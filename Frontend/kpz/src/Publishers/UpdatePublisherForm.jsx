import React from 'react';
import Button from 'react-bootstrap/Button';

const UpdatePublisherForm = ({ updatePublisher, handleUpdatePublisher, setUpdatePublisher }) => {

  return (
  <form onSubmit={handleUpdatePublisher}>
    <label>
      Name:
      <input
        type="text"
        name="name"
        value={updatePublisher.name}
        onChange={(e) => setUpdatePublisher({ ...updatePublisher, name: e.target.value })}
      />
    </label>
    <br />
    <label>
      Address:
      <input
        type="text"
        name="address"
        value={updatePublisher.address}
        onChange={(e) => setUpdatePublisher({ ...updatePublisher, address: e.target.value })}
      />
    </label>
    <br />
    <label>
      Phone:
      <input
        type="phone"
        name="phone"
        value={updatePublisher.phone}
        onChange={(e) => setUpdatePublisher({ ...updatePublisher, phone: e.target.value })}
      />
    </label>
    <br />
    <Button type="submit">Update Publisher</Button>
  </form>
  );
};

export default UpdatePublisherForm;
