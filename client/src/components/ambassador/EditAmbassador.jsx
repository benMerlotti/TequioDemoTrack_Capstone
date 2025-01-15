import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { editEmployee, getEmployeeById } from "../../managers/abassadorManager";

export const EditEmployee = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [employee, setEmployee] = useState({
    name: "",
    email: "",
    address: "",
  });
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getEmployeeById(id).then(setEmployee);
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();

    editEmployee(id, employee).then((res) => {
      if (res.errors) {
        setErrors(res.errors);
      } else {
        navigate("/employees");
      }
    });
  };
  return (
    <>
      <h2>Edit Employee</h2>
      <form onSubmit={handleSubmit}>
        <FormGroup>
          <Label>Name</Label>
          <Input
            type="text"
            value={employee.name}
            onChange={(e) => {
              const employeeCopy = { ...employee };
              employeeCopy.name = e.target.value;
              setEmployee(employeeCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Email</Label>
          <Input
            type="text"
            value={employee.email}
            onChange={(e) => {
              const employeeCopy = { ...employee };
              employeeCopy.email = e.target.value;
              setEmployee(employeeCopy);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Address</Label>
          <Input
            type="text"
            value={employee.address}
            onChange={(e) => {
              const employeeCopy = { ...employee };
              employeeCopy.address = e.target.value;
              setEmployee(employeeCopy);
            }}
          />
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
