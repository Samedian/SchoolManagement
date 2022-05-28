$(document).ready(function () {
    var $regexname = /^([A-Za-z]{3,16})$/;
    $('#nameData').on('blur', function () {
        if (!$(this).val().match($regexname)) {
            alert("Name is not Valid");
        }
        
    });
});