const _apiUrl = "/api/Product"

export const getProducts = () => {
    return fetch(`${_apiUrl}`).then((r) => r.json())
}

export const createProduct = (newProduct) => {
    return fetch(`${_apiUrl}`, {
        method: "POST",
        headers:{
            "Content-Type": "application/json",
          },
          body: JSON.stringify(newProduct)
    }).then((res) => res.json());

}

export const deleteProduct = (id) => {
    return fetch(`${_apiUrl}/${id}/delete`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        }
    });

}