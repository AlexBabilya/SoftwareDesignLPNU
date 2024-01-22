import React from 'react';
import Button from 'react-bootstrap/Button';

const AddEmployeeForm = ({ newEmployee, handleInputChange, handleAddEmployee }) => {

  return (
    <form onSubmit={handleAddEmployee}>
        <label>
          First Name:
          <input
            type="text"
            name="firstName"
            value={newEmployee.firstName}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Last Name:
          <input
            type="text"
            name="lastName"
            value={newEmployee.lastName}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Hire Date:
          <input
            type="date"
            name="hireDate"
            value={newEmployee.hireDate}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Salary:
          <input
            type="number"
            name="salary"
            value={newEmployee.salary}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
         Department ID:
          <input
            type="number"
            name="departmentID"
            value={newEmployee.departmentID}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <Button type="submit">Add Employee</Button>
    </form>
  );
};

export default AddEmployeeForm;
