import Swal from 'sweetalert2'

function Alert(icon, title, message, url ) {
    
    Swal.fire(
        {
            'icon': icon,
            'title': title,
            'text': message,
            'showConfirmButton': true,
            'confirmButtonText': "OK",
            'allowOutsideClick': false,
            'allowEscapeKey': false
        }
    ).then(function () {
        window.location.href = url;
    });
}

export default Alert;