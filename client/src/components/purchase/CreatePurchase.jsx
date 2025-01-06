import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { FormGroup, Label, Input, Button } from "reactstrap";
import { getProducts } from "../../managers/productManager";
import { getCustomers } from "../../managers/customerManager";
import { createPurchase } from "../../managers/purchaseManager";

// eslint-disable-next-line react/prop-types
export const CreatePurchase = ({ loggedInUser }) => {
  const navigate = useNavigate();
  const [products, setProducts] = useState([]);
  const [customers, setCustomers] = useState([]);
  const [newPurchase, setNewPurchase] = useState({
    customerId: 0,
    // eslint-disable-next-line react/prop-types
    employeeId: loggedInUser.id,
    purchaseProducts: [], // To store products and quantities
  });
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getProducts().then(setProducts);
  }, []);

  useEffect(() => {
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
    <>
      <h2>New Purchase</h2>
      <form onSubmit={handleSubmit}>
        <FormGroup>
          <Label>Customer</Label>
          <Input
            type="select"
            value={newPurchase.customerId}
            onChange={(e) => {
              const purchaseCopy = { ...newPurchase };
              purchaseCopy.customerId = parseInt(e.target.value);
              setNewPurchase(purchaseCopy);
            }}
          >
            <option value={0}>Choose a Customer</option>
            {customers.map((c) => (
              <option key={c.id} value={c.id}>{`${c.name}`}</option>
            ))}
          </Input>
        </FormGroup>

        {newPurchase.purchaseProducts.map((productPurchase, index) => (
          <div key={index}>
            <FormGroup>
              <Label>Product</Label>
              <Input
                type="select"
                name="productId"
                value={productPurchase.productId}
                onChange={(e) => handleProductChange(index, e)}
              >
                <option value={0}>Choose a Product</option>
                {products.map((p) => (
                  <option key={p.id} value={p.id}>{`${p.name}`}</option>
                ))}
              </Input>
            </FormGroup>

            <FormGroup>
              <Label>Quantity</Label>
              <Input
                type="number"
                name="quantity"
                value={productPurchase.quantity}
                onChange={(e) => handleProductChange(index, e)}
                min="1"
              />
            </FormGroup>
          </div>
        ))}

        <Button type="button" color="secondary" onClick={handleAddProduct}>
          Add Product
        </Button>

        <Button type="submit" color="primary">
          Submit
        </Button>

        <div style={{ color: "red" }}>
          {Object.keys(errors).map((key) => (
            <p key={key}>
              {key}: {errors[key].join(",")}
            </p>
          ))}
        </div>
      </form>
    </>
  );
};
