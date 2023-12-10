import React, { useEffect, useState } from 'react';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import PublisherTable from './PublisherTable';
import AddPublisherForm from './AddPublisherForm';
import UpdatePublisherForm from './UpdatePublisherForm';
import MyNavbar from '../Navbar';

const PublishersPage = () => {
  const [Publishers, setPublishers] = useState([]);
  const [newPublisher, setNewPublisher] = useState({
    name: '',
    address: '',
    phone: '',
  });
 const [updatePublisher, setUpdatePublisher] = useState({
    id: null,
    name: '',
    address: '',
    phone: '',
  });
  useEffect(() => {
    // Function to fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5004/api/Publishers/');
        const data = await response.json();
        setPublishers(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    // Call the function to fetch data when the component mounts
    fetchData();
  }, []);

  const handleDelete = async (PublisherId) => {
    try {
      // Make the DELETE request to delete the Publisher
      const response = await fetch(`http://localhost:5004/api/Publishers/${PublisherId}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        // If the request is successful, update the Publishers state
        setPublishers(Publishers.filter((Publisher) => Publisher.id !== PublisherId));
      } else {
        console.error('Error deleting Publisher:', response.status);
      }
    } catch (error) {
      console.error('Error deleting Publisher:', error);
    }
  };

  const handleInputChange = (e) => {
    // Update the newPublisher state when the input fields change
    setNewPublisher({
      ...newPublisher,
      [e.target.name]: e.target.value,
    });
  };

  const handleAddPublisher = async (e) => {
    e.preventDefault();

    try {
      // Make the POST request to add a new Publisher
      const response = await fetch('http://localhost:5004/api/Publishers/', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newPublisher),
      });

      if (response.ok) {
        // If the request is successful, update the Publishers state and reset the form
        setPublishers([...Publishers, newPublisher]);
        setNewPublisher({
          name: '',
          address: '',
          phone: '',
        });
      } else {
        console.error('Error adding Publisher:', response.status);
      }
    } catch (error) {
      console.error('Error adding Publisher:', error);
    }
  };
  const handleUpdate = (PublisherId) => {
    // Find the Publisher to update
    const PublisherToUpdate = Publishers.find((Publisher) => Publisher.id === PublisherId);

    // Set the updatePublisher state with the current Publisher data
    setUpdatePublisher({
      id: PublisherToUpdate.id,
      name: PublisherToUpdate.name,
      address: PublisherToUpdate.address,
      phone: PublisherToUpdate.phone,
    });
  };

  const handleUpdatePublisher = async (e) => {
    e.preventDefault();
    try {
      // Make the PUT request to update the Publisher
      const response = await fetch(`http://localhost:5004/api/Publishers/${updatePublisher.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatePublisher),
      });

      if (response.ok) {
        // If the request is successful, update the Publishers state and reset the form
        setPublishers(Publishers.map((Publisher) => (Publisher.id === updatePublisher.id ? updatePublisher : Publisher)));
        setUpdatePublisher({
          id: null,
          name: '',
          address: '',
          phone: '',
        });
      } else {
        console.error('Error updating Publisher:', response.status);
      }
    } catch (error) {
      console.error('Error updating Publisher:1', error);
    }
  };

  return (
    <div>
      <MyNavbar />
      <PublisherTable id="Publishers" Publishers={Publishers} onDelete={handleDelete} onUpdate={handleUpdate} />
      <Container>
        <Row>
          <Col>
            <h2 class="input-header">Add Publisher</h2>
            < AddPublisherForm
              newPublisher={newPublisher} 
              handleInputChange={handleInputChange} 
              handleAddPublisher={handleAddPublisher}/>
          </Col>
          <Col>
            <h2 class="input-header">Update Publisher</h2>
            <UpdatePublisherForm
              updatePublisher={updatePublisher}
              handleUpdatePublisher={handleUpdatePublisher}
              setUpdatePublisher={setUpdatePublisher}
            />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default PublishersPage;
