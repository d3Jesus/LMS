
import { Button } from 'react-bootstrap';
import Edit from '../../pages/author/Edit';
import ModalService from '../modal/services/ModalService';

const TableOption = ({ id }) => {

    const editModal = () => {
        ModalService.open(Edit, id);
    };

    return (
        <td>
            <div className="dropdown">
                <button className="btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <i className='bi bi-three-dots-vertical'></i>
                </button>
                <ul className="dropdown-menu dropdown-menu-dark bg-dark">
                    <li>
                        <Button variant="outline-success" onClick={editModal}
                            className="dropdown-item">
                            <i className='bi bi-pencil'></i>Edit
                        </Button>
                    </li>
                    <li>
                        <hr className="dropdown-divider border-top border-secondary" />
                    </li>
                    <li>
                        <Button variant="outline-danger"
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
