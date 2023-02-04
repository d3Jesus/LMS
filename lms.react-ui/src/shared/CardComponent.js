import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import TableComponent from "./TableComponent";

const CardComponent = () => {
    return (
        <Card>
            <Card.Header>
                Card
                <Button variant="outline-success" 
                    className="btn-sm btn-radius btn-card-add">
                        <i class='bi bi-plus-lg'></i>Add
                </Button>
            </Card.Header>
            <Card.Body>
                <TableComponent/>
            </Card.Body>
        </Card>
    );
}

export default CardComponent;