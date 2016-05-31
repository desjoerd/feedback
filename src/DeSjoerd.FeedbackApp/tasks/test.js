var bs = require('browser-sync').create();

module.exports.test = function (callback) {

    bs.reload();

    callback(undefined, "Hello from js!");
}