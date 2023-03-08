import Swal from 'sweetalert2'
import Delete from '../../components/author/Services/DeleteService';

function DeleteConfirmation(id, actionOn) {
    Swal.fire({
        'title': 'Are you sure?',
        'text': "You won't be able to revert this!",
        'icon': 'warning',
        'showCancelButton': true,
        'confirmButtonColor': '#d33',
        'cancelButtonColor': '#3085d6',
        'confirmButtonText': 'Yes, delete it!',
        'allowOutsideClick': false,
        'allowEscapeKey': false
    }).then((result) => {
        if (result.isConfirmed) {
            
            switch (actionOn) {
                case 'AUTHOR':
                    Delete(id);
                    break;
                default:
                    break;
            }
        }
    })
}

export default DeleteConfirmation;