import Modal from "../../shared/modal/components/Modal";
import ModalBody from "../../shared/modal/components/ModalBody";
import ModalHeader from "../../shared/modal/components/ModalHeader";

import AddService from './services/AddLibrarianService'

import Form from "react-bootstrap/Form";
import Button from 'react-bootstrap/Button';
import { useState } from "react";

export default function AddLibrarian(props) {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [address, setAddress] = useState("");
    const [email, setEmail] = useState("");

    const handleSubmit = async (event) => {
        event.preventDefault();

        const newLibrarian = {
            firstName: firstName,
            lastName: lastName,
            address: address,
            email: email
        }

        AddService(newLibrarian);
    }

    return (
        <Modal>
            <ModalHeader>
                <h4 className="modal-title">New Librarian</h4>
                <button type="button" onClick={props.close} className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </ModalHeader>
            <ModalBody>
                <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3">
                        <Form.Label>First Name</Form.Label>
                        <Form.Control type="text" placeholder="John" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Last Name</Form.Label>
                        <Form.Control type="text" placeholder="Doe" value={lastName} onChange={(e) => setLastName(e.target.value)} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Address</Form.Label>
                        <Form.Control type="text" placeholder="Mozambican" value={address} onChange={(e) => setAddress(e.target.value)} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" placeholder="example@example.com" value={email} onChange={(e) => setEmail(e.target.value)} />
                    </Form.Group>
                    <Button variant="outline-success" type="submit">
                        Submit
                    </Button>
                </Form>
            </ModalBody>
        </Modal>
    );
}