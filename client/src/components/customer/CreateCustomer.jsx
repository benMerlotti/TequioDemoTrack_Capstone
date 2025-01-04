import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { createCustomer } from "../../managers/customerManager";
import {
  getAgeGroups,
  getGenders,
  getLocations,
  getRaces,
} from "../../managers/demoManager";

export const CreateCustomer = () => {
  const navigate = useNavigate();
  const [newCustomer, setNewCustomer] = useState({
    name: "",
    email: "",
    address: "",
    ageGroupId: 0,
    genderId: 0,
    raceId: 0,
    locationId: 0,
  });
  const [ageGroups, setAgeGroups] = useState([]);
  const [genders, setGenders] = useState([]);
  const [races, setRaces] = useState([]);
  const [locations, setLocations] = useState([]);
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getAgeGroups().then(setAgeGroups);
  }, []);

  useEffect(() => {
    getGenders().then(setGenders);
  }, []);

  useEffect(() => {
    getRaces().then(setRaces);
  }, []);

  useEffect(() => {
    getLocations().then(setLocations);
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    createCustomer(newCustomer).then((res) => {
      if (res.errors) {
        setErrors(res.errors);
      } else {
        navigate("/customers");
      }
    });
  };
  return (
    <>
      <h2>Add Customer</h2>
      <form onSubmit={handleSubmit}>
        <FormGroup>
          <Label>Name</Label>
          <Input
            type="text"
            value={newCustomer.name}
            onChange={(e) => {
              const customerCopy = { ...newCustomer };
              customerCopy.name = e.target.value;
              setNewCustomer(customerCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Email</Label>
          <Input
            type="text"
            value={newCustomer.email}
            onChange={(e) => {
              const customerCopy = { ...newCustomer };
              customerCopy.email = e.target.value;
              setNewCustomer(customerCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Address</Label>
          <Input
            type="text"
            value={newCustomer.address}
            onChange={(e) => {
              const customerCopy = { ...newCustomer };
              customerCopy.address = e.target.value;
              setNewCustomer(customerCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Age Group</Label>
          <Input
            type="select"
            value={newCustomer.ageGroupId}
            onChange={(e) => {
              const customerCopy = { ...newCustomer };
              customerCopy.ageGroupId = parseInt(e.target.value);
              setNewCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose an age group</option>
            {ageGroups.map((a) => (
              <option key={a} value={a.id}>{`${a.group}`}</option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Gender</Label>
          <Input
            type="select"
            value={newCustomer.genderId}
            onChange={(e) => {
              const customerCopy = { ...newCustomer };
              customerCopy.genderId = parseInt(e.target.value);
              setNewCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose a gender</option>
            {genders.map((a) => (
              <option key={a} value={a.id}>{`${a.genderValue}`}</option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Race</Label>
          <Input
            type="select"
            value={newCustomer.raceId}
            onChange={(e) => {
              const customerCopy = { ...newCustomer };
              customerCopy.raceId = parseInt(e.target.value);
              setNewCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose a race</option>
            {races.map((r) => (
              <option key={r} value={r.id}>{`${r.raceValue}`}</option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Location</Label>
          <Input
            type="select"
            value={newCustomer.locationId}
            onChange={(e) => {
              const customerCopy = { ...newCustomer };
              customerCopy.locationId = parseInt(e.target.value);
              setNewCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose a location</option>
            {locations.map((l) => (
              <option key={l} value={l.id}>{`${l.locationValue}`}</option>
            ))}
          </Input>
        </FormGroup>
        <Button type="submit" color="primary">
          Submit
        </Button>
        <div style={{ color: "red" }}>
          {Object.keys(errors).map((key) => (
            <p key={key}>
              {key}: {errors[key].join(",")}
            </p>
          ))}
        </div>
      </form>
    </>
  );
};
