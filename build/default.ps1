﻿Framework "4.0x86"

properties {
	$baseDir = Resolve-Path ".."
	$buildtoolsDir = Resolve-Path "."
	$outDir = "$(Resolve-Path "".."")\bin"
	$configuration = "Debug"
	$releaseTagPattern = "release-(.*)"
	$skipTests = $false
	$autoVersion = $true
}

Function Get-DependencyVersion($RawVersion) {
	If ($RawVersion -Match "-.+$") {
		return $RawVersion
	}
	else {
		Return $RawVersion -replace "^([0-9]+\.[0-9]+).*","`$1"
	}
}

Task default -Depends Build

Task Clean {
	if (Test-Path $outDir) {
		rm -Recurse -Force "$outDir" >$null
	}
	md "$outDir" >$null
}

Task Build-Solution -Depends Clean, Generate-VersionInfo {
	Exec { msbuild "$baseDir\Linq.sln" /verbosity:minimal /p:"Configuration=$configuration" }
}

Task Run-Tests -Depends Build-Solution {
	if (-not $skipTests) {
		$runner = (dir "$baseDir\packages" -Recurse -Filter nunit-console.exe | Select -ExpandProperty FullName)
		Exec { & "$runner" "$baseDir\Linq.Tests\Linq.Tests.csproj" -nologo -xml "$outDir\TestResults.xml" }
	}
}

Task Build-NuGetPackages -Depends Determine-Version, Run-Tests {
	$config = [xml](Get-Content $baseDir\Linq\packages.config)
	$runtimeVersion = $config.SelectSingleNode("//package[@id='Saltarelle.Runtime']/@version").Value
@"
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
	<metadata>
		<id>Saltarelle.Linq</id>
		<version>$script:Version</version>
		<title>Linq for the Saltarelle C# to JavaScript compiler</title>
		<description>Import library for Linq.js (linqjs.codeplex.com) for projects compiled with Saltarelle.Compiler. Unfortunately the official version is slightly incompatible with the Saltarelle runtime so you have to use the JS files included in this package instead of the official linq.js release.</description>
		<licenseUrl>http://www.apache.org/licenses/LICENSE-2.0.txt</licenseUrl>
		<authors>Yoshifumi Kawai, Erik Källén</authors>
		<projectUrl>http://www.saltarelle-compiler.com</projectUrl>
		<tags>compiler c# javascript web</tags>
		<dependencies>
			<dependency id="Saltarelle.Runtime" version="$(Get-DependencyVersion $runtimeVersion)"/>
		</dependencies>
	</metadata>
	<files>
		<file src="$baseDir\License.txt" target=""/>
		<file src="$baseDir\history.txt" target=""/>
		<file src="$baseDir\Linq\bin\Saltarelle.Linq.dll" target="lib"/>
		<file src="$baseDir\Linq\bin\Saltarelle.Linq.xml" target="lib"/>
		<file src="$baseDir\Linq.Script\bin\linq.js" target=""/>
		<file src="$baseDir\Linq.Script\bin\linq.min.js" target=""/>
	</files>
</package>
"@ | Out-File -Encoding UTF8 "$outDir\Linq.nuspec"

	Exec { & "$buildtoolsDir\nuget.exe" pack "$outDir\Linq.nuspec" -NoPackageAnalysis -OutputDirectory "$outDir" }
}

Task Build -Depends Build-NuGetPackages {
}

Task Configure -Depends Generate-VersionInfo {
}

Function Determine-PathVersion($RefCommit, $RefVersion, $Path) {
	if ($autoVersion) {
		if ($RefVersion -Match "^[0-9]+\.[0-9]+$") {
			$RefVersion = "$RefVersion.0"
		}

		$revision = ((git log "$RefCommit..HEAD" --pretty=format:"%H" -- (@($Path) | % { """$_""" })) | Measure-Object).Count # Number of commits since our reference commit
		if ($RefVersion -Match "-.*$") {
			$RefVersion = "$RefVersion-$($revision.ToString('0000'))"
		}
		elseif ($revision -gt 0) {
			$RefVersion = "$RefVersion.$revision"
		}
	}

	Return $RefVersion
}

Function Determine-Ref {
	$refcommit = % {
	(git log --decorate=full --simplify-by-decoration --pretty=oneline HEAD |           # Append items from the log
		Select-String '\(' |                                                            # Only include entries with names
		% { ($_ -replace "^[^(]*\(([^)]*)\).*$","`$1" -replace " ", "").Split(',') } |  # Select only the names, one line per name, delete spaces
		Select-String "^tag:$releaseTagPattern`$" |                                     # Only tags of interest
		% { $_ -replace "^tag:","" }                                                    # Remove the tag: prefix
	) } { git log --reverse --pretty=format:%H | Select-Object -First 1 } |             # Add the oldest commit as a fallback
	Select-Object -First 1
	
	If ($refcommit | Select-String "^$releaseTagPattern`$") {
		$refVersion = $refcommit -replace "^$releaseTagPattern`$","`$1"
	}
	else {
		$refVersion = "0.0.0"
	}

	($refcommit, $refVersion)
}

Task Determine-Version {
	if (-not $autoVersion) {
		if ((git log -1 --decorate=full --simplify-by-decoration --pretty=oneline HEAD |
			 Select-String '\(' |
			 % { ($_ -replace "^[^(]*\(([^)]*)\).*$","`$1" -replace " ", "").Split(',') } |
			 Select-String "^tag:$releaseTagPattern`$" |
			 % { $_ -replace "^tag:","" } |
			 Measure-Object
			).Count -eq 0) {
			
			Throw "The most recent commit must be tagged when not using auto-versioning"
		}
	}

	$refs = Determine-Ref
	$script:Version = Determine-PathVersion -RefCommit $refs[0] -RefVersion $refs[1] -Path "$baseDir"

	"Version: $script:Version"
}

Function Generate-VersionFile($Path, $Version) {
	$Version -match "^[0-9]+" | Out-Null
@"
[assembly: System.Reflection.AssemblyVersion("$($Matches[0]).0.0.0")]
[assembly: System.Reflection.AssemblyFileVersion("$($Version -Replace '-.*$','')")]
"@ | Out-File $Path -Encoding "UTF8"
}

Task Generate-VersionInfo -Depends Determine-Version {
	Generate-VersionFile -Path "$baseDir\Linq\Properties\Version.cs" -Version $script:Version
}
