import { useState, useEffect } from "react";
import Table from 'react-bootstrap/Table';
import Card from "react-bootstrap/Card";
import CardHeader from "../../shared/card/HeaderComponent";

import ModalRoot from '../../shared/modal/components/ModalRoot';

import getAuthors from '../author/Services';
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
        setTimeout(() => {
            getAuthors().then((result) => setListOfAuthors(result.responseData))
        }, 2000)
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
                                            <TableOption editUrl={"/authors/" + author.id} deleteUrl={"/authors/" + + author.id} />
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