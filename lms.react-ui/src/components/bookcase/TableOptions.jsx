
import { Button } from 'react-bootstrap';
import ModalService from '../../shared/modal/services/ModalService';
import DeleteConfirmation from '../../shared/layout/DeleteConfirmation';
import EditBookcase from './EditBookcase';

const TableOption = ({ id }) => {

    const editModal = () => {
        ModalService.open(EditBookcase, id);
    };
    const deleteModal = () => {
        DeleteConfirmation(id, 'BOOKCASE')
    };

    return (
        <td>
            <div className="dropdown">
                <button className="btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <i className='bi bi-three-dots-vertical'></i>
                </button>
                <ul className="dropdown-menu dropdown-menu-dark bg-dark">
                    <li>
                        <Button variant="outline-success"
                            onClick={editModal}
                            className="dropdown-item">
                            <i className='bi bi-pencil'></i>Edit
                        </Button>
                    </li>
                    <li>
                        <hr className="dropdown-divider border-top border-secondary" />
                    </li>
                    <li>
                        <Button variant="outline-danger" 
                            onClick={deleteModal}
                            className="dropdown-item">
                            <i className='bi bi-trash-o'></i>Delete
                        </Button>
                    </li>
                </ul>
            </div>
        </td>
    );
}

export default TableOption;
