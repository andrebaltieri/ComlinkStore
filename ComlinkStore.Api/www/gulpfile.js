var gulp = require('gulp');
var cssmin = require('gulp-cssmin');
var uglify = require('gulp-uglify');
var jsvalidate = require('gulp-jsvalidate');
var concat = require('gulp-concat');

var paths = {
    css:{
        src:[
            'bower_components/angular-material/angular-material.css',
            'custom_components/css/**.css'
        ],
        dest:'wwwroot/dev/assets/css/',
        file: 'styles.css'
    },
    scripts: {
        src: [
            'app/app.js',
            'app/config.js',
            'app/routes.js',
            'app/controllers/**.js',
            'app/data/**.js',
            'app/directives/**.js',
        ],
        dest: 'dist/assets/js/',
        file: 'scripts-1.0.0.js'
    }
};

gulp.task('css', function () {
    gulp.src(paths.css.src)
        .pipe(concat(paths.css.file))
        .pipe(gulp.dest(paths.css.dest));
});

gulp.task('script', function () {
    return gulp
        .src(paths.scripts.src)
        .pipe(jsvalidate())
        .pipe(uglify(paths.scripts.src))
        .pipe(concat(paths.scripts.file))        
        .pipe(gulp.dest(paths.scripts.dest))
});

// gulp.task('default', ['script', 'css']);
gulp.task('default', ['script']);