(function () {
    var EventHub = $.connection.eventHub;
    $.connection.hub.start()
                .done(function () {
                    console.log("connected");
                    EventHub.server.announce("connected");
                })
                .fail(function () { console.log("Not connected"); });

    EventHub.server.announce = function (message) {
        WriteToPage(message);
    }

    var WriteToPage = function (message) {
        $("#Toshow").append(message + "<br />");
    }
})()

