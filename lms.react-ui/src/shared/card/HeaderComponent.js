
import Card from "react-bootstrap/Card";
import CardButton from './ButtonComponent'

const CardHeader = ({title}) => {
    return (
        <Card.Header>
           {title}
            <CardButton />
        </Card.Header>
    )
}

export default CardHeader;