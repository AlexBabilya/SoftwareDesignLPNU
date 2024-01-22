
// BookTable.js
import React from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

const BookTable = ({ Books, onDelete, onUpdate }) => {
  const handleDelete = (BookId) => {
    onDelete(BookId);
  };

  const handleUpdate = (BookId) => {
    onUpdate(BookId);
  };

  return (
    <div>
      <h2 className="header">Book Table</h2>
      <Table striped bordered hover variant="dark">
        <thead>
          <tr>
            <th>Title</th>
            <th>PublicationDate</th>
            <th>Price</th>
            <th>AuthorId</th>
            <th>PublisherId</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {Books.map((Book) => (
            <tr key={Book.id}>
              <td>{Book.title}</td>
              <td>{Book.publicationDate}</td>
              <td>{Book.price}</td>
              <td>{Book.authorId}</td>
              <td>{Book.publisherId}</td>
              <td>
                <Button variant="success" onClick={() => handleUpdate(Book.id)}>Update</Button>
                <Button variant="danger" onClick={() => handleDelete(Book.id)}>Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default BookTable;
