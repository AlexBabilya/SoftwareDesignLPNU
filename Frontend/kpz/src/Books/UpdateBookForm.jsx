import React from 'react';
import Button from 'react-bootstrap/Button';

const UpdateBookForm = ({ updateBook, handleUpdateBook, setUpdateBook }) => {

  return (
  <form onSubmit={handleUpdateBook}>
    <label>
      Title:
      <input
        type="text"
        name="title"
        value={updateBook.title}
        onChange={(e) => setUpdateBook({ ...updateBook, title: e.target.value })}
      />
    </label>
    <br />
    <label>
      Publication Date:
      <input
        type="date"
        name="publicationDate"
        value={updateBook.publicationDate}
        onChange={(e) => setUpdateBook({ ...updateBook, publicationDate: e.target.value })}
      />
    </label>
    <br />
    <label>
      Price:
      <input
        type="number"
        name="price"
        value={updateBook.price}
        onChange={(e) => setUpdateBook({ ...updateBook, price: e.target.value })}
      />
    </label>
    <br />
    <label>
      Author ID:
      <input
        type="number"
        name="authorID"
        value={updateBook.authorID}
        onChange={(e) => setUpdateBook({ ...updateBook, authorID: e.target.value })}
      />
    </label>
    <br />
    <label>
      Publisher ID:
      <input
        type="number"
        name="publisherID"
        value={updateBook.publisherID}
        onChange={(e) => setUpdateBook({ ...updateBook, publisherID: e.target.value })}
      />
    </label>
    <br />
    <Button type="submit">Update Book</Button>
  </form>
  );
};

export default UpdateBookForm;
