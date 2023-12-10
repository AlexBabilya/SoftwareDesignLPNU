import React, { useEffect, useState } from 'react';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import DepartmentTable from './DepartmentTable';
import AddDepartmentForm from './AddDepartmentForm';
import UpdateDepartmentForm from './UpdateDepartmentForm';
import MyNavbar from '../Navbar';

const DepartmentsPage = () => {
  const [Departments, setDepartments] = useState([]);
  const [newDepartment, setNewDepartment] = useState({
    name: '',
    location: '',
  });
 const [updateDepartment, setUpdateDepartment] = useState({
    id: null,
    name: '',
    location: '',
  });
  useEffect(() => {
    // Function to fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5004/api/departments/');
        const data = await response.json();
        setDepartments(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    // Call the function to fetch data when the component mounts
    fetchData();
  }, []);

  const handleDelete = async (DepartmentId) => {
    try {
      // Make the DELETE request to delete the Department
      const response = await fetch(`http://localhost:5004/api/Departments/${DepartmentId}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        // If the request is successful, update the Departments state
        setDepartments(Departments.filter((Department) => Department.id !== DepartmentId));
      } else {
        console.error('Error deleting Department:', response.status);
      }
    } catch (error) {
      console.error('Error deleting Department:', error);
    }
  };

  const handleInputChange = (e) => {
    // Update the newDepartment state when the input fields change
    setNewDepartment({
      ...newDepartment,
      [e.target.name]: e.target.value,
    });
  };

  const handleAddDepartment = async (e) => {
    e.preventDefault();

    try {
      // Make the POST request to add a new Department
      const response = await fetch('http://localhost:5004/api/Departments/', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newDepartment),
      });

      if (response.ok) {
        // If the request is successful, update the Departments state and reset the form
        setDepartments([...Departments, newDepartment]);
        setNewDepartment({
          name: '',
          location: '',
        });
      } else {
        console.error('Error adding Department:', response.status);
      }
    } catch (error) {
      console.error('Error adding Department:', error);
    }
  };
  const handleUpdate = (DepartmentId) => {
    // Find the Department to update
    const DepartmentToUpdate = Departments.find((Department) => Department.id === DepartmentId);

    // Set the updateDepartment state with the current Department data
    setUpdateDepartment({
      id: DepartmentToUpdate.id,
      name: DepartmentToUpdate.name,
      location: DepartmentToUpdate.location,
    });
  };

  const handleUpdateDepartment = async (e) => {
    e.preventDefault();
    try {
      // Make the PUT request to update the Department
      const response = await fetch(`http://localhost:5004/api/Departments/${updateDepartment.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateDepartment),
      });

      if (response.ok) {
        // If the request is successful, update the Departments state and reset the form
        setDepartments(Departments.map((Department) => (Department.id === updateDepartment.id ? updateDepartment : Department)));
        setUpdateDepartment({
          id: null,
          name: '',
          location: '',
        });
      } else {
        console.error('Error updating Department:', response.status);
      }
    } catch (error) {
      console.error('Error updating Department:1', error);
    }
  };

  return (
    <div>
      <MyNavbar />
      <DepartmentTable id="Departments" Departments={Departments} onDelete={handleDelete} onUpdate={handleUpdate} />
      <Container>
        <Row>
          <Col>
            <h2 class="input-header">Add Department</h2>
            < AddDepartmentForm
              newDepartment={newDepartment} 
              handleInputChange={handleInputChange} 
              handleAddDepartment={handleAddDepartment}/>
          </Col>
          <Col>
            <h2 class="input-header">Update Department</h2>
            <UpdateDepartmentForm
              updateDepartment={updateDepartment}
              handleUpdateDepartment={handleUpdateDepartment}
              setUpdateDepartment={setUpdateDepartment}
            />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default DepartmentsPage;
