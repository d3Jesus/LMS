import React from "react";

import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';

import LayoutRoute from './LayoutRoute';


const LayoutComponent = () => {

    return (
        <>
            <Navbar expand="lg" sticky="top" className='mb-3'>
                <Container>
                    <Navbar.Brand to='/'>LMS</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse className='navbar-collapse' id="basic-navbar-nav">
                        <Nav className="navbar-nav mx-auto mb-2 mb-lg-0">
                            <Nav.Link href="/" className='nav-item'>Home</Nav.Link>
                            <Nav.Link href="/authors" className='nav-item'>Authors</Nav.Link>
                            <Nav.Link href="/bookcases" className='nav-item'>Bookcases</Nav.Link>
                            <Nav.Link href="/books" className='nav-item'>Books</Nav.Link>
                            <Nav.Link href="/librarians" className='nav-item'>Librarian</Nav.Link>
                            <Nav.Link href="/booking" className='nav-item'>Booking</Nav.Link>
                            <Nav.Link href="/requisitions" className='nav-item'>Requisition</Nav.Link>
                        </Nav>
                        <Button variant="outline-danger" className='btn-sm'>Log out</Button>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
            <LayoutRoute />
        </>

    );
}

export default LayoutComponent;
