
// AuthorTable.js
import React from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

const AuthorTable = ({ authors, onDelete, onUpdate }) => {
  const handleDelete = (authorId) => {
    onDelete(authorId);
  };

  const handleUpdate = (authorId) => {
    onUpdate(authorId);
  };

  return (
    <div>
      <h2 className="header">Author Table</h2>
      <Table striped bordered hover variant="dark">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Birthdate</th>
            <th>Nationality</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {authors.map((author) => (
            <tr key={author.id}>
              <td>{author.firstName}</td>
              <td>{author.lastName}</td>
              <td>{author.birthdate}</td>
              <td>{author.nationality}</td>
              <td>
              <Button variant="success" onClick={() => handleUpdate(author.id)}>Update</Button>
              <Button variant="danger" onClick={() => handleDelete(author.id)}>Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
        </Table>
    </div>
  );
};

export default AuthorTable;
