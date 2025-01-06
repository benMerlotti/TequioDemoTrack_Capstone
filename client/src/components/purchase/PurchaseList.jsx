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
      <Link to="/new-purchase">New Purchase</Link>
      <Table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Buyer</th>
            <th>Price</th>
            <th>Date</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {purchases.map((p) => (
            <tr key={p.id}>
              <th scope="row">{`${p.id}`}</th>
              <td>{p.customer?.name}</td>
              <td>$$$</td>
              <td>{new Date(p.purchaseDate).toLocaleDateString()}</td>
              <td>
                <Link to={`${p.id}`}>Details</Link>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
