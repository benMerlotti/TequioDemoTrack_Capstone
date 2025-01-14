import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
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
import { getPurchaseById } from "../../managers/purchaseManager";

export const PurchaseDetails = () => {
  const [purchase, setPurchase] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    getPurchaseById(id).then(setPurchase);
  }, [id]);

  if (!purchase) {
    return (
      <div className="text-center mt-5">
        <Spinner color="primary" />
        <p>Loading purchase details...</p>
      </div>
    );
  }

  return (
    <Container className="mt-5">
      {/* Purchase Details Section */}
      <Row className="mb-4 justify-content-center">
        <Col xl={12}>
          <Card>
            <CardBody>
              <h2 className="mb-3">Purchase #{purchase.id}</h2>
              <Table bordered>
                <tbody>
                  <tr>
                    <th style={{ width: "200px" }}>Customer Name</th>
                    <td style={{ width: "400px" }}>{purchase.customer.name}</td>
                  </tr>
                  <tr>
                    <th>Email</th>
                    <td>{purchase.customer.email}</td>
                  </tr>
                  <tr>
                    <th>Address</th>
                    <td>{purchase.customer.address}</td>
                  </tr>
                  <tr>
                    <th>Employee</th>
                    <td>{purchase.employee.name}</td>
                  </tr>
                  <tr>
                    <th>Employee Email</th>
                    <td>{purchase.employee.email}</td>
                  </tr>
                  <tr>
                    <th>Total Price</th>
                    <td>${purchase.totalPrice}</td>
                  </tr>
                  <tr>
                    <th>Purchase Date</th>
                    <td>
                      {new Date(purchase.purchaseDate).toLocaleDateString()}
                    </td>
                  </tr>
                </tbody>
              </Table>
            </CardBody>
          </Card>
        </Col>
      </Row>

      {/* Products Section */}
      <Row className="justify-content-center">
        <Col xl={12}>
          <Card>
            <Link to="edit">
              <Button color="primary" className="mb-3">
                Edit Purchase
              </Button>
            </Link>
            <CardBody>
              <h3 className="mb-3">Products</h3>
              {purchase.purchaseProducts.length > 0 ? (
                <Table striped>
                  <thead>
                    <tr>
                      <th>#</th>
                      <th>Product Name</th>
                      <th>Price</th>
                      <th>Quantity</th>
                      <th>Total</th>
                    </tr>
                  </thead>
                  <tbody>
                    {purchase.purchaseProducts.map((product, index) => (
                      <tr key={product.id}>
                        <th scope="row">{index + 1}</th>
                        <td>{product.product.name}</td>
                        <td>${product.product.price}</td>
                        <td>{product.quantity}</td>
                        <td>${product.product.price * product.quantity}</td>
                      </tr>
                    ))}
                  </tbody>
                </Table>
              ) : (
                <p>No products found.</p>
              )}
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};
