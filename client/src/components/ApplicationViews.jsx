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
import { EditEmployee } from "./employee/EditEmployee";
import { CreateProduct } from "./product/CreateProduct";
import { ProductDetails } from "./product/ProductDetails";
import { EditProduct } from "./product/EditProduct";
import { PurchaseDetails } from "./purchase/PurchaseDetails";
import { EditPurchase } from "./purchase/EditPurchase";

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
      </Route>
      <Route path="purchases">
        <Route
          index
          element={<PurchaseList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path=":id"
          element={
            <PurchaseDetails
              setLoggedInUser={setLoggedInUser}
              loggedInUser={loggedInUser}
            />
          }
        />
        <Route
          path=":id/edit"
          element={
            <EditPurchase
              setLoggedInUser={setLoggedInUser}
              loggedInUser={loggedInUser}
            />
          }
        />
      </Route>
      <Route path="new-purchase">
        <Route
          index
          element={
            <CreatePurchase
              setLoggedInUser={setLoggedInUser}
              loggedInUser={loggedInUser}
            />
          }
        />
      </Route>
      <Route path="products">
        <Route
          index
          element={<ProductList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path=":id"
          element={<ProductDetails setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path=":id/edit"
          element={<EditProduct setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="add-product"
          element={<CreateProduct setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="employees">
        <Route
          index
          element={<EmployeeList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path=":id"
          element={<EmployeeDetails setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path=":id/edit"
          element={<EditEmployee setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="add-employee"
          element={<CreateEmployee setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="customers">
        <Route
          index
          element={<CustomerList setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path=":id"
          element={<CustomerDetails setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path=":id/edit"
          element={<EditCustomer setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="add-customer"
          element={<CreateCustomer setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route
        path="login"
        element={<Login setLoggedInUser={setLoggedInUser} />}
      />
      <Route
        path="register"
        element={<Register setLoggedInUser={setLoggedInUser} />}
      />
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
