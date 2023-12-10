import React from 'react';
import Button from 'react-bootstrap/Button';

const UpdateDepartmentForm = ({ updateDepartment, handleUpdateDepartment, setUpdateDepartment }) => {

  return (
  <form onSubmit={handleUpdateDepartment}>
    <label>
      Name:
      <input
        type="text"
        name="name"
        value={updateDepartment.name}
        onChange={(e) => setUpdateDepartment({ ...updateDepartment, name: e.target.value })}
      />
    </label>
    <br />
    <label>
      Location:
      <input
        type="text"
        name="location"
        value={updateDepartment.location}
        onChange={(e) => setUpdateDepartment({ ...updateDepartment, location: e.target.value })}
      />
    </label>
    <br />
    <Button type="submit">Update Department</Button>
  </form>
  );
};

export default UpdateDepartmentForm;
