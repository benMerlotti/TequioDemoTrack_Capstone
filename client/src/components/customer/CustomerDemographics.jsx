import React from "react";
import { Doughnut, Bar } from "react-chartjs-2";
import {
  Chart as ChartJS,
  ArcElement,
  Legend,
  Tooltip,
  CategoryScale,
  LinearScale,
  BarElement,
} from "chart.js";

ChartJS.register(
  ArcElement,
  Legend,
  Tooltip,
  CategoryScale,
  LinearScale,
  BarElement
);

export const CustomerDemographics = () => {
  // Data for Doughnut Chart
  const genderData = {
    labels: ["Male", "Female", "Other"],
    datasets: [
      {
        label: "Customer Demographics",
        data: [45, 50, 5], // Example data
        backgroundColor: ["blue", "pink", "gray"], // Colors for the segments
        borderColor: ["#000", "#000", "#000"], // Optional: border for segments
        borderWidth: 1, // Optional: width of the border
      },
    ],
  };

  const genderOptions = {
    responsive: true,
    plugins: {
      legend: {
        display: true,
        position: "right", // Position of the legend
      },
    },
  };

  // Data for Bar Chart
  const ageData = {
    labels: ["18-24", "25-34", "35-44", "45-54", "55+"],
    datasets: [
      {
        label: "Customer Age Groups",
        data: [30, 50, 40, 20, 10], // Example data
        backgroundColor: "rgba(75, 192, 192, 0.6)", // Bars color
        borderColor: "rgba(75, 192, 192, 1)",
        borderWidth: 1,
      },
    ],
  };

  const ageOptions = {
    responsive: true,
    plugins: {
      legend: {
        display: false, // Hide legend for bar chart
      },
    },
    scales: {
      x: {
        title: {
          display: true,
          text: "Age Groups",
        },
      },
      y: {
        title: {
          display: true,
          text: "Number of Customers",
        },
        beginAtZero: true,
      },
    },
  };

  return (
    <div style={{ textAlign: "center", padding: "20px" }}>
      <h1 className="text-start">Customer Demographics</h1>
      <hr
        style={{
          borderTop: "1px solid #ccc",
          marginTop: "1rem",
          marginBottom: "3rem",
        }}
      />
      <div style={{ display: "flex", justifyContent: "space-around" }}>
        {/* Doughnut Chart */}
        <div style={{ width: "30%" }}>
          <h3>Gender Distribution</h3>
          <Doughnut data={genderData} options={genderOptions} />
        </div>

        {/* Bar Chart */}
        <div style={{ width: "45%" }}>
          <h3>Age Groups</h3>
          <Bar data={ageData} options={ageOptions} />
        </div>
      </div>
    </div>
  );
};
