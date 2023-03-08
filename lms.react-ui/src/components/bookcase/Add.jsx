import Modal from "../../shared/modal/components/Modal";
import ModalBody from "../../shared/modal/components/ModalBody";
import ModalHeader from "../../shared/modal/components/ModalHeader";
import Form from "react-bootstrap/Form";
import Button from 'react-bootstrap/Button';
import { useState } from "react";
import AddService from "./services/AddService";

export default function AddBookcase(props) {
    const [section, setSection] = useState("");
    const [hall, setHall] = useState("");

    const handleSubmit = async (event) => {
        event.preventDefault();

        const newBookcase = {
            section: section,
            hall: hall,
        }

        AddService(newBookcase);
    }

    return (
        <Modal>
            <ModalHeader>
                <h4 className="modal-title">New Bookcase</h4>
                <button type="button" onClick={props.close} className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </ModalHeader>
            <ModalBody>
                <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3">
                        <Form.Label>Section</Form.Label>
                        <Form.Control type="text" placeholder="Science" value={section} onChange={(e) => setSection(e.target.value)} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Hall</Form.Label>
                        <Form.Control type="text" placeholder="F" value={hall} onChange={(e) => setHall(e.target.value)} />
                    </Form.Group>
                    <Button variant="outline-success" type="submit">
                        Submit
                    </Button>
                </Form>
            </ModalBody>
        </Modal>
    );
}