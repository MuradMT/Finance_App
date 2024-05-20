import React, { useEffect, useState } from "react";
import { CompanyCashFlow } from "../../Types/company";
import { useOutletContext } from "react-router";
import { getCashFlow } from "../../API/api";
import Table from "../Table/Table";
import Spinner from "../Spinner/Spinner";

type Props = {};

const config = [
  {
    label: "Date",
    render: (company: CompanyCashFlow) => company.date,
  },
  {
    label: "Operating Cashflow",
    render: (company: CompanyCashFlow) => company.operatingCashFlow,
  },
  {
    label: "Investing Cashflow",
    render: (company: CompanyCashFlow) =>
      company.netCashUsedForInvestingActivites,
  },
  {
    label: "Financing Cashflow",
    render: (company: CompanyCashFlow) =>
      company.netCashUsedProvidedByFinancingActivities,
  },
  {
    label: "Cash At End of Period",
    render: (company: CompanyCashFlow) => company.cashAtEndOfPeriod,
  },
  {
    label: "CapEX",
    render: (company: CompanyCashFlow) => company.capitalExpenditure,
  },
  {
    label: "Issuance Of Stock",
    render: (company: CompanyCashFlow) => company.commonStockIssued,
  },
  {
    label: "Free Cash Flow",
    render: (company: CompanyCashFlow) => company.freeCashFlow,
  },
];

const CashflowStatement = (props: Props) => {
  const ticker = useOutletContext<string>();
  const [cashFlow, setCashFlow] = useState<CompanyCashFlow[]>();
  useEffect(() => {
    const cashFlowFetch = async () => {
      const result = await getCashFlow(ticker!);
      setCashFlow(result!.data);
    };
    cashFlowFetch();
  }, []);

  return (
    <>
      {cashFlow ? (
        <Table config={config} data={cashFlow} />
      ) : (
        <Spinner />
      )}
    </>
  );
};

export default CashflowStatement;
