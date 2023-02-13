import { useState, useEffect } from "react";
import Card from "react-bootstrap/Card";
import CardHeader from "../../shared/card/HeaderComponent";

import ModalRoot from '../../shared/modal/components/ModalRoot';
import { Container } from "react-bootstrap";
import BreadCrumb from "../../shared/layout/BreadcrumbComponent";
import TableComponent from "./TableComponent";
import SpinnerComponent from "../../shared/layout/SpinnerComponent";

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
                <CardHeader title="List of Authors" />
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