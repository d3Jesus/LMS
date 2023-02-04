
import Table from 'react-bootstrap/Table';

const TableComponent = () => {
    return (
        <div className="table-responsive">
            <Table striped id='example'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Position</th>
                        <th>Office</th>
                        <th>Age</th>
                        <th>Start date</th>
                        <th>Salary</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Tiger Nixon</td>
                        <td>System Architect</td>
                        <td>Edinburgh</td>
                        <td>61</td>
                        <td>2011-04-25</td>
                        <td>$320,800</td>
                        <td>
                            <div className="dropdown">
                                <button className="btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i className='bi bi-three-dots-vertical'></i>
                                </button>
                                <ul className="dropdown-menu dropdown-menu-dark bg-dark">
                                    <li><a className="dropdown-item" href="#">Edit</a></li>
                                    <li>
                                        <hr className="dropdown-divider border-top border-secondary"/>
                                    </li>
                                    <li><a className="dropdown-item text-danger" href="#">Delete</a></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Donna Snider</td>
                        <td>Customer Support</td>
                        <td>New York</td>
                        <td>27</td>
                        <td>2011-01-25</td>
                        <td>$112,000</td>
                        <td>
                            <div className="dropdown">
                                <button className="btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i className='bi bi-three-dots-vertical'></i>
                                </button>
                                <ul className="dropdown-menu dropdown-menu-dark bg-dark">
                                    <li><a className="dropdown-item" href="#">Edit</a></li>
                                    <li>
                                        <hr className="dropdown-divider border-top border-secondary"/>
                                    </li>
                                    <li><a className="dropdown-item text-danger" href="#">Delete</a></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </Table>
        </div>
    );
}

export default TableComponent;
