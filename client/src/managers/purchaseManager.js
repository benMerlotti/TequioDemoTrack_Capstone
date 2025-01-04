const _apiUrl = "/api/Purchase"

export const getPurchases = () => {
    return fetch(`${_apiUrl}`).then((r) => r.json())
}

export const createPurchase = (newPurchase) => {
    return fetch(`${_apiUrl}`, {
        method: "POST",
        headers:{
            "Content-Type": "application/json",
          },
          body: JSON.stringify(newPurchase)
    }).then((res) => res.json());
}