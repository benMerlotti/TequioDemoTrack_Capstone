import { useEffect, useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  Row,
} from "reactstrap";
import { logout } from "../managers/authManager";

// eslint-disable-next-line react/prop-types
export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);
  const [isDarkMode, setIsDarkMode] = useState(() => {
    // Check localStorage for theme preference
    const savedTheme = localStorage.getItem("isDarkMode");
    return savedTheme ? JSON.parse(savedTheme) : false;
  });

  const toggleDarkMode = () => {
    setIsDarkMode((prevMode) => {
      const newMode = !prevMode;
      document.body.classList.toggle("dark-mode", newMode);
      localStorage.setItem("isDarkMode", JSON.stringify(newMode));
      return newMode;
    });
  };

  useEffect(() => {
    // Apply initial theme from localStorage
    document.body.classList.toggle("dark-mode", isDarkMode);
  }, [isDarkMode]);

  return (
    <div>
      <Navbar
        color={isDarkMode ? "dark" : "light"}
        dark={isDarkMode}
        light={!isDarkMode}
        fixed="top"
        expand="lg"
      >
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          Tequio Demo Tracker
        </NavbarBrand>
        <Nav navbar>
          <NavItem onClick={() => setOpen(false)}>
            <NavLink tag={RRNavLink} to="/customers">
              Customers
            </NavLink>
          </NavItem>
          <NavItem onClick={() => setOpen(false)}>
            <NavLink tag={RRNavLink} to="/employees">
              Employees
            </NavLink>
          </NavItem>
          <NavItem onClick={() => setOpen(false)}>
            <NavLink tag={RRNavLink} to="/products">
              Products
            </NavLink>
          </NavItem>
          <NavItem onClick={() => setOpen(false)}>
            <NavLink tag={RRNavLink} to="/new-purchase">
              New Purchase
            </NavLink>
          </NavItem>
          <NavItem onClick={() => setOpen(false)}>
            <NavLink tag={RRNavLink} to="/purchases">
              All Purchases
            </NavLink>
          </NavItem>
        </Nav>
        <div>
          <Button onClick={toggleDarkMode} color="secondary" className="me-3">
            {isDarkMode ? "Light Mode" : "Dark Mode"}
          </Button>
          {loggedInUser && (
            <Button
              color="primary"
              onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => setLoggedInUser(null));
              }}
            >
              Logout
            </Button>
          )}
        </div>
      </Navbar>
    </div>
  );
}
