var BASE_API_URI = "https://localhost:7262/api";


var TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJLdWxsYW5pY2lJZCI6MjMsInJvbGUiOiJZb25ldGltS3VydWx1QmFza2FuaSIsIlNpcmtldCI6IkFobGF0w6fEsSBIb2xkaW5nIEEuxZ4uICjDnHN0IMWeaXJrZXQpIiwibmJmIjoxNjk4MjM5OTAxLCJleHAiOjE2OTgyNDM1MDEsImlhdCI6MTY5ODIzOTkwMX0.jjSAONDN095PxHjbVgewcBUrgcKB4hrJYGc6vPL52aU";

function Get(url, success) {
    $.ajax({
        type: "GET",
        url: `Category/GetAllCategory`,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {
                success(response.data);
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}

function Delete(action, success, ask = true) {
    var confirmed = true;
    if (ask) {
        confirmed = confirm("Kaydı silmek istediğinizden emin misiniz?");
    }
    if (confirmed) {
        $.ajax({
            type: "DELETE",
            url: `${BASE_API_URI}/${action}`,
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
            },
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.success) {
                    success(response.data);
                }
                else {
                    alert(response.message);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
            }
        });
    }
}


function Post(data, success) {
    $.ajax({
        type: "POST",
        url: `/Account/Login`,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        success: function (response) {
            if (response.success) {
                success(response.data);
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}

function PostRedirect(data) {
    $.ajax({
        url: `Account/Login`,
        type: "POST",
        datatype: "json",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        processData: false,
        success: function (response) {
            if (response.result == 'Redirect')
                window.location = response.url;
        }
    });
}
function Get2(url, success) {
    $.ajax({
        type: "GET",
        url: url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            success(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}

function Post2(url,data, success) {
    $.ajax({
        type: "POST",
        url: url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${TOKEN}`);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        success: function (response) {
            success(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}