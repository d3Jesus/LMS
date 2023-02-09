import Modal from "../../shared/modal/components/Modal";
import ModalBody from "../../shared/modal/components/ModalBody";
import ModalHeader from "../../shared/modal/components/ModalHeader";

import Form from "react-bootstrap/Form";
import Button from 'react-bootstrap/Button';
import { useEffect, useState } from "react";

export default function EditAuthor(props) {
    // const id = props.id;
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [nationality, setNationality] = useState("");

    useEffect(() => {
        const getAuthor = async () => {
            const url = `https://localhost:7078/api/authors/4`;
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
                        const author = result.responseData
                        setFirstName(author.firstName)
                        setLastName(author.lastName)
                        setNationality(author.nationality)
                    }
                    else
                        alert(result.message)
                })
        }
        getAuthor()
    }, [props.id]);


    // const handleSubmit = async (event) => {
    //   event.preventDefault();

    //   try {
    //     let res = await fetch("https://localhost:7078/api/authors", {
    //       method: "GET",
    //       body: JSON.stringify({
    //         id: props.id
    //       }),
    //       mode: 'cors', cache: 'no-cache',
    //       headers: {
    //         'Content-Type': "application/json"
    //       }
    //     });
    //     let resJson = await res.json();
    //     console.log(resJson)
    //     if (resJson.succeeded) {
    //       alert("Success");
    //     } else {
    //       console.log(resJson.message);
    //       alert(resJson.message);
    //     }
    //   } catch (err) {
    //     console.log(err);
    //   }
    // }

    return (
        <Modal>
            <ModalHeader>
                <h4 className="modal-title">Edit Author</h4>
                <button type="button" onClick={props.close} className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </ModalHeader>
            <ModalBody>
                <Form /*onSubmit={handleSubmit}*/>
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