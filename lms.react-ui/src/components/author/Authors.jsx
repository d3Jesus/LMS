import { useState, useEffect } from "react";
import Card from "react-bootstrap/Card";

import ModalRoot from '../../shared/modal/components/ModalRoot';
import { Button, Container } from "react-bootstrap";
import BreadCrumb from "../../shared/layout/BreadcrumbComponent";
import TableComponent from "./TableComponent";
import SpinnerComponent from "../../shared/layout/SpinnerComponent";
import AddAuthor from "./Add";
import ModalService from "../../shared/modal/services/ModalService";

const tableHeaders = ["First Name", "Last Name", "Nationality", "Options"];
const breadcrumbs = [
    {
        text: "Home",
        isActive: true
    },
    {
        text: "Authors",
        isActive: true
    }
];

const Authors = () => {

    const addModal = () => {
        ModalService.open(AddAuthor);
    };

    const [listOfAuthors, setListOfAuthors] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);

    useEffect(() => {
        const getAuthors = async () => {
            await fetch('https://localhost:7078/api/authors')
                .then((response) => {
                    if (response.ok) {
                        return response.json()
                    } else {
                        throw new Error("Sorry something went wrong")
                    }
                })
                .then((result) => {
                    setListOfAuthors(result.responseData)
                    setDataLoaded(true);
                })
        }
        getAuthors()
    }, []);

    return (
        <>
            <ModalRoot />
            <BreadCrumb breadcrumbs={breadcrumbs} />
            <Card>
                <Card.Header>
                    List of Authors
                    <Button variant="outline-primary" onClick={addModal}
                        className="btn-sm btn-radius btn-card-add">
                        <i className='bi bi-plus-lg'></i>Add
                    </Button>
                </Card.Header>
                <Card.Body>
                    <Container>
                        {dataLoaded ?
                            <TableComponent headers={tableHeaders} authors={listOfAuthors} />
                            :
                            <SpinnerComponent />
                        }
                    </Container>
                </Card.Body>
            </Card>

        </>
    );
}

export default Authors;