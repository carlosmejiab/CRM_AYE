function ShowMessage(message, messagetype) {
    var cssclass;
    switch (messagetype) {
        case 'Success':
            cssclass = 'alert-success'
            break;
        case 'Error':
            cssclass = 'alert-danger'
            break;
        case 'Warning':
            cssclass = 'alert-warning'
            break;
        default:
            cssclass = 'alert-info'
    }
    $('#alert_container').append('<div id="alert_div"  style="text-align:left" class="alert ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + 'Aviso' + '! </strong> <span>' + message + '</span></div>');

    setTimeout(function () {
        $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            $("#alert_div").remove();
        });
    }, 3000);//5000=5 seconds          
}