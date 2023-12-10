import React from 'react';
import Button from 'react-bootstrap/Button';

const AddPublisherForm = ({ newPublisher, handleInputChange, handleAddPublisher }) => {

  return (
    <form onSubmit={handleAddPublisher}>
        <label>
          Name:
          <input
            type="text"
            name="name"
            value={newPublisher.name}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Address:
          <input
            type="text"
            name="address"
            value={newPublisher.address}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Phone:
          <input
            type="phone"
            name="phone"
            value={newPublisher.phone}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <Button type="submit">Add Publisher</Button>
    </form>
  );
};

export default AddPublisherForm;
