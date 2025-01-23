// import React, { createContext, useState, useContext, useEffect } from "react";
// import { getPendingActivations } from "../managers/abassadorManager";

// const PendingActivationsContext = createContext();

// export const PendingActivationsProvider = ({ children }) => {
//   const [pendingUsers, setPendingUsers] = useState([]);

//   useEffect(() => {}, []);

//   const fetchPendingUsers = async () => {
//     const data = await getPendingActivations();
//     setPendingUsers(data);
//   };

//   return (
//     <PendingActivationsContext.Provider
//       value={{ pendingUsers, fetchPendingUsers }}
//     >
//       {children}
//     </PendingActivationsContext.Provider>
//   );
// };

// export const usePendingActivations = () =>
//   useContext(PendingActivationsContext);
