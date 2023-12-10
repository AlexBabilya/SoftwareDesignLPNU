import React, { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import AuthorTable from './AuthorTable';
import AddAuthorForm from './AddAuthorForm';
import UpdateAuthorForm from './UpdateAuthorForm';
import MyNavbar from '../Navbar';

const AuthorsPage = () => {
  const [authors, setAuthors] = useState([]);
  const [newAuthor, setNewAuthor] = useState({
    firstName: '',
    lastName: '',
    birthdate: '',
    nationality: '',
  });
 const [updateAuthor, setUpdateAuthor] = useState({
    id: null,
    firstName: '',
    lastName: '',
    birthdate: '',
    nationality: '',
  });
  useEffect(() => {
    // Function to fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5004/api/authors/');
        const data = await response.json();
        setAuthors(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    // Call the function to fetch data when the component mounts
    fetchData();
  }, []);

  const handleDelete = async (authorId) => {
    try {
      // Make the DELETE request to delete the author
      const response = await fetch(`http://localhost:5004/api/authors/${authorId}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        // If the request is successful, update the authors state
        setAuthors(authors.filter((author) => author.id !== authorId));
      } else {
        console.error('Error deleting author:', response.status);
      }
    } catch (error) {
      console.error('Error deleting author:', error);
    }
  };

  const handleInputChange = (e) => {
    // Update the newAuthor state when the input fields change
    setNewAuthor({
      ...newAuthor,
      [e.target.name]: e.target.value,
    });
  };

  const handleAddAuthor = async (e) => {
    e.preventDefault();

    try {
      // Make the POST request to add a new author
      const response = await fetch('http://localhost:5004/api/authors/', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newAuthor),
      });

      if (response.ok) {
        // If the request is successful, update the authors state and reset the form
        setAuthors([...authors, newAuthor]);
        setNewAuthor({
          firstName: '',
          lastName: '',
          birthdate: '',
          nationality: '',
        });
      } else {
        console.error('Error adding author:', response.status);
      }
    } catch (error) {
      console.error('Error adding author:', error);
    }
  };
  const handleUpdate = (authorId) => {
    // Find the author to update
    const authorToUpdate = authors.find((author) => author.id === authorId);

    // Set the updateAuthor state with the current author data
    setUpdateAuthor({
      id: authorToUpdate.id,
      firstName: authorToUpdate.firstName,
      lastName: authorToUpdate.lastName,
      birthdate: authorToUpdate.birthdate,
      nationality: authorToUpdate.nationality,
    });
  };

  const handleUpdateAuthor = async (e) => {
    e.preventDefault();
    try {
      // Make the PUT request to update the author
      const response = await fetch(`http://localhost:5004/api/authors/${updateAuthor.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateAuthor),
      });

      if (response.ok) {
        // If the request is successful, update the authors state and reset the form
        setAuthors(authors.map((author) => (author.id === updateAuthor.id ? updateAuthor : author)));
        setUpdateAuthor({
          id: null,
          firstName: '',
          lastName: '',
          birthdate: '',
          nationality: '',
        });
      } else {
        console.error('Error updating author:', response.status);
      }
    } catch (error) {
      console.error('Error updating author:1', error);
    }
  };

  return (
    <div>
      <MyNavbar />
      <AuthorTable id="authors" authors={authors} onDelete={handleDelete} onUpdate={handleUpdate} />
      <Container>
        <Row>
        <Col>
        <h2 class="input-header">Add Author</h2>
          < AddAuthorForm
            newAuthor={newAuthor} 
            handleInputChange={handleInputChange} 
            handleAddAuthor={handleAddAuthor}/>
       </Col>
        <Col>
          <h2 class="input-header">Update Author</h2>
          <UpdateAuthorForm
            updateAuthor={updateAuthor}
            handleUpdateAuthor={handleUpdateAuthor}
            setUpdateAuthor={setUpdateAuthor}
          />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default AuthorsPage;
