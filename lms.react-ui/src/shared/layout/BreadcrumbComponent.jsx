
import Breadcrumb from "react-bootstrap/Breadcrumb";

const BreadCrumb = ({ breadcrumbs }) => {
    return (
        <Breadcrumb>
            {breadcrumbs.map(breadcrumb =>
                <Breadcrumb.Item active={breadcrumb.isActive} key={breadcrumb.text}>
                    {breadcrumb.text}
                </Breadcrumb.Item>)}
        </Breadcrumb>
    );
}

export default BreadCrumb;
