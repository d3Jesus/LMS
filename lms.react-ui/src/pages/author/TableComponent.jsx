
import TableHeader from "../../shared/table-components/TableHeaderComponent";
import TableOption from "./TableOptions";

import { Table } from "react-bootstrap";
import { useEffect } from "react";

const TableComponent = ({ headers, authors }) => {

    useEffect(() => {
        const setDataTable = () => {
            return window.DataTablesAdd('#author')
        }
        setDataTable()
    }, []);
    return (
        <>
            <Table responsive id='author'>
                <TableHeader headers={headers} />
                <tbody>
                    {
                        authors.map(author =>
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
        </>
    )
}

export default TableComponent;