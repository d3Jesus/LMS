import { useState, useEffect } from "react";
import Table from 'react-bootstrap/Table';
import Card from "react-bootstrap/Card";
import CardHeader from "../../shared/card/HeaderComponent";

import ModalRoot from '../../shared/modal/components/ModalRoot';
import { Container } from "react-bootstrap";
import TableHeader from "../../shared/table-components/TableHeaderComponent";
import TableOption from "../../shared/table-components/TableOptionsComponent";
import BreadCrumb from "../../shared/layout/BreadcrumbComponent";

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
                .then((result) => setListOfAuthors(result.responseData))
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
                        <Table responsive id='example'>
                            <TableHeader headers={tableHeaders} />
                            <tbody>
                                {
                                    listOfAuthors?.map(author =>
                                        <tr key={author.id}>
                                            <td>{author.firstName}</td>
                                            <td>{author.lastName}</td>
                                            <td>{author.nationality}</td>
                                            <TableOption id={author.id} />
                                        </tr>
                                    )
                                }
                            </tbody>
                        </Table>
                    </Container>
                </Card.Body>
            </Card>
        </>
    );
}

export default Authors;