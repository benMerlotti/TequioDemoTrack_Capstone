import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { createPurchase } from "../../managers/purchaseManager";
import { getProducts } from "../../managers/productManager";
import { getCustomers } from "../../managers/customerManager";

export const CreatePurchase = () => {
  const navigate = useNavigate();
  const [products, setProducts] = useState([]);
  const [customers, setCustomers] = useState([]);
  const [newPurchase, setNewPurchase] = useState({
    customerId: 0,
    productId: 0,
    employeeId: 0,
    purchaseDate: "",
  });
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getProducts().then(setProducts);
  }, []);

  useEffect(() => {
    getCustomers().then(setCustomers);
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    createPurchase(newPurchase).then((res) => {
      if (res.errors) {
        setErrors(res.errors);
      } else {
        navigate("/chores");
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
              purchaseCopy.customerId = e.target.value;
              setNewPurchase(purchaseCopy);
            }}
          >
            <option value={0}>Choose a Customer</option>
            {customers.map((c) => (
              <option key={c} value={c.id}>{`${c.name}`}</option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Product</Label>
          <Input
            type="select"
            value={newPurchase.productId}
            onChange={(e) => {
              const purchaseCopy = { ...newPurchase };
              purchaseCopy.productId = parseInt(e.target.value);
              setNewPurchase(purchaseCopy);
            }}
          >
            <option value={0}>Choose a Product</option>
            {products.map((p) => (
              <option key={p} value={p.id}>{`${p.name}`}</option>
            ))}
          </Input>
        </FormGroup>
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
