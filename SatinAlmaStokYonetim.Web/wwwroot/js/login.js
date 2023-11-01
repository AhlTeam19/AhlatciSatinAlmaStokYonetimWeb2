
function login() {

    var data = {
        userName: document.getElementById("username").value,
        userPassword: document.getElementById("password").value,
    }
    PostRedirect(data, (data) => {

    });
}
