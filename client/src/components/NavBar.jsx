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
      <Navbar color="light" light fixed="top" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          Tequio Demo Tracker
        </NavbarBrand>
        {loggedInUser ? (
          <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
              <Nav navbar>
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink tag={RRNavLink} to="/customers">
                    Customers
                  </NavLink>
                </NavItem>
                {isAdmin && (
                  <>
                    <NavItem onClick={() => setOpen(false)}>
                      <NavLink tag={RRNavLink} to="/employees">
                        Ambassadors
                      </NavLink>
                    </NavItem>
                    <NavItem onClick={() => setOpen(false)}>
                      <NavLink tag={RRNavLink} to="/products">
                        Products
                      </NavLink>
                    </NavItem>
                  </>
                )}
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
            </Collapse>
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
