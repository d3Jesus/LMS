
import TableHeader from "../../shared/table-components/TableHeaderComponent";
import TableOption from "./TableOptions";

import { Table } from "react-bootstrap";
import { useEffect } from "react";

const TableComponent = ({ librarians }) => {

    const headers = ["First Name", "Last Name", "Email", "Options"];

    useEffect(() => {
        const setDataTable = () => {
            return window.DataTablesAdd('#librarian')
        }
        setDataTable()
    }, []);
    return (
        <>
            <Table responsive id='librarian'>
                <TableHeader headers={headers} />
                <tbody>
                    {
                        librarians.map(librarian =>
                            <tr key={librarian.id}>
                                <td>{librarian.firstName}</td>
                                <td>{librarian.lastName}</td>
                                <td>{librarian.email}</td>
                                <TableOption id={librarian.id} />
                            </tr>
                        )
                    }
                </tbody>
            </Table>
        </>
    )
}

export default TableComponent;