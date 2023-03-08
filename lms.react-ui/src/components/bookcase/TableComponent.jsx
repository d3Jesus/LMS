
import TableHeader from "../../shared/table-components/TableHeaderComponent";
import TableOption from "./TableOptions";

import { Table } from "react-bootstrap";
import { useEffect } from "react";

const TableComponent = ({ headers, bookcases }) => {

    useEffect(() => {
        const setDataTable = () => {
            return window.DataTablesAdd('#bookcase')
        }
        setDataTable()
    }, []);
    return (
        <>
            <Table responsive id='bookcase'>
                <TableHeader headers={headers} />
                <tbody>
                    {
                        bookcases.map(bookcase =>
                            <tr key={bookcase.id}>
                                <td>{bookcase.section}</td>
                                <td>{bookcase.hall}</td>
                                <TableOption id={bookcase.id} />
                            </tr>
                        )
                    }
                </tbody>
            </Table>
        </>
    )
}

export default TableComponent;