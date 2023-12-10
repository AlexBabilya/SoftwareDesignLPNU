import React from "react";
import { Route, BrowserRouter, Routes } from "react-router-dom";

import AuthorsPage from "./Authors/AuthorsPage";
import HomePage from "./Home/HomePage";
import BooksPage from "./Books/BooksPage";
import EmployeesPage from "./Employees/EmployeesPage";
import PublishersPage from "./Publishers/PublishersPage";
import DepartmentsPage from "./Departments/DepartmentsPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route
          path="/"
          element={ <HomePage /> }
        />
        <Route
          path="/authors"
          element={ <AuthorsPage /> } 
        />
        <Route
          path="/books"
          element={ <BooksPage /> } 
        />
        <Route
          path="/employees"
          element={ <EmployeesPage /> } 
        />
        <Route
          path="/publishers"
          element={ <PublishersPage /> } 
        />
        <Route
          path="/departments"
          element={ <DepartmentsPage /> } 
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;