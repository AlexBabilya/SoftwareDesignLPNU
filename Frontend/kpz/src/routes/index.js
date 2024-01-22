import React from "react";

import AuthorsPage from "../pages/AuthorsPage";
import HomePage from "../pages/HomePage";
import BooksPage from "../pages/BooksPage";
import EmployeesPage from "../pages/EmployeesPage";
import PublishersPage from "../pages/PublishersPage";
import DepartmentsPage from "../pages/DepartmentsPage";

const routes = [
  {
    path: '/',
    element: <HomePage />,
  },
  {
    path: '/authors',
    element: <AuthorsPage />,
  },
  {
    path: '/books',
    element: <BooksPage />,
  },
  {
    path: '/employees',
    element: <EmployeesPage />,
  },
  {
    path: '/publishers',
    element: <PublishersPage />,
  },
  {
    path: '/departments',
    element: <DepartmentsPage />,
  },
];

export default routes;
