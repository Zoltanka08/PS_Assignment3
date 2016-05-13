// Handle click event on Update button
function updateClick() {
}
// Handle click event on Add button
function addClick() {
}


function userList() {
    // Call Web API to get a list of user
    $.ajax({
        url: '/api/Patient/GetAll',
        type: 'GET',
        dataType: 'json',
        success: function (users) {
            userListSuccess(users);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function userListSuccess(users) {
    // Iterate over the collection of data
    $.each(users, function (index, user) {
        // Add a row to the user table
        userAddRow(user);
    });
}

function userAddRow(user) {
    // Check if <tbody> tag exists, add one if not
    if ($("#userTable tbody").length == 0) {
        $("#userTable").append("<tbody></tbody>");
    }
    // Append row to <table>
    $("#userTable tbody").append(
      userBuildTableRow(user));
}

function userBuildTableRow(user) {
    var ret =
      "<tr>" +
       "<td>" + user.Firstname + "</td>"
        + "<td>" + user.Lastname + "</td>" +
        "<td>" +
          "<button type='button' " +
             "onclick='notifyDoctors(this);' " +
             "class='btn btn-default' " +
             "data-id='" + user.Id + "'>" +
             "<span class='glyphicon glyphicon-edit' />"
           + "</button>" +
        "</td >" +
      "</tr>";
    return ret;
}

function notifyDoctors(ctl) {

    // Get user id from data- attribute
    var id = $(ctl).data("id");

    // Store user id in hidden field
    $("#UserId").val(id);

    // Call Web API to get a list of users
    $.ajax({
        url: "/api/Patient/NotifyDoctors/" + id,
        type: 'GET',
        dataType: 'json',
        success: function (user) {
            notify(user);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function userGet(ctl) {
    // Get user id from data- attribute
    var id = $(ctl).data("id");

    // Store user id in hidden field
    $("#UserId").val(id);

    // Call Web API to get a list of users
    $.ajax({
        url: "/api/User/GetUserById/" + id,
        type: 'GET',
        dataType: 'json',
        success: function (user) {
            userToFields(user);

            // Change Update Button Text
            $("#updateButton").text("Update");
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function notify(message) {
   
    alert(message);
}

function handleException(request, message,
                 error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" +
            request.responseJSON.Message + "\n";
    }
    alert(msg);
}

$(document).ready(function () {
    userList();
});