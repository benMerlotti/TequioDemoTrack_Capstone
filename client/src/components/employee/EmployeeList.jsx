import { useEffect, useState } from "react";
import { deleteEmployee, getEmployees } from "../../managers/employeeManager";
import { Link } from "react-router-dom";
import { Button, Table } from "reactstrap";

export const EmployeeList = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    getEmployees().then(setEmployees);
  }, []);

  const handleDelete = (id) => {
    deleteEmployee(id).then(() => {
      getEmployees().then(setEmployees);
    });
  };
  return (
    <>
      <h2>Employees</h2>
      <Link to="add-employee">Add Employee</Link>
      <Table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Address</th>
            <th>Email</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {employees.map((e) => (
            <tr key={e.id}>
              <th scope="row">{`${e.name}`}</th>
              <td>{e.address}</td>
              <td>{e.email}</td>
              <td>
                <Link to={`${e.id}`}>Details</Link>
              </td>
              <td>
                <Button onClick={() => handleDelete(e.id)} color="danger">
                  Delete
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
