import Modal from "../../shared/modal/components/Modal";
import ModalBody from "../../shared/modal/components/ModalBody";
import ModalHeader from "../../shared/modal/components/ModalHeader";

import Form from "react-bootstrap/Form";
import Button from 'react-bootstrap/Button';
import { useEffect, useState } from "react";

import EditService from '../bookcase/services/EditBookcaseService'
import Alert from "../../shared/layout/Alert";

export default function EditBookcase(props) {
    const [section, setSection] = useState("");
    const [hall, setHall] = useState("");

    useEffect(() => {
        const getBookcase = async () => {
            const url = `https://localhost:7078/api/bookcases/${props.id}`;
            await fetch(url)
                .then((response) => {
                    if (response.ok) {
                        return response.json()
                    } else {
                        throw new Error("Sorry something went wrong")
                    }
                })
                .then((result) => {

                    if (result.succeeded) {
                        const bookcase = result.responseData
                        setSection(bookcase.section)
                        setHall(bookcase.hall)
                    }
                    else
                        Alert("error", "Error", result.message, "/bookcases");
                })
        }
        getBookcase()
    }, [props.id]);

    const handleSubmit = async (event) => {
        event.preventDefault();

        const existingBookcase = {
            id: props.id,
            section: section,
            hall: hall
        }

        EditService(existingBookcase)
    }

    return (
        <Modal>
            <ModalHeader>
                <h4 className="modal-title">Edit Bookcase</h4>
                <button type="button" onClick={props.close}
                    className="btn-close" data-bs-dismiss="modal"
                    aria-label="Close">
                </button>
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