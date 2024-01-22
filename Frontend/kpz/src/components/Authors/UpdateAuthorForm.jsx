import React from 'react';
import Button from 'react-bootstrap/Button';

const UpdateAuthorForm = ({ updateAuthor, handleUpdateAuthor, setUpdateAuthor }) => {

  return (
  <form onSubmit={handleUpdateAuthor}>
    <label>
      First Name:
      <input
        type="text"
        name="firstName"
        value={updateAuthor.firstName}
        onChange={(e) => setUpdateAuthor({ ...updateAuthor, firstName: e.target.value })}
      />
    </label>
    <br />
    <label>
      Last Name:
      <input
        type="text"
        name="lastName"
        value={updateAuthor.lastName}
        onChange={(e) => setUpdateAuthor({ ...updateAuthor, lastName: e.target.value })}
      />
    </label>
    <br />
    <label>
      Birthdate:
      <input
        type="date"
        name="birthdate"
        value={updateAuthor.birthdate}
        onChange={(e) => setUpdateAuthor({ ...updateAuthor, birthdate: e.target.value })}
      />
    </label>
    <br />
    <label>
      Nationality:
      <input
        type="text"
        name="nationality"
        value={updateAuthor.nationality}
        onChange={(e) => setUpdateAuthor({ ...updateAuthor, nationality: e.target.value })}
      />
    </label>
    <br />
    <Button type="submit">Update Author</Button>
  </form>
  );
};

export default UpdateAuthorForm;
