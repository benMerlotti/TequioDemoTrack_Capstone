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

export const PurchaseList = () => {
  const [purchases, setPurchases] = useState([]);
  const [filteredByDate, setFilteredByDate] = useState([]);
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");

  useEffect(() => {
    getPurchases().then((data) => {
      setPurchases(data);
      setFilteredByDate(data);
    });
  }, []);

  const handleDelete = (id) => {
    deletePurchase(id).then(() => {
      getPurchases().then((data) => {
        setPurchases(data);
        setFilteredByDate(data);
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
      <Card>
        <CardBody>
          <Row className="mb-4">
            <Col>
              <h2 className="fw-bold">Purchases</h2>
              <p className="text-muted">
                View all purchase records. You can add new purchases or check
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
          <table style={{ tableLayout: "fixed", width: "100%" }}>
            <thead>
              <tr>
                <th style={{ width: "100px" }}>Id</th>
                <th>Buyer</th>
                <th>Price</th>
                <th>Date</th>
                <th
                  colSpan="2"
                  className="text-center"
                  style={{ width: "150px" }}
                >
                  Actions
                </th>
              </tr>
            </thead>
          </table>
          <div
            style={{ maxHeight: "400px", overflowY: "auto" }}
            className="mt-1"
          >
            <table style={{ tableLayout: "fixed", width: "100%" }}>
              <thead>
                <tr>
                  <th style={{ width: "100px" }}></th>
                  <th></th>
                  <th></th>
                  <th></th>
                  <th
                    colSpan="2"
                    className="text-center"
                    style={{ width: "150px" }}
                  ></th>
                </tr>
              </thead>
              <tbody>
                {filteredByDate.map((p) => (
                  <tr key={p.id}>
                    <td>{p.id}</td>
                    <td>
                      <Link to={`/customers/${p.customer?.id}`}>
                        {p.customer?.name}
                      </Link>
                    </td>
                    <td>${p.totalPrice.toFixed(2)}</td>
                    <td>{new Date(p.purchaseDate).toLocaleDateString()}</td>
                    <td className="text-center">
                      <Link to={`${p.id}`}>
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
            </table>
          </div>
        </CardBody>
      </Card>
    </Container>
  );
};
