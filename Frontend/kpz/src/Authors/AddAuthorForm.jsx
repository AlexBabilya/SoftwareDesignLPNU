import React from 'react';
import Button from 'react-bootstrap/Button';

const AddAuthorForm = ({ newAuthor, handleInputChange, handleAddAuthor }) => {

  return (
    <form onSubmit={handleAddAuthor}>
        <label>
          First Name:
          <input
            type="text"
            name="firstName"
            value={newAuthor.firstName}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Last Name:
          <input
            type="text"
            name="lastName"
            value={newAuthor.lastName}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Birthdate:
          <input
            type="date"
            name="birthdate"
            value={newAuthor.birthdate}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Nationality:
          <input
            type="text"
            name="nationality"
            value={newAuthor.nationality}
            onChange={handleInputChange}
            placeholder = "Max 3 Chars"
          />
        </label>
        <br />
        <Button type="submit">Add Author</Button>
    </form>
  );
};

export default AddAuthorForm;
