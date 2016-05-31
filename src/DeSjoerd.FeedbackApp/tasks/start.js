var bs = require('browser-sync').create();

bs.init({
    proxy: "http://localhost:5000"
}, function () {
    console.log("started");
});

process.stdin.on('data', function (data) {
    if (data === "#reload") {
        bs.reload();
    }
});