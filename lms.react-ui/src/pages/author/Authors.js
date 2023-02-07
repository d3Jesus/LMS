import { useState, useEffect } from "react";
import Table from 'react-bootstrap/Table';
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";

import ModalRoot from '../../shared/modal/components/ModalRoot';
import ModalService from '../../shared/modal/services/ModalService';
import TestModal from './AddModal';

import getAuthors from '../author/Services';

const Authors = () => {

    const [listOfAuthors, setListOfAuthors] = useState([]);
    useEffect(() => {
        getAuthors().then((result) => setListOfAuthors(result.responseData))
    }, []);

    const addModal = () => {
        ModalService.open(TestModal);
    };

    return (
        <>
            <ModalRoot />
            <Card>
                <Card.Header>
                    List of Authors
                    <Button variant="outline-success" onClick={addModal}
                        className="btn-sm btn-radius btn-card-add">
                        <i className='bi bi-plus-lg'></i>Add
                    </Button>
                </Card.Header>
                <Card.Body>
                    <div className="table-responsive">
                        <Table striped id='example'>
                            <thead>
                                <tr>
                                    <th>FirstName</th>
                                    <th>LastName</th>
                                    <th>Nationality</th>
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
                    </div>
                </Card.Body>
            </Card>

        </>
    );
}

export default Authors;