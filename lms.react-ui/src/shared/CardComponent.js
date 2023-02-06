import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import TableComponent from "./TableComponent";

import ModalRoot from './modal/ModalRoot';
import ModalService from './modal/services/ModalService';
import TestModal from './modal/TestModal';

const CardComponent = () => {

    const addModal = () => {
        ModalService.open(TestModal);
    };

    return (
        <>
            <ModalRoot />
            <Card>
                <Card.Header>
                    Card
                    <Button variant="outline-success" onClick={addModal}
                        className="btn-sm btn-radius btn-card-add">
                        <i className='bi bi-plus-lg'></i>Add
                    </Button>
                </Card.Header>
                <Card.Body>
                    <TableComponent />
                </Card.Body>
            </Card>
        </>
    );
}

export default CardComponent;