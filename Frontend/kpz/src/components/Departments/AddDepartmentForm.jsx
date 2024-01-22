import React from 'react';
import Button from 'react-bootstrap/Button';

const AddDepartmentForm = ({ newDepartment, handleInputChange, handleAddDepartment }) => {

  return (
    <form onSubmit={handleAddDepartment}>
      <label>
          Name:
          <input
            type="text"
            name="name"
            value={newDepartment.name}
            onChange={handleInputChange}
          />
        </label>
        
        <br />
        <label>
          Location:
          <input
            type="text"
            name="location"
            value={newDepartment.location}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <Button type="submit">Add Department</Button>
    </form>
  );
};

export default AddDepartmentForm;
