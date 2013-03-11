var testrunner = require('qunit');
testrunner.setup({
	log: {
		json: true
	}
});
testrunner.run({
	deps: ['../mscorlib.js', '../linq.js'],
	code: '../Linq.TestScript.js',
	tests: process.argv[2],
});
