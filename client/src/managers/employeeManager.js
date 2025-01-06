const _apiUrl = "/api/Employee"

export const getEmployees = () => {
    return fetch(`${_apiUrl}`).then((r) => r.json())
}

export const getEmployeeById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((r) => r.json())
}

export const createEmployee = (newEmployee) => {
    return fetch(`${_apiUrl}`, {
        method: "POST",
        headers:{
            "Content-Type": "application/json",
          },
          body: JSON.stringify(newEmployee)
    }).then((res) => res.json());
}

export const deleteEmployee = (id) => {
    return fetch(`${_apiUrl}/${id}/delete`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        }
    });

}