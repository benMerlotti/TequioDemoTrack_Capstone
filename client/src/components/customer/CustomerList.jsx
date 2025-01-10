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

export const CustomerList = () => {
  const [customers, setCustomers] = useState([]);
  const [filteredCustomers, setFilteredCustomers] = useState([]);
  const [searchTerm, setSearchTerm] = useState(""); // Step 1: Track search term

  useEffect(() => {
    getCustomers().then((data) => {
      setCustomers(data);
      setFilteredCustomers(data); // Initially display all customers
    });
  }, []);

  // Handle the search functionality
  const handleSearch = (event) => {
    const term = event.target.value;
    setSearchTerm(term);

    // Filter customers based on name matching the search term
    const filtered = customers.filter((customer) =>
      customer.name.toLowerCase().includes(term.toLowerCase())
    );
    setFilteredCustomers(filtered); // Step 2: Update filtered list
  };

  const handleDelete = (id) => {
    deleteCustomer(id).then(() => {
      getCustomers().then((data) => {
        setCustomers(data);
        setFilteredCustomers(data); // Reapply search filter after deletion if needed
      });
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
          {/* Step 3: Input field for search */}
          <FormGroup>
            <Input
              type="text"
              placeholder="Search Customers"
              value={searchTerm}
              onChange={handleSearch} // Step 4: Call handleSearch on change
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
                  <th>Name</th>
                  <th>Address</th>
                  <th>Email</th>
                  <th
                    colSpan="2"
                    className="text-center"
                    style={{ width: "150px" }}
                  >
                    Actions
                  </th>
                </tr>
              </thead>
              <tbody>
                {filteredCustomers.map((c) => (
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
          </div>
        </CardBody>
      </Card>
    </Container>
  );
};
