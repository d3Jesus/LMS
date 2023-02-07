
import Button from "react-bootstrap/Button";
import ModalService from '../modal/services/ModalService';
import Add from '../../pages/author/AddModal';


const CardButton = () => {
    const addModal = () => {
        ModalService.open(Add);
    };

    return (
        <Button variant="outline-success" onClick={addModal}
            className="btn-sm btn-radius btn-card-add">
            <i className='bi bi-plus-lg'></i>Add
        </Button>
    )
}

export default CardButton;