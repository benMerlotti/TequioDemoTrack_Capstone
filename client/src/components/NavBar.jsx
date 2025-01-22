import { useState } from "react";
import { NavLink as RRNavLink, useNavigate } from "react-router-dom";
import {
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Button,
} from "reactstrap";
import { logout } from "../managers/authManager";
import "../App.css";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const navigate = useNavigate();

  const toggleNavbar = () => setOpen(!open);
  const toggleDropdown = () => setDropdownOpen(!dropdownOpen);

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
            <div className="d-flex align-items-center">
              <Dropdown isOpen={dropdownOpen} toggle={toggleDropdown}>
                <DropdownToggle
                  tag="button"
                  className="btn btn-light btn-sm p-0 border-0 d-flex align-items-center"
                >
                  <i className="bi bi-person-circle text-white me-2 fs-3"></i>
                  <span className="text-white">{loggedInUser.userName}</span>
                </DropdownToggle>
                <DropdownMenu>
                  <DropdownItem
                    onClick={(e) => {
                      e.preventDefault();
                      setOpen(false);
                      logout().then(() => {
                        setLoggedInUser(null);
                        navigate("/login");
                      });
                    }}
                    className="text-danger"
                  >
                    Log Out
                  </DropdownItem>
                </DropdownMenu>
              </Dropdown>
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
