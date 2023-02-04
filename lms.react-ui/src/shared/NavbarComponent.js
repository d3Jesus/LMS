
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';

const NavigationBar = () => {
    return (
        <Navbar expand="lg" sticky="top" className='mb-3'>
            <Container>
                <Navbar.Brand href='#'>LMS</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse className='navbar-collapse' id="basic-navbar-nav">
                    <Nav className="navbar-nav mx-auto mb-2 mb-lg-0">
                        <Nav.Link href="#" className='nav-item active'>Home</Nav.Link>
                        <Nav.Link href="#" className='nav-item'>Authors</Nav.Link>
                        <Nav.Link href="#" className='nav-item'>Shelfs</Nav.Link>
                        <Nav.Link href="#" className='nav-item'>Books</Nav.Link>
                        <Nav.Link href="#" className='nav-item'>Librarian</Nav.Link>
                        <Nav.Link href="#" className='nav-item'>Booking</Nav.Link>
                        <Nav.Link href="#" className='nav-item'>Requisition</Nav.Link>                        
                    </Nav>
                    <Button variant="outline-danger" className='btn-sm'>Log out</Button>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavigationBar;
