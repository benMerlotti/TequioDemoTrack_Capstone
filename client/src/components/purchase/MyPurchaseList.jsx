/* eslint-disable react/prop-types */
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {
  Table,
  Button,
  Row,
  Col,
  Card,
  CardBody,
  Container,
  FormGroup,
  InputGroup,
  InputGroupText,
} from "reactstrap";
import { deletePurchase, getPurchases } from "../../managers/purchaseManager";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

export const MyPurchaseList = ({ loggedInUser }) => {
  const [purchases, setPurchases] = useState([]);
  const [filteredByDate, setFilteredByDate] = useState([]);
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");

  useEffect(() => {
    getPurchases().then((data) => {
      // Filter purchases based on the logged-in user's ID
      const userPurchases = data.filter(
        (purchase) => purchase.userProfileId === loggedInUser.id
      );
      setPurchases(userPurchases);
      setFilteredByDate(userPurchases);
    });
  }, [loggedInUser.id]);

  const handleDelete = (id) => {
    deletePurchase(id).then(() => {
      getPurchases().then((data) => {
        // Filter purchases again after deletion
        const userPurchases = data.filter(
          (purchase) => purchase.userProfile.Id === loggedInUser.id
        );
        setPurchases(userPurchases);
        setFilteredByDate(userPurchases);
      });
    });
  };

  const handleDateFilter = () => {
    if (startDate && endDate) {
      const filtered = purchases.filter((purchase) => {
        const purchaseDate = new Date(purchase.purchaseDate);
        const start = new Date(startDate);
        const end = new Date(endDate);
        return purchaseDate >= start && purchaseDate <= end;
      });
      setFilteredByDate(filtered);
    } else {
      setFilteredByDate(purchases);
    }
  };

  const handleClearFilter = () => {
    setStartDate("");
    setEndDate("");
    setFilteredByDate(purchases);
  };

  return (
    <Container className="mt-5">
      <Card className="p-1">
        <CardBody className="mx-0">
          <Row className="mb-4">
            <Col>
              <h2 className="fw-bold">Your Purchases</h2>
              <p>
                View your purchase records. You can add new purchases or check
                details for each transaction.
              </p>
            </Col>
            <Col className="text-end">
              <Link to="/new-purchase">
                <Button color="primary" className="px-4">
                  + New Purchase
                </Button>
              </Link>
            </Col>
          </Row>
          <Row className="mb-4">
            <Col md="4">
              <FormGroup>
                <InputGroup>
                  <InputGroupText>Start</InputGroupText>
                  <DatePicker
                    selected={startDate}
                    onChange={(date) => setStartDate(date)}
                    placeholderText="Start Date"
                    dateFormat="yyyy-MM-dd"
                    className="form-control"
                  />
                </InputGroup>
              </FormGroup>
            </Col>
            <Col md="4">
              <FormGroup>
                <InputGroup>
                  <InputGroupText>End</InputGroupText>
                  <DatePicker
                    selected={endDate}
                    onChange={(date) => setEndDate(date)}
                    placeholderText="End Date"
                    dateFormat="yyyy-MM-dd"
                    className="form-control"
                  />
                </InputGroup>
              </FormGroup>
            </Col>
            <Col md="4">
              <Button
                color="primary"
                className="me-3"
                onClick={handleDateFilter}
              >
                Filter
              </Button>
              <Button color="secondary" onClick={handleClearFilter}>
                Clear Filter
              </Button>
            </Col>
          </Row>
          <div style={{ maxHeight: "400px", overflowY: "auto" }}>
            <Table
              hover
              responsive
              bordered
              style={{ tableLayout: "fixed", width: "100%" }}
            >
              <thead className="table-light">
                <tr>
                  <th className="col-2 col-md-1">Id</th>
                  <th className="d-none d-md-table-cell">Buyer</th>
                  <th className="d-none d-md-table-cell">Price</th>
                  <th>Date</th>
                  <th colSpan="2" className="text-center col-5 col-md-2">
                    Actions
                  </th>
                </tr>
              </thead>
              <tbody>
                {filteredByDate.map((p) => (
                  <tr key={p.id}>
                    <td className="col-2 col-md-1">{p.id}</td>
                    <td className="d-none d-md-table-cell">
                      <Link to={`/customers/${p.customer?.id}`}>
                        {p.customer?.name}
                      </Link>
                    </td>
                    <td className="d-none d-md-table-cell">
                      ${p.totalPrice.toFixed(2)}
                    </td>
                    <td>{new Date(p.purchaseDate).toLocaleDateString()}</td>
                    <td className="text-center">
                      <Link to={`/purchases/${p.id}`}>
                        <Button color="secondary" size="sm">
                          Details
                        </Button>
                      </Link>
                    </td>
                    <td className="text-center">
                      <Button
                        onClick={() => handleDelete(p.id)}
                        color="danger"
                        size="sm"
                      >
                        Delete
                      </Button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        </CardBody>
      </Card>
    </Container>
  );
};
