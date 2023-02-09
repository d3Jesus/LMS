import Modal from "../../shared/modal/components/Modal";
import ModalBody from "../../shared/modal/components/ModalBody";
import ModalHeader from "../../shared/modal/components/ModalHeader";
// import ModalFooter from "../../shared/modal/components/ModalFooter";
import Form from "react-bootstrap/Form";
import Button from 'react-bootstrap/Button';
import { useState } from "react";

export default function AddAuthor(props) {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [nationality, setNationality] = useState("");

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      let res = await fetch("https://localhost:7078/api/authors", {
        method: "POST",
        body: JSON.stringify({
          firstName: firstName,
          lastName: lastName,
          nationality: nationality,
        }),
        mode: 'cors', cache: 'no-cache',
        headers: {
          'Content-Type': "application/json"
        }
      });
      let resJson = await res.json();
      console.log(resJson)
      if (resJson.succeeded) {
        alert("Success");
      } else {
        console.log(resJson.message);
        alert("Some error occured");
      }
    } catch (err) {
      console.log(err);
    }
  }

  return (
    <Modal>
      <ModalHeader>
        <h4 className="modal-title">New Author</h4>
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
            <Form.Label>Nationality</Form.Label>
            <Form.Control type="text" placeholder="Mozambican" value={nationality} onChange={(e) => setNationality(e.target.value)} />
          </Form.Group>
          <Button variant="outline-success" type="submit">
            Submit
          </Button>
        </Form>
      </ModalBody>
    </Modal>
  );
}