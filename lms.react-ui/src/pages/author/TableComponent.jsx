
import TableHeader from "../../shared/table-components/TableHeaderComponent";
import TableOption from "../../shared/table-components/TableOptionsComponent";

import { Table } from "react-bootstrap";
import { useEffect } from "react";

const TableComponent = ({ headers, authors }) => {

    useEffect(() => {
        const sayHello = () => {
            return window.DataTablesAdd('#example')
        }
        sayHello()
    }, []);
    return (
        <>
            {/* <button onClick={window['alertHello']}>alert</button> */}
            <Table responsive id='example'>
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