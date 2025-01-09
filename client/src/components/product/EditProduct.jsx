import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { editProduct, getProductById } from "../../managers/productManager";

export const EditProduct = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState({
    name: "",
    price: 0,
  });
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getProductById(id).then(setProduct);
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();

    editProduct(id, product).then((res) => {
      if (res.errors) {
        setErrors(res.errors);
      } else {
        navigate("/products");
      }
    });
  };
  return (
    <>
      <h2>Edit Product</h2>
      <form onSubmit={handleSubmit}>
        <FormGroup>
          <Label>Name</Label>
          <Input
            type="text"
            value={product.name}
            onChange={(e) => {
              const productCopy = { ...product };
              productCopy.name = e.target.value;
              setProduct(productCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Price</Label>
          <Input
            type="text"
            value={product.price}
            onChange={(e) => {
              const productCopy = { ...product };
              productCopy.price = e.target.value;
              setProduct(productCopy);
            }}
          />
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
