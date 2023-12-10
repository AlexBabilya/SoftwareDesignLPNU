import React from 'react';
import Button from 'react-bootstrap/Button';

const UpdateEmployeeForm = ({ updateEmployee, handleUpdateEmployee, setUpdateEmployee }) => {

  return (
  <form onSubmit={handleUpdateEmployee}>
    <label>
      First Name:
      <input
        type="text"
        name="firstName"
        value={updateEmployee.firstName}
        onChange={(e) => setUpdateEmployee({ ...updateEmployee, firstName: e.target.value })}
      />
    </label>
    <br />
    <label>
      Last Name:
      <input
        type="text"
        name="lastName"
        value={updateEmployee.lastName}
        onChange={(e) => setUpdateEmployee({ ...updateEmployee, lastName: e.target.value })}
      />
    </label>
    <br />
    <label>
      Hire Date:
      <input
        type="date"
        name="hireDate"
        value={updateEmployee.hireDate}
        onChange={(e) => setUpdateEmployee({ ...updateEmployee, hireDate: e.target.value })}
      />
    </label>
    <br />
    <label>
      Department ID:
      <input
        type="number"
        name="departmentID"
        value={updateEmployee.departmentID}
        onChange={(e) => setUpdateEmployee({ ...updateEmployee, departmentID: e.target.value })}
      />
    </label>
    <br />
    <Button type="submit">Update Employee</Button>
  </form>
  );
};

export default UpdateEmployeeForm;
