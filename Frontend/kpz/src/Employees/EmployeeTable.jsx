
// employeeTable.js
import React from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

const EmployeeTable = ({ employees, onDelete, onUpdate }) => {
  const handleDelete = (employeeId) => {
    onDelete(employeeId);
  };

  const handleUpdate = (employeeId) => {
    onUpdate(employeeId);
  };

  return (
    <div>
      <h2 class="header">Employee Table</h2>
      <Table striped bordered hover variant="dark">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>HireDate</th>
            <th>Salary</th>
            <th>DepartmentID</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((employee) => (
            <tr key={employee.id}>
              <td>{employee.firstName}</td>
              <td>{employee.lastName}</td>
              <td>{employee.hireDate}</td>
              <td>{employee.salary}</td>
              <td>{employee.departmentID}</td>
              <td>
                <Button variant="success" onClick={() => handleUpdate(employee.id)}>Update</Button>
                <Button variant="danger" onClick={() => handleDelete(employee.id)}>Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default EmployeeTable;
