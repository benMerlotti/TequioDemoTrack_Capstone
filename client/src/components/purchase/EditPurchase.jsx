import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { editPurchase, getPurchaseById } from "../../managers/purchaseManager";

export const EditPurchase = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [purchaseProducts, setPurchaseProducts] = useState([]);
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getPurchaseById(id).then((purchase) =>
      setPurchaseProducts(purchase.purchaseProducts)
    );
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();

    editPurchase(id, purchaseProducts).then((res) => {
      if (res.errors) {
        setErrors(res.errors);
      } else {
        navigate("/purchases");
      }
    });
  };

  return (
    <>
      <h2>Edit Purchase</h2>
      <form onSubmit={handleSubmit}>
        {purchaseProducts.map((product, index) => (
          <div key={product.productId}>
            <FormGroup>
              <Label>Product ID</Label>
              <Input type="text" value={product.productId} disabled />
            </FormGroup>
            <FormGroup>
              <Label>Quantity</Label>
              <Input
                type="number"
                value={product.quantity}
                onChange={(e) => {
                  const updatedProducts = [...purchaseProducts];
                  updatedProducts[index].quantity = parseFloat(e.target.value);
                  setPurchaseProducts(updatedProducts);
                }}
              />
            </FormGroup>
          </div>
        ))}
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
