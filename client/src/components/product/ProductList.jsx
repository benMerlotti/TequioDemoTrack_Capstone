import { useEffect, useState } from "react";
import { deleteProduct, getProducts } from "../../managers/productManager";
import { Link } from "react-router-dom";
import { Button, Table } from "reactstrap";

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
    <>
      <h2>Products</h2>
      <Link to="add-product">Add Product</Link>
      <Table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {products.map((p) => (
            <tr key={p.id}>
              <th scope="row">{`${p.id}`}</th>
              <td>{p.name}</td>
              <td>
                <Link to={`${p.id}`}>Details</Link>
              </td>
              <td>
                <Button onClick={() => handleDelete(p.id)} color="danger">
                  Delete
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
