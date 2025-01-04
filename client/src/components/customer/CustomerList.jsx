import { useEffect, useState } from "react";
import { deleteCustomer, getCustomers } from "../../managers/customerManager";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";

export const CustomerList = () => {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    getCustomers().then(setCustomers);
  }, []);

  const handleDelete = (id) => {
    deleteCustomer(id).then(() => {
      getCustomers().then(setCustomers);
    });
  };

  return (
    <>
      <h2>Customers</h2>
      <Link to="add-customer">Add Customer</Link>
      <Table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Address</th>
            <th>Email</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {customers.map((c) => (
            <tr key={c.id}>
              <th scope="row">{`${c.name}`}</th>
              <td>{c.address}</td>
              <td>{c.email}</td>
              <td>
                <Link to={`${c.id}`}>Details</Link>
              </td>
              <td>
                <Button onClick={() => handleDelete(c.id)} color="danger">
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
