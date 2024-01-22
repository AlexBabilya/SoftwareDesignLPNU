import React from 'react';
import Button from 'react-bootstrap/Button';

const AddBookForm = ({ newBook, handleInputChange, handleAddBook }) => {

  return (
    <form onSubmit={handleAddBook}>
        <label>
          Title:
          <input
            type="text"
            name="title"
            value={newBook.title}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Publication Date:
          <input
            type="date"
            name="publicationDate"
            value={newBook.publicationDate}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Price:
          <input
            type="number"
            name="price"
            value={newBook.price}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Author ID:
          <input
            type="number"
            name="authorID"
            value={newBook.authorId}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Publisher ID:
          <input
            type="number"
            name="publisherID"
            value={newBook.publisherId}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <Button type="submit">Add Book</Button>
    </form>
  );
};

export default AddBookForm;
