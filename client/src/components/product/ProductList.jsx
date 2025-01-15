import { useEffect, useState } from "react";
import { deleteProduct, getProducts } from "../../managers/productManager";
import { Link } from "react-router-dom";
import { Button, Table, Row, Col, Card, CardBody, Container } from "reactstrap";

export const ProductList = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    getProducts().then(setProducts);
  }, []);

  const handleDelete = (id) => {
    deleteProduct(id).then(() => {
      getProducts().then(setProducts);
    });
  };

  return (
    <Container className="mt-5">
      <Card>
        <CardBody>
          <Row className="mb-4">
            <Col>
              <h2 className="fw-bold">Products</h2>
              <p className="text-muted">
                Manage your product inventory. Add new products or view product
                details below.
              </p>
            </Col>
            <Col className="text-end">
              <Link to="add-product">
                <Button color="primary" className="px-4">
                  + Add Product
                </Button>
              </Link>
            </Col>
          </Row>
          <Table hover responsive bordered>
            <thead className="table-light">
              <tr>
                <th className="text-center col-1 col-md-1">Id</th>
                <th className="text-center col-5 col-md-6">Name</th>
                <th colSpan="2" className="text-center col-1 col-md-2">
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>
              {products.map((p) => (
                <tr key={p.id}>
                  <td>{p.id}</td>
                  <td>{p.name}</td>
                  <td className="text-center">
                    <Link to={`${p.id}`}>
                      <Button color="secondary" size="sm">
                        Details
                      </Button>
                    </Link>
                  </td>
                  <td className="text-center">
                    <Button
                      color="danger"
                      size="sm"
                      onClick={() => handleDelete(p.id)}
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
