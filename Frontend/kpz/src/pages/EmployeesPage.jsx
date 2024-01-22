import React, { useEffect, useState } from 'react';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import EmployeeTable from '../components/Employees/EmployeeTable';
import AddEmployeeForm from '../components/Employees/AddEmployeeForm';
import UpdateEmployeeForm from '../components/Employees/UpdateEmployeeForm';
import MyNavbar from '../components/Navbar';

const apiUrl = process.env.REACT_APP_API_URL;

const EmployeesPage = () => {
  const [Employees, setEmployees] = useState([]);
  const [newEmployee, setNewEmployee] = useState({
    firstName: '',
    lastName: '',
    hireDate: '',
    salary: null,
    departmentID: null,
  });
 const [updateEmployee, setUpdateEmployee] = useState({
    id: null,
    firstName: '',
    lastName: '',
    hireDate: '',
    salary: null,
    departmentID: null,
  });
  useEffect(() => {
    // Function to fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await fetch(`${apiUrl}/Employees/`);
        const data = await response.json();
        setEmployees(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    // Call the function to fetch data when the component mounts
    fetchData();
  }, []);

  const handleDelete = async (EmployeeId) => {
    try {
      // Make the DELETE request to delete the Employee
      const response = await fetch(`${apiUrl}/Employees/${EmployeeId}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        // If the request is successful, update the Employees state
        setEmployees(Employees.filter((Employee) => Employee.id !== EmployeeId));
      } else {
        console.error('Error deleting Employee:', response.status);
      }
    } catch (error) {
      console.error('Error deleting Employee:', error);
    }
  };

  const handleInputChange = (e) => {
    // Update the newEmployee state when the input fields change
    setNewEmployee({
      ...newEmployee,
      [e.target.name]: e.target.value,
    });
  };

  const handleAddEmployee = async (e) => {
    e.preventDefault();

    try {
      // Make the POST request to add a new Employee
      const response = await fetch(`${apiUrl}/Employees/`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newEmployee),
      });

      if (response.ok) {
        // If the request is successful, update the Employees state and reset the form
        setEmployees([...Employees, newEmployee]);
        setNewEmployee({
          firstName: '',
          lastName: '',
          hireDate: '',
          salary: null,
          departmentID: null,
        });
      } else {
        console.error('Error adding Employee:', response.status);
      }
    } catch (error) {
      console.error('Error adding Employee:', error);
    }
  };
  const handleUpdate = (EmployeeId) => {
    // Find the Employee to update
    const EmployeeToUpdate = Employees.find((Employee) => Employee.id === EmployeeId);

    // Set the updateEmployee state with the current Employee data
    setUpdateEmployee({
      id: EmployeeToUpdate.id,
      firstName: EmployeeToUpdate.firstName,
      lastName: EmployeeToUpdate.lastName,
      hireDate: EmployeeToUpdate.hireDate,
      salary: EmployeeToUpdate.salary,
      departmentID: EmployeeToUpdate.departmentID,
    });
  };

  const handleUpdateEmployee = async (e) => {
    e.preventDefault();
    try {
      // Make the PUT request to update the Employee
      const response = await fetch(`${apiUrl}/Employees/${updateEmployee.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateEmployee),
      });

      if (response.ok) {
        // If the request is successful, update the Employees state and reset the form
        setEmployees(Employees.map((Employee) => (Employee.id === updateEmployee.id ? updateEmployee : Employee)));
        setUpdateEmployee({
          id: null,
          firstName: '',
          lastName: '',
          hireDate: '',
          salary: null,
          departmentID: null,
        });
      } else {
        console.error('Error updating Employee:', response.status);
      }
    } catch (error) {
      console.error('Error updating Employee:1', error);
    }
  };

  return (
    <div>
      <MyNavbar />
      <EmployeeTable id="Employees" employees={Employees} onDelete={handleDelete} onUpdate={handleUpdate} />
      <Container>
        <Row>
          <Col>
            <h2 className="input-header">Add Employee</h2>
            < AddEmployeeForm
              newEmployee={newEmployee} 
              handleInputChange={handleInputChange} 
              handleAddEmployee={handleAddEmployee}/>
            </Col>
          <Col>
            <h2 className="input-header">Update Employee</h2>
            <UpdateEmployeeForm
              updateEmployee={updateEmployee}
              handleUpdateEmployee={handleUpdateEmployee}
              setUpdateEmployee={setUpdateEmployee}
            />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default EmployeesPage;
