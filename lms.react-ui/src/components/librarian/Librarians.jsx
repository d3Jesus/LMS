import { useState, useEffect } from "react";
import { Container, Button } from "react-bootstrap";
import Card from "react-bootstrap/Card";
import ModalRoot from '../../shared/modal/components/ModalRoot';
import BreadCrumb from "../../shared/layout/BreadcrumbComponent";
import SpinnerComponent from "../../shared/layout/SpinnerComponent";
import TableComponent from "./TableComponent";

import AddLibrarian from "./AddLibrarian";
import ModalService from '../../shared/modal/services/ModalService';

const breadcrumbs = [
    {
        text: "Home",
        isActive: true
    },
    {
        text: "Librarians",
        isActive: true
    }
];

const Librarians = () => {

    const addModal = () => {
        ModalService.open(AddLibrarian);
    };

    const [listOfLibrarians, setListOfLibrarians] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);

    useEffect(() => {
        const getLibrarians = async () => {
            await fetch('https://localhost:7078/api/librarians')
                .then((response) => {
                    if (response.ok) {
                        return response.json()
                    } else {
                        throw new Error("Sorry something went wrong")
                    }
                })
                .then((result) => {
                    setListOfLibrarians(result.responseData)
                    setDataLoaded(true);
                })
        }
        getLibrarians()
    }, []);

    return (
        <>
            <ModalRoot />
            <BreadCrumb breadcrumbs={breadcrumbs} />
            <Card>
                <Card.Header>
                    List of Librarians
                    <Button variant="outline-primary" onClick={addModal}
                        className="btn-sm btn-radius btn-card-add">
                        <i className='bi bi-plus-lg'></i>Add
                    </Button>
                </Card.Header>
                <Card.Body>
                    <Container>
                        {dataLoaded ?
                            <TableComponent librarians={listOfLibrarians} />
                            :
                            <SpinnerComponent />
                        }
                    </Container>
                </Card.Body>
            </Card>

        </>
    );
}

export default Librarians;