import { useState, useEffect } from "react";
import { Container, Row, Col, Card, CardBody } from "reactstrap";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Pie } from "react-chartjs-2"; // Using Chart.js for the charts

// Register the necessary components
ChartJS.register(ArcElement, Tooltip, Legend);

export const CustomerDemographics = () => {
  const [customerData, setCustomerData] = useState(null);

  useEffect(() => {
    // Simulating fetching demographic data (replace with real API call)
    setCustomerData({
      demographics: {
        age: [25, 35, 20, 15, 5], // Example data for age groups: 18-25, 26-35, 36-45, 46-60, 60+
        gender: [60, 40], // Example data for gender: 60% male, 40% female
        location: {
          "New York": 40, // 40% of customers from New York
          "Los Angeles": 30,
          Chicago: 20,
          Others: 10,
        },
      },
    });
  }, []);

  if (!customerData) return <p>Loading demographics...</p>;

  // Age Distribution Chart
  const ageChartData = {
    labels: ["18-25", "26-35", "36-45", "46-60", "60+"],
    datasets: [
      {
        data: customerData.demographics.age,
        backgroundColor: [
          "#FF5733",
          "#33FF57",
          "#5733FF",
          "#FFC300",
          "#FF33A8",
        ],
        hoverBackgroundColor: [
          "#FF5733",
          "#33FF57",
          "#5733FF",
          "#FFC300",
          "#FF33A8",
        ],
      },
    ],
  };

  // Gender Distribution Chart
  const genderChartData = {
    labels: ["Male", "Female"],
    datasets: [
      {
        data: customerData.demographics.gender,
        backgroundColor: ["#2E7D32", "#D32F2F"],
      },
    ],
  };

  return (
    <Container className="mt-5">
      <Row>
        <Col>
          <h2>Customer Demographics</h2>
          <p className="text-muted">
            Analyze your customers&apos; age, gender, and location distribution.
          </p>
        </Col>
      </Row>

      {/* Age Distribution */}
      <Row className="mb-4">
        <Col md="6" lg="12">
          <Card>
            <CardBody>
              <h5>Age Distribution</h5>
              <div style={{ position: "relative", height: "300px" }}>
                <Pie
                  data={ageChartData}
                  options={{
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                      legend: {
                        position: "top",
                      },
                    },
                  }}
                />
              </div>
            </CardBody>
          </Card>
        </Col>

        {/* Gender Distribution */}
        <Col md="6" lg="4">
          <Card>
            <CardBody>
              <h5>Gender Distribution</h5>
              <div style={{ position: "relative", height: "300px" }}>
                <Pie
                  data={genderChartData}
                  options={{
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                      legend: {
                        position: "top",
                      },
                    },
                  }}
                />
              </div>
            </CardBody>
          </Card>
        </Col>
      </Row>

      {/* Optional: Location Distribution (Can add a bar chart or list) */}
      <Row>
        <Col>
          <h5>Geographical Location</h5>
          <ul>
            {Object.entries(customerData.demographics.location).map(
              ([location, percentage], index) => (
                <li key={index}>
                  {location}: {percentage}%
                </li>
              )
            )}
          </ul>
        </Col>
      </Row>
    </Container>
  );
};
