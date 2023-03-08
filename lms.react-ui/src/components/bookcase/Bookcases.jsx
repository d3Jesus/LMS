import { useState, useEffect } from "react";
import { Container, Button } from "react-bootstrap";
import Card from "react-bootstrap/Card";
import ModalRoot from '../../shared/modal/components/ModalRoot';
import BreadCrumb from "../../shared/layout/BreadcrumbComponent";
import SpinnerComponent from "../../shared/layout/SpinnerComponent";
import TableComponent from "./TableComponent";

import AddBookcase from "./Add";
import ModalService from '../../shared/modal/services/ModalService';

const tableHeaders = ["Section", "Hall", "Options"];

const breadcrumbs = [
    {
        text: "Home",
        isActive: true
    },
    {
        text: "Bookcases",
        isActive: true
    }
];

const Bookcases = () => {

    const addModal = () => {
        ModalService.open(AddBookcase);
    };

    const [listOfBookcases, setListOfBookcases] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);

    useEffect(() => {
        const getBookcases = async () => {
            await fetch('https://localhost:7078/api/bookcases')
                .then((response) => {
                    if (response.ok) {
                        return response.json()
                    } else {
                        throw new Error("Sorry something went wrong")
                    }
                })
                .then((result) => {
                    setListOfBookcases(result.responseData)
                    setDataLoaded(true);
                })
        }
        getBookcases()
    }, []);

    return (
        <>
            <ModalRoot />
            <BreadCrumb breadcrumbs={breadcrumbs} />
            <Card>
                <Card.Header>
                    List of Bookcases
                    <Button variant="outline-primary" onClick={addModal}
                        className="btn-sm btn-radius btn-card-add">
                        <i className='bi bi-plus-lg'></i>Add
                    </Button>
                </Card.Header>
                <Card.Body>
                    <Container>
                        {dataLoaded ?
                            <TableComponent headers={tableHeaders} bookcases={listOfBookcases} />
                            :
                            <SpinnerComponent />
                        }
                    </Container>
                </Card.Body>
            </Card>

        </>
    );
}

export default Bookcases;