import { useEffect, useState } from "react";
import { deleteCustomer, getCustomers } from "../../managers/customerManager";
import { Button, Table, Row, Col, Card, CardBody, Container } from "reactstrap";
import { Link } from "react-router-dom";

export const CustomerList = () => {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    getCustomers().then(setCustomers);
  }, []);

  const handleDelete = (id) => {
    deleteCustomer(id).then(() => {
      getCustomers().then(setCustomers);
    });
  };

  return (
    <Container className="mt-5">
      <Card>
        <CardBody>
          <Row className="mb-4">
            <Col>
              <h2 className="fw-bold">Customers</h2>
              <p className="text-muted">
                Manage your customer information. Add, view, or delete customers
                below.
              </p>
            </Col>
            <Col className="text-end">
              <Link to="add-customer">
                <Button color="primary" className="px-4">
                  + Add Customer
                </Button>
              </Link>
            </Col>
          </Row>
          <Table hover responsive bordered>
            <thead className="table-light">
              <tr>
                <th>Name</th>
                <th>Address</th>
                <th>Email</th>
                <th colSpan="2" className="text-center">
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>
              {customers.map((c) => (
                <tr key={c.id}>
                  <td>{c.name}</td>
                  <td>{c.address}</td>
                  <td>{c.email}</td>
                  <td className="text-center">
                    <Link to={`${c.id}`}>
                      <Button color="secondary" size="sm">
                        Details
                      </Button>
                    </Link>
                  </td>
                  <td className="text-center">
                    <Button
                      color="danger"
                      size="sm"
                      onClick={() => handleDelete(c.id)}
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
