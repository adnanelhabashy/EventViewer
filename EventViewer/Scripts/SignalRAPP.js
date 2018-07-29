(function () {
    var EventHub = $.connection.EventHub;
    $.connection.hub.start()
                .done(function () {
                    $.connection.hub.logging = true;
                    console.log("connected");
                    EventHub.server.announce("connected");
                    
                })
                .fail(function () { console.log("Not connected"); });

    EventHub.client.announce = function (message) {
        WriteToPage(message);
    };
    
    var WriteToPage = function (message) {
        $("#Toshow").append(message + "<br />");
    }

    $("#ClickMe").click(function () {
        EventHub.server.getServerDateTime()
                    .done(function (data) {
                        WriteToPage(data)
                    })
                    .fail(function (e) {
                        WriteToPage("Failed to get date Error :" + e);
                    });
    });
})()

