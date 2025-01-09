import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Table, Button, Row, Col, Card, CardBody, Container } from "reactstrap";
import { getPurchases } from "../../managers/purchaseManager";

export const PurchaseList = () => {
  const [purchases, setPurchases] = useState([]);

  useEffect(() => {
    getPurchases().then(setPurchases);
  }, []);

  return (
    <Container className="mt-5">
      <Card>
        <CardBody>
          <Row className="mb-4">
            <Col>
              <h2 className="fw-bold">Purchases</h2>
              <p className="text-muted">
                View all purchase records. You can add new purchases or check
                details for each transaction.
              </p>
            </Col>
            <Col className="text-end">
              <Link to="/new-purchase">
                <Button color="primary" className="px-4">
                  + New Purchase
                </Button>
              </Link>
            </Col>
          </Row>
          <Table hover responsive bordered>
            <thead className="table-light">
              <tr>
                <th>Id</th>
                <th>Buyer</th>
                <th>Price</th>
                <th>Date</th>
                <th className="text-center">Actions</th>
              </tr>
            </thead>
            <tbody>
              {purchases.map((p) => (
                <tr key={p.id}>
                  <td>{p.id}</td>
                  <td>
                    <Link to={`/customers/${p.customer?.id}`}>
                      {p.customer?.name}
                    </Link>
                  </td>
                  <td>${p.totalPrice.toFixed(2)}</td>
                  <td>{new Date(p.purchaseDate).toLocaleDateString()}</td>
                  <td className="text-center">
                    <Link to={`${p.id}`}>
                      <Button color="secondary" size="sm" className="me-2">
                        Details
                      </Button>
                    </Link>
                    <Button color="danger" size="sm">
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
