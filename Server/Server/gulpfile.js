/// <binding BeforeBuild='build'/>
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

"use strict";

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify");

var paths = {
    webroot: "./website/",
    release: "./wwwroot/",
    publish: "../PublishOutput/wwwroot"
};

//specify js files path, order is important
paths.js = [
    paths.webroot + "lib/huypq.arrayUtils.js",
    paths.webroot + "lib/huypq.dateTimeUtils.js",
    paths.webroot + "lib/huypq.control.utilsDOM.js",
    paths.webroot + "lib/headerMenu/huypq.control.headerMenu.js",
    paths.webroot + "lib/datepicker/huypq.ko.binding.datepicker.js",
    paths.webroot + "lib/combobox/huypq.ko.binding.combobox.js",
    paths.webroot + "lib/datagrid/huypq.control.datagrid.js",
    paths.webroot + "js/defineNamespace.js",
    paths.webroot + "js/webApi.js",
    paths.webroot + "js/referenceDataManager.js",
    paths.webroot + "js/dataProvider.js",
    paths.webroot + "js/dataProvider/*.js",
    paths.webroot + "js/viewModel/*.js",
    paths.webroot + "js/viewManager.js",
    paths.webroot + "js/view/*.js",
    paths.webroot + "js/app.js"
];

//specify cs files path, order is important
paths.css = [
    paths.webroot + "lib/headerMenu/huypq.control.headerMenu.css",
    paths.webroot + "lib/datepicker/huypq.ko.binding.datepicker.css",
    paths.webroot + "lib/combobox/huypq.ko.binding.combobox.css",
    paths.webroot + "lib/datagrid/huypq.control.datagrid.css",
    paths.webroot + "css/*.css"
];

paths.image = [
    paths.webroot + "lib/headerMenu/images/*.*",
    paths.webroot + "css/images/*.*"
];

//release
paths.minJsDest = paths.release + "site.min.js";
paths.minCssDest = paths.release + "site.min.css";
paths.imageDest = paths.release + "images";

gulp.task("clean:image", function (cb) {
    rimraf(paths.imageDest, cb);
});

gulp.task("min:js", function () {
    return gulp.src(paths.js)
      .pipe(concat(paths.minJsDest))
      .pipe(uglify())
      .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src(paths.css)
      .pipe(concat(paths.minCssDest))
      .pipe(cssmin())
      .pipe(gulp.dest("."));
});

gulp.task("copy:image", ["clean:image"], function () {
    return gulp.src(paths.image)
      .pipe(gulp.dest(paths.imageDest));
});

gulp.task("copy:wwwroot-build", ["build"], function () {
    return gulp.src(paths.release + "**")
        .pipe(gulp.dest(paths.publish));
});

gulp.task("build", ["clean:image", "min:js", "min:css", "copy:image"]);

gulp.task("#publish", ["build", "copy:wwwroot-build"]);


//debug
paths.jsDebugDest = paths.webroot + "site.debug.js";
paths.cssDebugDest = paths.webroot + "site.debug.css";
paths.imageDebugDest = paths.webroot + "images";

gulp.task("clean-debug:image", function (cb) {
    rimraf(paths.imageDebugDest, cb);
});

gulp.task("debug:js", function () {
    return gulp.src(paths.js)
        .pipe(concat(paths.jsDebugDest))
        .pipe(gulp.dest("."));
});

gulp.task("debug:css", function () {
    return gulp.src(paths.css)
        .pipe(concat(paths.cssDebugDest))
        .pipe(gulp.dest("."));
});

gulp.task("copy-debug:image", ["clean-debug:image"], function () {
    return gulp.src(paths.image)
        .pipe(gulp.dest(paths.imageDebugDest));
});

gulp.task("#debug", ["clean-debug:image", "debug:js", "debug:css", "copy-debug:image"]);
