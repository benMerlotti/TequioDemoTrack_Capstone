/* eslint-disable react/prop-types */
import { useState } from "react";
import { NavLink as RRNavLink, useNavigate } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import "../App.css";

// eslint-disable-next-line react/prop-types
export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);
  const navigate = useNavigate();

  const toggleNavbar = () => setOpen(!open);

  // Check if the user has admin rights (you can adjust the logic based on your authentication setup)
  // eslint-disable-next-line react/prop-types
  const isAdmin = loggedInUser?.roles?.includes("Admin");

  return (
    <div>
      <Navbar fixed="top" style={{ background: "#04040a" }} expand="md">
        <NavbarBrand tag={RRNavLink} to="/">
          <img
            src="/Tequio_Logo.png"
            alt="Tequio Logo"
            style={{ marginLeft: "0px", height: "50px", width: "auto" }}
          />
        </NavbarBrand>
        {loggedInUser ? (
          <>
            <NavbarToggler onClick={toggleNavbar} className="custom-toggler">
              <i className="bi bi-list text-white"></i>
            </NavbarToggler>

            <Collapse isOpen={open} navbar>
              <Nav navbar>
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink
                    tag={RRNavLink}
                    to="/customers"
                    className="custom-nav-link"
                  >
                    Customers
                  </NavLink>
                </NavItem>
                {isAdmin && (
                  <>
                    <NavItem onClick={() => setOpen(false)}>
                      <NavLink
                        tag={RRNavLink}
                        to="/employees"
                        className="custom-nav-link"
                      >
                        Ambassadors
                      </NavLink>
                    </NavItem>
                    <NavItem onClick={() => setOpen(false)}>
                      <NavLink
                        tag={RRNavLink}
                        to="/products"
                        className="custom-nav-link"
                      >
                        Products
                      </NavLink>
                    </NavItem>
                  </>
                )}
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink
                    tag={RRNavLink}
                    to="/new-purchase"
                    className="custom-nav-link"
                  >
                    New Purchase
                  </NavLink>
                </NavItem>
                {/* Only show "My Purchases" if the user is not an admin */}
                {!isAdmin && (
                  <NavItem onClick={() => setOpen(false)}>
                    <NavLink
                      tag={RRNavLink}
                      to="/my-purchases"
                      className="custom-nav-link"
                    >
                      My Sales
                    </NavLink>
                  </NavItem>
                )}
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink
                    tag={RRNavLink}
                    to="/purchases"
                    className="custom-nav-link"
                  >
                    All Purchases
                  </NavLink>
                </NavItem>
              </Nav>
            </Collapse>
            <div>
              <span className="nav-logged-in-user">
                {loggedInUser.userName}
              </span>
              <Button
                color="primary"
                onClick={(e) => {
                  e.preventDefault();
                  setOpen(false);
                  logout().then(() => {
                    setLoggedInUser(null);
                    setOpen(false);
                    navigate("/login");
                  });
                }}
              >
                Logout
              </Button>
            </div>
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}
