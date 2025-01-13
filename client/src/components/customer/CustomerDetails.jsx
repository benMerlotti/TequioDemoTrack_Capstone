import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { getCustomerById } from "../../managers/customerManager";
import {
  Table,
  Spinner,
  Container,
  Row,
  Col,
  Card,
  CardBody,
  Button,
} from "reactstrap";

export const CustomerDetails = () => {
  const [customer, setCustomer] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    getCustomerById(id).then(setCustomer);
  }, [id]);

  if (!customer) {
    return (
      <div className="text-center mt-5">
        <Spinner color="primary" />
        <p>Loading customer details...</p>
      </div>
    );
  }

  return (
    <Container className="mt-5">
      {/* Customer Details Section */}
      <Row className="mb-4 justify-content-center">
        <Col xl={12}>
          <Card>
            <CardBody>
              <h2 className="mb-3">{customer.name}</h2>
              <Link to="edit">
                <Button color="primary" className="mb-3">
                  Edit Customer
                </Button>
              </Link>
              <Table bordered>
                <tbody>
                  <tr>
                    <th>Email</th>
                    <td>{customer.email}</td>
                  </tr>
                  <tr>
                    <th>Address</th>
                    <td>{customer.address}</td>
                  </tr>
                  <tr>
                    <th>Age Group</th>
                    <td>{customer.ageGroup?.group}</td>
                  </tr>
                  <tr>
                    <th>Gender</th>
                    <td>{customer.gender?.genderValue}</td>
                  </tr>
                  <tr>
                    <th>Race</th>
                    <td>{customer.race?.raceValue}</td>
                  </tr>
                  <tr>
                    <th>Location</th>
                    <td>{customer.location?.locationValue}</td>
                  </tr>
                </tbody>
              </Table>
            </CardBody>
          </Card>
        </Col>
      </Row>

      {/* Purchases Section */}
      <Row className="justify-content-center">
        <Col xl={12}>
          <Card>
            <CardBody>
              <h3 className="mb-3">Purchases</h3>
              {customer.purchases.length > 0 ? (
                <Table striped>
                  <thead>
                    <tr>
                      <th>#</th>
                      <th>Purchase Date</th>
                      <th>Employee ID</th>
                      <th>Products</th>
                    </tr>
                  </thead>
                  <tbody>
                    {customer.purchases.map((purchase, index) => (
                      <tr key={purchase.id}>
                        <th scope="row">{index + 1}</th>
                        <td>
                          {new Date(purchase.purchaseDate).toLocaleDateString()}
                        </td>
                        <td>{purchase.employeeId}</td>
                        <td>
                          <ul>
                            {purchase.purchaseProducts.map((product) => (
                              <li key={product.id}>
                                Product ID: {product.productId}, Quantity:{" "}
                                {product.quantity}
                              </li>
                            ))}
                          </ul>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </Table>
              ) : (
                <p>No purchases found.</p>
              )}
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};
