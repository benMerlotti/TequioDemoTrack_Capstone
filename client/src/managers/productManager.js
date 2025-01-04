const _apiUrl = "/api/Product"

export const getProducts = () => {
    return fetch(`${_apiUrl}`).then((r) => r.json())
}