
// Write your JavaScript code.

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover({
        placement: 'bottom',
        content: function () {
            return $("#notification-content").html();
        },
        html: true
    });

    $('body').append(`<div id="notification-content" class="hide"></div>`)


    function getNotification() {

        var res = "<ul class='list-group'>";
        $.ajax({
            url: "/Notification/GetNotification",
            method: "GET",
            success: function (result) {
                if (result.count != 0) {
                    $("#notificationCount").html(result.count);
                    $("#notificationCount").show('slow');
                } else {
                    $("#notificationCount").html();
                    $("#notificationCount").hide('slow');
                    $("#notificationCount").popover('hide');
                }

                //var notifications = result.userNotification;
                //notifications.forEach(element => {
                //    res = res + "<li class='list-group-item notification-text' data-id='" + element.notification.id + "'>" + element.notification.text + "</li>";
                //});
               res = res + "<li class='list-group-item notification-text'>New Activity Is Assigned</li>";

                res = res + "</ul>";

                $("#notification-content").html(res);

                console.log(result);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    $("ul").on('click', 'li.notification-text', function (e) {
        var target = e.target;
        var id = $(target).data('id');

        readNotification(id, target);
    })

    function readNotification(id, target) {
        $.ajax({
            url: "~/Notification/ReadNotification",
            method: "GET",
            data: { notificationId: id },
            success: function (result) {
                getNotification();
                $(target).fadeOut('slow');
            },
            error: function (error) {
                console.log(error);
            }
        })
    }

    getNotification();

    //let connection = new signalR.HubConnection("signalServer");

    //connection.on('displayNotification', () => {
    //    debugger;
    //    getNotification();
    //});

    //connection.start();


    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/SignalServer")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    };

    connection.on("ReceiveMessage", (user, message) => {
       getNotification();

        //const li = document.createElement("li");
        //li.textContent = `${user}: ${message}`;
        //document.getElementById("messageList").appendChild(li);
    });

    connection.onclose(start);

    // Start the connection.
    start();

});

function isNumberKey(txt, evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode == 46) {
        //Check if the text already contains the . character
        if (txt.value.indexOf('.') === -1) {
            return true;
        } else {
            return false;
        }
    } else {
        if (charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;
    }
    return true;
}