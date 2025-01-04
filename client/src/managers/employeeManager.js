const _apiUrl = "/api/Employee"

export const getEmployees = () => {
    return fetch(`${_apiUrl}`).then((r) => r.json())
}