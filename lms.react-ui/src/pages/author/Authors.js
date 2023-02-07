import { useState, useEffect } from "react";
import Table from 'react-bootstrap/Table';
import Card from "react-bootstrap/Card";
import CardHeader from "../../shared/card/HeaderComponent";

import ModalRoot from '../../shared/modal/components/ModalRoot';

import getAuthors from '../author/Services';
import { Container } from "react-bootstrap";

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
            <Card>
                <CardHeader title="List of Authors" />
                <Card.Body>
                    <Container>
                        <Table responsive id='example'>
                            <thead>
                                <tr>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Nationality</th>
                                    <th>Options</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    listOfAuthors?.map(author =>
                                        <tr key={author.id}>
                                            <td>{author.firstName}</td>
                                            <td>{author.lastName}</td>
                                            <td>{author.nationality}</td>
                                            <td>
                                                <div className="dropdown">
                                                    <button className="btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                                        <i className='bi bi-three-dots-vertical'></i>
                                                    </button>
                                                    <ul className="dropdown-menu dropdown-menu-dark bg-dark">
                                                        <li><a className="dropdown-item" href="/">Edit</a></li>
                                                        <li>
                                                            <hr className="dropdown-divider border-top border-secondary" />
                                                        </li>
                                                        <li><a className="dropdown-item text-danger" href="/">Delete</a></li>
                                                    </ul>
                                                </div>
                                            </td>
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