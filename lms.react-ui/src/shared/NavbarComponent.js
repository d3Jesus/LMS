import { NavLink } from "react-router-dom";

import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';

const NavigationBar = () => {
    return (
        <Navbar expand="lg" sticky="top" className='mb-3'>
            <Container>
                <Navbar.Brand to='/'>LMS</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse className='navbar-collapse' id="basic-navbar-nav">
                    <Nav className="navbar-nav mx-auto mb-2 mb-lg-0">
                        <Nav.Link to="/" className='nav-item active'>Home</Nav.Link>
                        <Nav.Link to="/authors" className='nav-item'>Authors</Nav.Link>
                        <Nav.Link to="#" className='nav-item'>Shelfs</Nav.Link>
                        <Nav.Link to="#" className='nav-item'>Books</Nav.Link>
                        <Nav.Link to="#" className='nav-item'>Librarian</Nav.Link>
                        <Nav.Link to="#" className='nav-item'>Booking</Nav.Link>
                        <Nav.Link to="#" className='nav-item'>Requisition</Nav.Link>
                    </Nav>
                    <Button variant="outline-danger" className='btn-sm'>Log out</Button>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavigationBar;
