import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { CustomerList } from "./customer/CustomerList";
import { EmployeeList } from "./employee/EmployeeList";
import { ProductList } from "./product/ProductList";
import { PurchaseList } from "./purchase/PurchaseList";
import { CreatePurchase } from "./purchase/CreatePurchase";
import { CreateCustomer } from "./customer/CreateCustomer";
import { CreateEmployee } from "./employee/CreateEmployee";
import { CustomerDetails } from "./customer/CustomerDetails";
import { EmployeeDetails } from "./employee/EmployeeDetails";
import { EditCustomer } from "./customer/EditCustomer";

// eslint-disable-next-line react/prop-types
export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}></AuthorizedRoute>
          }
        />
        <Route
          path="purchases"
          element={<PurchaseList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="new-purchase"
          element={
            <CreatePurchase
              setLoggedInUser={setLoggedInUser}
              loggedInUser={loggedInUser}
            />
          }
        />
        <Route
          path="products"
          element={<ProductList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="employees"
          element={<EmployeeList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="employees/:id"
          element={<EmployeeDetails setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="employees/add-employee"
          element={<CreateEmployee setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="customers"
          element={<CustomerList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="customers/:id"
          element={<CustomerDetails setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="customers/:id/edit"
          element={<EditCustomer setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="customers/add-customer"
          element={<CreateCustomer setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
