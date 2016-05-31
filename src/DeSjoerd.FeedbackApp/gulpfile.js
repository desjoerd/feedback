var gulp = require('gulp');
var Dotnet = require('gulp-dotnet');

var runSequence = require('run-sequence');
var paths = './**/*.cs';

gulp.task('build:csharp', function (cb) {
    Dotnet.build({ cwd: './' }, cb);
});


function changed(event) {
    //gutil.log(`File ${event.path} was ${event.type}, running tasks...`);
};

gulp.task('watch', function () {
    gulp.watch(paths, { interval: 500 }, function () {
        runSequence('build:csharp', 'start:api');
    }).on('change', changed);
});

var server;
gulp.task('start:api', function (cb) {
    if (!server) server = new Dotnet({ cwd: paths.api });
    server.start('run', cb);
});