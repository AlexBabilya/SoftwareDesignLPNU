import React, { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import BookTable from '../components/Books/BookTable';
import AddBookForm from '../components/Books/AddBookForm';
import UpdateBookForm from '../components/Books/UpdateBookForm';
import MyNavbar from '../components/Navbar';

const apiUrl = process.env.REACT_APP_API_URL;

const BooksPage = () => {
  const [Books, setBooks] = useState([]);
  const [newBook, setNewBook] = useState({
    title: '',
    publicationDate: '',
    price: null,
    authorID: null,
    publisherID: null,
  });
 const [updateBook, setUpdateBook] = useState({
    id: null,
    title: '',
    publicationDate: '',
    price: null,
    authorID: null,
    publisherID: null,
  });
  useEffect(() => {
    // Function to fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await fetch(`${apiUrl}/books/`);
        const data = await response.json();
        console.log(data);
        setBooks(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    // Call the function to fetch data when the component mounts
    fetchData();
  }, []);

  const handleDelete = async (BookId) => {
    try {
      // Make the DELETE request to delete the Book
      const response = await fetch(`${apiUrl}/books/${BookId}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        // If the request is successful, update the Books state
        setBooks(Books.filter((Book) => Book.id !== BookId));
      } else {
        console.error('Error deleting Book:', response.status);
      }
    } catch (error) {
      console.error('Error deleting Book:', error);
    }
  };

  const handleInputChange = (e) => {
    // Update the newBook state when the input fields change
    setNewBook({
      ...newBook,
      [e.target.name]: e.target.value,
    });
  };

  const handleAddBook = async (e) => {
    e.preventDefault();

    try {
      // Make the POST request to add a new Book
      const response = await fetch(`${apiUrl}/books/`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newBook),
      });

      if (response.ok) {
        // If the request is successful, update the Books state and reset the form
        setBooks([...Books, newBook]);
        setNewBook({
          title: '',
          publicationDate: '',
          price: null,
          authorID: null,
          publisherID: null,
        });
      } else {
        console.error('Error adding Book:', response.status);
      }
    } catch (error) {
      console.error('Error adding Book:', error);
    }
  };
  const handleUpdate = (BookId) => {
    // Find the Book to update
    const BookToUpdate = Books.find((Book) => Book.id === BookId);

    // Set the updateBook state with the current Book data
    setUpdateBook({
      id: BookToUpdate.id,
      title: BookToUpdate.title,
      publicationDate: BookToUpdate.publicationDate,
      price: BookToUpdate.price,
      authorID: BookToUpdate.authorID,
      publisherID: BookToUpdate.publisherID,
    });
  };

  const handleUpdateBook = async (e) => {
    e.preventDefault();
    try {
      // Make the PUT request to update the Book
      const response = await fetch(`${apiUrl}/Books/${updateBook.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateBook),
      });

      if (response.ok) {
        // If the request is successful, update the Books state and reset the form
        setBooks(Books.map((Book) => (Book.id === updateBook.id ? updateBook : Book)));
        setUpdateBook({
          id: null,
          title: '',
          publicationDate: '',
          price: null,
          authorID: null,
          publisherID: null,
        });
      } else {
        console.error('Error updating Book:', response.status);
      }
    } catch (error) {
      console.error('Error updating Book:1', error);
    }
  };

  return (
    <div>
      <MyNavbar />        
        <BookTable id="Books" Books={Books} onDelete={handleDelete} onUpdate={handleUpdate} />
        <Container>
          <Row>
            <Col>
              <h2 className="input-header">Add Book</h2>
            < AddBookForm
              newBook={newBook} 
              handleInputChange={handleInputChange} 
              handleAddBook={handleAddBook}/>
            </Col>
            <Col>
              <h2 className="input-header">Update Book</h2>
              <UpdateBookForm
                updateBook={updateBook}
                handleUpdateBook={handleUpdateBook}
                setUpdateBook={setUpdateBook}
              />
            </Col>
          </Row>
      </Container>
    </div>
  );
};

export default BooksPage;
