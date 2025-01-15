import { useEffect, useState } from "react";
import { deleteCustomer, getCustomers } from "../../managers/customerManager";
import {
  Button,
  Table,
  Row,
  Col,
  Card,
  CardBody,
  Container,
  FormGroup,
  Input,
} from "reactstrap";
import { Link } from "react-router-dom";
import "../../assets/styles/customerList.css";

export const CustomerList = () => {
  const [customers, setCustomers] = useState([]);
  const [filteredCustomers, setFilteredCustomers] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    getCustomers().then((data) => {
      setCustomers(data);
      setFilteredCustomers(data);
    });
  }, []);

  const handleSearch = (event) => {
    const term = event.target.value;
    setSearchTerm(term);

    const filtered = customers.filter((customer) =>
      customer.name.toLowerCase().includes(term.toLowerCase())
    );
    setFilteredCustomers(filtered);
  };

  const handleDelete = (id) => {
    deleteCustomer(id).then(() => {
      getCustomers().then((data) => {
        setCustomers(data);
        setFilteredCustomers(data);
      });
    });
  };

  return (
    <Container className="mt-5">
      <Card className="p-1">
        <CardBody className="mx-0">
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
          <FormGroup>
            <Input
              type="text"
              placeholder="Search Customers"
              value={searchTerm}
              onChange={handleSearch}
            />
          </FormGroup>
          <div style={{ maxHeight: "400px", overflowY: "auto" }}>
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
                  <th colSpan="2" className="text-center col-5 col-md-2">
                    Actions
                  </th>
                </tr>
              </thead>
              <tbody>
                {filteredCustomers.map((c) => (
                  <tr key={c.id}>
                    <td className="col-7 col-md-2">{c.name}</td>
                    <td className="d-none d-md-table-cell">{c.address}</td>
                    <td className="d-none d-md-table-cell">{c.email}</td>
                    <td className="text-center col-5 col-md-4">
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
          </div>
        </CardBody>
      </Card>
    </Container>
  );
};
