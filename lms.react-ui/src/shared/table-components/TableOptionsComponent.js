const TableOption = ({ editUrl, deleteUrl }) => {
    return (
        <td>
            <div className="dropdown">
                <button className="btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <i className='bi bi-three-dots-vertical'></i>
                </button>
                <ul className="dropdown-menu dropdown-menu-dark bg-dark">
                    <li><a className="dropdown-item" href={editUrl}  >Edit</a></li>
                    <li>
                        <hr className="dropdown-divider border-top border-secondary" />
                    </li>
                    <li><a className="dropdown-item text-danger" href={deleteUrl}>Delete</a></li>
                </ul>
            </div>
        </td>
        // <thead>
        //     <tr>
        //         {
        //             headers.map(header =>
        //                 <th key={header}>{header}</th>)
        //         }
        //     </tr>
        // </thead>
    );
}

export default TableOption;
