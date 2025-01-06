import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { Table, Spinner, Container, Row, Col } from "reactstrap";
import { getEmployeeById } from "../../managers/employeeManager";

export const EmployeeDetails = () => {
  const [employee, setEmployee] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    getEmployeeById(id).then(setEmployee);
  }, [id]);

  if (!employee) {
    return (
      <div className="text-center mt-5">
        <Spinner color="primary" />
        <p>Loading employee details...</p>
      </div>
    );
  }

  return (
    <Container className="mt-5">
      <Row>
        <Col>
          <h2>{employee.name}</h2>
          <Link to="edit">Edit Employee</Link>
          <Table bordered>
            <tbody>
              <tr>
                <th>Email</th>
                <td>{employee.email}</td>
              </tr>
              <tr>
                <th>Address</th>
                <td>{employee.address}</td>
              </tr>
            </tbody>
          </Table>
        </Col>
      </Row>

      <Row className="mt-4">
        <Col>
          <h3>Purchases</h3>
          {employee.purchases.length > 0 ? (
            <Table striped>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Purchase Date</th>
                  <th>Employee ID</th>
                  <th>Products</th>
                </tr>
              </thead>
              <tbody>
                {employee.purchases.map((purchase, index) => (
                  <tr key={purchase.id}>
                    <th scope="row">{index + 1}</th>
                    <td>
                      {new Date(purchase.purchaseDate).toLocaleDateString()}
                    </td>
                    <td>{purchase.employeeId}</td>
                    <td>
                      <ul>
                        {purchase.purchaseProducts.map((product) => (
                          <li key={product.id}>
                            Product ID: {product.productId}, Quantity:{" "}
                            {product.quantity}
                          </li>
                        ))}
                      </ul>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          ) : (
            <p>No purchases found.</p>
          )}
        </Col>
      </Row>
    </Container>
  );
};
