import { createBrowserRouter } from "react-router-dom";
import { App, HomePage, CompanyPage, SearchPage, CompanyProfile, IncomeStatement, DesignPage, BalanceSheet,CashflowStatement } from "./Imports";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "",
                element: <HomePage />
            },
            {
                path: "search",
                element: <SearchPage />
            },
            {
                path: "design-guide",
                element: <DesignPage />
            },
            {
                path: "company/:ticker",
                element: <CompanyPage />,
                children:[
                    {
                        path: "company-profile",
                        element: <CompanyProfile />
                    },
                    {
                        path: "income-statement",
                        element: <IncomeStatement />
                    },{
                        path: "balance-sheet",
                        element: <BalanceSheet />
                    },
                    {
                        path: "cash-flow-statement",
                        element: <CashflowStatement />
                    }
                ]
            }
        ]
    }
]);