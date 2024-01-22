import React from 'react';

import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';


const MyNavbar = () => {
  return (
    <Navbar bg="dark" data-bs-theme="dark">
        <Container>
          <Navbar.Brand href="/">KPZ</Navbar.Brand>
          <Nav>
            <Nav.Link href="/Authors">Authors</Nav.Link>
            <Nav.Link href="/Books">Books</Nav.Link>
            <Nav.Link href="/Employees">Employees</Nav.Link>
            <Nav.Link href="/Publishers">Publishers</Nav.Link>
            <Nav.Link href="/Departments">Departments</Nav.Link>
          </Nav>
          <Navbar.Text className="justify-content-end">
            By Babilia Oleksandr PZ-31
          </Navbar.Text>
        </Container>
      </Navbar>
  );
};

export default MyNavbar;
