import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Table } from "reactstrap";
import { getPurchases } from "../../managers/purchaseManager";

export const PurchaseList = () => {
  const [purchases, setPurchases] = useState([]);

  useEffect(() => {
    getPurchases().then(setPurchases);
  }, []);
  return (
    <>
      <h2>Purchases</h2>
      <Link to="add-purchase">New Purchase</Link>
      <Table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Buyer</th>
            <th>Product</th>
            <th>Price</th>
            <th>Date</th>
          </tr>
        </thead>
        <tbody>
          {purchases.map((p) => (
            <tr key={p.id}>
              <th scope="row">{`${p.id}`}</th>
              <td>{p.customer?.name}</td>
              <td>{p.product?.name}</td>
              <td>$$$</td>
              <td>{p.purchaseDate}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
