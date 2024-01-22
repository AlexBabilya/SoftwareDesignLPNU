
// DepartmentTable.js
import React from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

const DepartmentTable = ({ Departments, onDelete, onUpdate }) => {
  const handleDelete = (DepartmentId) => {
    onDelete(DepartmentId);
  };

  const handleUpdate = (DepartmentId) => {
    onUpdate(DepartmentId);
  };

  return (
    <div>
      <h2 className="header">Department Table</h2>
      <Table striped bordered hover variant="dark">
        <thead>
          <tr>
            <th>Name</th>
            <th>Location</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {Departments.map((Department) => (
            <tr key={Department.id}>
              <td>{Department.name}</td>
              <td>{Department.location}</td>
              <td>
              <Button variant="success" onClick={() => handleUpdate(Department.id)}>Update</Button>
              <Button variant="danger" onClick={() => handleDelete(Department.id)}>Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
        </Table>
    </div>
  );
};

export default DepartmentTable;
