import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  getAgeGroups,
  getGenders,
  getLocations,
  getRaces,
} from "../../managers/demoManager";
import { editCustomer, getCustomerById } from "../../managers/customerManager";
import { Button, FormGroup, Input, Label } from "reactstrap";

export const EditCustomer = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [customer, setCustomer] = useState({
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
    getCustomerById(id).then(setCustomer);
  }, [id]);

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

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const res = await editCustomer(id, customer);

      if (res.errors) {
        setErrors(res.errors); // Handle validation errors
      } else {
        navigate("/customers"); // Navigate only after successful edit
      }
    } catch (err) {
      console.error("Failed to edit customer:", err);
      setErrors(err); // Handle unexpected errors
    }
  };

  return (
    <>
      <h2>Edit Customer</h2>
      <form onSubmit={handleSubmit}>
        <FormGroup>
          <Label>Name</Label>
          <Input
            type="text"
            value={customer.name}
            onChange={(e) => {
              const customerCopy = { ...customer };
              customerCopy.name = e.target.value;
              setCustomer(customerCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Email</Label>
          <Input
            type="text"
            value={customer.email}
            onChange={(e) => {
              const customerCopy = { ...customer };
              customerCopy.email = e.target.value;
              setCustomer(customerCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Address</Label>
          <Input
            type="text"
            value={customer.address}
            onChange={(e) => {
              const customerCopy = { ...customer };
              customerCopy.address = e.target.value;
              setCustomer(customerCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Age Group</Label>
          <Input
            type="select"
            value={customer.ageGroupId}
            onChange={(e) => {
              const customerCopy = { ...customer };
              customerCopy.ageGroupId = parseInt(e.target.value);
              setCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose an age group</option>
            {ageGroups.map((a) => (
              <option key={a.id} value={a.id}>{`${a.group}`}</option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Gender</Label>
          <Input
            type="select"
            value={customer.genderId}
            onChange={(e) => {
              const customerCopy = { ...customer };
              customerCopy.genderId = parseInt(e.target.value);
              setCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose a gender</option>
            {genders.map((a) => (
              <option key={a.id} value={a.id}>{`${a.genderValue}`}</option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Race</Label>
          <Input
            type="select"
            value={customer.raceId}
            onChange={(e) => {
              const customerCopy = { ...customer };
              customerCopy.raceId = parseInt(e.target.value);
              setCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose a race</option>
            {races.map((r) => (
              <option key={r.id} value={r.id}>{`${r.raceValue}`}</option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Location</Label>
          <Input
            type="select"
            value={customer.locationId}
            onChange={(e) => {
              const customerCopy = { ...customer };
              customerCopy.locationId = parseInt(e.target.value);
              setCustomer(customerCopy);
            }}
          >
            <option value={0}>Choose a location</option>
            {locations.map((l) => (
              <option key={l.id} value={l.id}>{`${l.locationValue}`}</option>
            ))}
          </Input>
        </FormGroup>
        <Button type="submit" color="primary">
          Submit
        </Button>
        <div style={{ color: "red" }}>
          {Object.keys(errors).map((key) => (
            <p key={key}>
              {key}:{" "}
              {Array.isArray(errors[key])
                ? errors[key].join(", ")
                : errors[key]}
            </p>
          ))}
        </div>
      </form>
    </>
  );
};
