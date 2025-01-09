import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { Table, Spinner, Button, Container, Row, Col } from "reactstrap";
import { getProductById } from "../../managers/productManager";

export const ProductDetails = () => {
  const [product, setProduct] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    getProductById(id).then(setProduct);
  }, [id]);

  if (!product) {
    return (
      <div className="text-center mt-5">
        <Spinner color="primary" />
        <p>Loading product details...</p>
      </div>
    );
  }

  return (
    <Container className="mt-5">
      <Row>
        <Col>
          <h2>{product.name}</h2>
          <Link to="edit">
            <Button color="primary" className="mb-3">
              Edit Product
            </Button>
          </Link>
          <Table bordered>
            <tbody>
              <tr>
                <th>Price</th>
                <td>${product.price}</td>
              </tr>
              <tr>
                <th>Description</th>
                <td>{product.description}</td>
              </tr>
              <tr>
                <th>Category</th>
                <td>{product.category}</td>
              </tr>
              <tr>
                <th>Stock</th>
                <td>{product.stock}</td>
              </tr>
            </tbody>
          </Table>
        </Col>
      </Row>

      {/* Optional section for purchases or related data */}
      {/* You can add another section if needed, like how purchases relate to the product */}
      <Row className="mt-4">
        <Col>
          <h3>Purchase History</h3>
          {/* You can implement a similar table or remove this if not needed */}
        </Col>
      </Row>
    </Container>
  );
};
