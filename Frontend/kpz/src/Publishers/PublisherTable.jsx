
// PublisherTable.js
import React from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

const PublisherTable = ({ Publishers, onDelete, onUpdate }) => {
  const handleDelete = (PublisherId) => {
    onDelete(PublisherId);
  };

  const handleUpdate = (PublisherId) => {
    onUpdate(PublisherId);
  };

  return (
    <div>
      <h2 class="header">Publisher Table</h2>
      <Table striped bordered hover variant="dark">
        <thead>
          <tr>
            <th>Name</th>
            <th>Address</th>
            <th>Phone</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {Publishers.map((Publisher) => (
            <tr key={Publisher.id}>
              <td>{Publisher.name}</td>
              <td>{Publisher.address}</td>
              <td>{Publisher.phone}</td>
              <td>
              <Button variant="success" onClick={() => handleUpdate(Publisher.id)}>Update</Button>
              <Button variant="danger" onClick={() => handleDelete(Publisher.id)}>Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
        </Table>
    </div>
  );
};

export default PublisherTable;
