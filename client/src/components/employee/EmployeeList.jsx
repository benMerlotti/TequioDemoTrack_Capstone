import { useEffect, useState } from "react";
import { deleteEmployee, getEmployees } from "../../managers/employeeManager";
import { Link } from "react-router-dom";
import { Button, Row, Col, Card, CardBody, Container } from "reactstrap";

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
    <Container className="mt-5">
      <Card>
        <CardBody>
          <Row className="mb-4">
            <Col>
              <h2 className="fw-bold">Employees</h2>
              <p className="text-muted">
                View and manage your employees. Add new employees or view
                details below.
              </p>
            </Col>
            <Col className="text-end">
              <Link to="add-employee">
                <Button color="primary" className="px-4">
                  + Add Employee
                </Button>
              </Link>
            </Col>
          </Row>
          <table style={{ tableLayout: "fixed", width: "100%" }}>
            <thead>
              <tr>
                <th style={{ width: "200px" }}>Name</th>
                <th>Address</th>
                <th>Email</th>
                <th
                  colSpan="2"
                  className="text-center"
                  style={{ width: "200px" }}
                >
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>
              {employees.map((e) => (
                <tr key={e.id}>
                  <td>{e.name}</td>
                  <td>{e.address}</td>
                  <td>{e.email}</td>
                  <td className="text-center">
                    <Link to={`${e.id}`}>
                      <Button color="secondary" size="sm">
                        Details
                      </Button>
                    </Link>
                  </td>
                  <td className="text-center">
                    <Button
                      color="danger"
                      size="sm"
                      onClick={() => handleDelete(e.id)}
                    >
                      Delete
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </CardBody>
      </Card>
    </Container>
  );
};
