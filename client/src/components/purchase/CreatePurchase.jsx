import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import {
  FormGroup,
  Label,
  Input,
  Button,
  Row,
  Col,
  Card,
  CardBody,
  Container,
} from "reactstrap";
import { getProducts } from "../../managers/productManager";
import { getCustomers } from "../../managers/customerManager";
import { createPurchase } from "../../managers/purchaseManager";

export const CreatePurchase = ({ loggedInUser }) => {
  const navigate = useNavigate();
  const [products, setProducts] = useState([]);
  const [customers, setCustomers] = useState([]);
  const [newPurchase, setNewPurchase] = useState({
    customerId: 0,
    employeeId: loggedInUser.id,
    purchaseProducts: [],
  });
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getProducts().then(setProducts);
    getCustomers().then(setCustomers);
  }, []);

  const handleAddProduct = () => {
    setNewPurchase((prevState) => ({
      ...prevState,
      purchaseProducts: [
        ...prevState.purchaseProducts,
        { productId: 0, quantity: 1 },
      ],
    }));
  };

  const handleProductChange = (index, e) => {
    const updatedPurchaseProducts = [...newPurchase.purchaseProducts];
    updatedPurchaseProducts[index][e.target.name] = parseInt(e.target.value);
    setNewPurchase({
      ...newPurchase,
      purchaseProducts: updatedPurchaseProducts,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    createPurchase(newPurchase).then((res) => {
      if (res.errors) {
        setErrors(res.errors);
      } else {
        navigate("/purchases");
      }
    });
  };

  return (
    <Container className="mt-5">
      <Card>
        <CardBody>
          <h2 className="fw-bold mb-4">New Purchase</h2>
          <form onSubmit={handleSubmit}>
            <Row className="mb-4">
              <Col md={12}>
                {" "}
                {/* Changed from md={6} to md={8} */}
                <FormGroup>
                  <Label for="customer">Customer</Label>
                  <Input
                    id="customer"
                    type="select"
                    value={newPurchase.customerId}
                    onChange={(e) =>
                      setNewPurchase({
                        ...newPurchase,
                        customerId: parseInt(e.target.value),
                      })
                    }
                  >
                    <option value={0}>Choose a Customer</option>
                    {customers.map((c) => (
                      <option key={c.id} value={c.id}>
                        {c.name}
                      </option>
                    ))}
                  </Input>
                </FormGroup>
              </Col>
            </Row>

            {newPurchase.purchaseProducts.map((productPurchase, index) => (
              <Row key={index} className="mb-4">
                <Col md={6}>
                  <FormGroup>
                    <Label for={`product-${index}`}>Product</Label>
                    <Input
                      id={`product-${index}`}
                      type="select"
                      name="productId"
                      value={productPurchase.productId}
                      onChange={(e) => handleProductChange(index, e)}
                    >
                      <option value={0}>Choose a Product</option>
                      {products.map((p) => (
                        <option key={p.id} value={p.id}>
                          {p.name}
                        </option>
                      ))}
                    </Input>
                  </FormGroup>
                </Col>
                <Col md={4}>
                  <FormGroup>
                    <Label for={`quantity-${index}`}>Quantity</Label>
                    <Input
                      id={`quantity-${index}`}
                      type="number"
                      name="quantity"
                      value={productPurchase.quantity}
                      onChange={(e) => handleProductChange(index, e)}
                      min="1"
                    />
                  </FormGroup>
                </Col>
              </Row>
            ))}

            <div className="d-flex mb-4">
              <Button
                type="button"
                color="secondary"
                onClick={handleAddProduct}
                className="me-3"
              >
                + Add Product
              </Button>
              <Button type="submit" color="primary">
                Submit
              </Button>
            </div>

            {errors && (
              <div style={{ color: "red" }}>
                {Object.keys(errors).map((key) => (
                  <p key={key}>
                    {key}: {errors[key].join(",")}
                  </p>
                ))}
              </div>
            )}
          </form>
        </CardBody>
      </Card>
    </Container>
  );
};
