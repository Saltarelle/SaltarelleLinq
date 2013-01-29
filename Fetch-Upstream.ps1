$currentBranch = git rev-parse --abbrev-ref HEAD

git checkout upstream
if ($LastExitCode -ne 0) {
	return
}
git submodule update

$commit = git ls-tree head -- Upstream | %{ $_ -replace "^\S+\s\S+\s(\S+)\s.*$","`$1" }
cd Upstream
git fetch -q origin
git checkout -qf origin/v3
$patches = git format-patch -o ..\patches $commit -- linq.js | % { Resolve-Path $_ }
cd ..
if ($patches.Count -gt 0) {
	$patches | %{ git am --whitespace=fix --directory=Linq.Script $_ }
	git add Upstream
	git commit -m "Upstream @ $(Get-Date -Format ""yyyy-MM-dd"")"
}

rm -recurse -force patches
rm -recurse -force Upstream
git checkout -f $currentBranch
