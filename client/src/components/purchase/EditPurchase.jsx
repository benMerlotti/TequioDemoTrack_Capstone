import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { editPurchase, getPurchaseById } from "../../managers/purchaseManager";
import { getProducts } from "../../managers/productManager";

export const EditPurchase = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [purchaseProducts, setPurchaseProducts] = useState([]);
  const [allProducts, setAllProducts] = useState([]);
  const [errors, setErrors] = useState("");

  useEffect(() => {
    // Fetch the current purchase's products
    getPurchaseById(id).then((purchase) =>
      setPurchaseProducts(purchase.purchaseProducts)
    );

    // Fetch all available products for the dropdown
    getProducts().then((products) => setAllProducts(products));
  }, [id]);

  const handleProductChange = (index, selectedProductId) => {
    const updatedProducts = [...purchaseProducts];
    updatedProducts[index].productId = selectedProductId;
    setPurchaseProducts(updatedProducts);
  };

  const handleQuantityChange = (index, quantity) => {
    const updatedProducts = [...purchaseProducts];
    updatedProducts[index].quantity = parseFloat(quantity);
    setPurchaseProducts(updatedProducts);
  };

  const handleAddProduct = () => {
    setPurchaseProducts([
      ...purchaseProducts,
      { productId: "", quantity: 1 }, // Default values for new product
    ]);
  };

  const handleDeleteProduct = (index) => {
    const updatedProducts = purchaseProducts.filter((_, i) => i !== index);
    setPurchaseProducts(updatedProducts);
  };

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
          <div
            key={index} // Use index since productId might not be unique for new entries
            className="d-flex align-items-center mb-3 justify-content-between"
          >
            <div className="d-flex align-items-center">
              <FormGroup className="me-3">
                <Label>Product</Label>
                <Input
                  type="select"
                  value={product.productId}
                  onChange={(e) => handleProductChange(index, e.target.value)}
                >
                  <option value="" disabled>
                    Select a product
                  </option>
                  {allProducts.map((p) => (
                    <option key={p.id} value={p.id}>
                      {p.name}
                    </option>
                  ))}
                </Input>
              </FormGroup>
              <FormGroup className="me-3">
                <Label>Quantity</Label>
                <Input
                  type="number"
                  min="1"
                  value={product.quantity}
                  onChange={(e) => handleQuantityChange(index, e.target.value)}
                />
              </FormGroup>
            </div>

            <Button color="danger" onClick={() => handleDeleteProduct(index)}>
              Delete
            </Button>
          </div>
        ))}

        <Button
          type="button"
          color="secondary"
          onClick={handleAddProduct}
          className="me-3"
        >
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
