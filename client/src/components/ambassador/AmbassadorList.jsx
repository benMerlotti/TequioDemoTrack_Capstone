import { useEffect, useState } from "react";
import { deleteEmployee, getEmployees } from "../../managers/abassadorManager";
import { Link } from "react-router-dom";
import { Button, Table, Row, Col, Card, CardBody, Container } from "reactstrap";

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
      <Card className="p-1">
        <CardBody className="mx-0">
          <Row className="mb-4">
            <Col>
              <h2 className="fw-bold">Ambassadors</h2>
              <p className="text-muted">
                View and manage your ambassadors. Add new ambassadors or view
                details below.
              </p>
            </Col>
            <Col className="text-end">
              <Link to="add-employee">
                <Button color="primary" className="px-4">
                  + Add Ambassador
                </Button>
              </Link>
            </Col>
          </Row>
          <Table
            hover
            responsive
            bordered
            style={{ tableLayout: "fixed", width: "100%" }}
          >
            <thead className="table-light">
              <tr>
                <th className="col-7 col-md-2">Name</th>
                <th className="d-none d-md-table-cell">Address</th>
                <th className="d-none d-md-table-cell">Email</th>
                <th colSpan="2" className="text-center col-5 col-md-3">
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>
              {employees.map((e) => (
                <tr key={e.id}>
                  <td className="col-7 col-md-2">
                    {e.firstName} {e.lastName}
                  </td>
                  <td className="d-none d-md-table-cell">{e.address}</td>
                  <td className="d-none d-md-table-cell">
                    {e.identityUser?.email}
                  </td>
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
          </Table>
        </CardBody>
      </Card>
    </Container>
  );
};
