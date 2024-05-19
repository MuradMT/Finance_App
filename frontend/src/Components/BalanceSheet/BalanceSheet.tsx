import React, { useEffect, useState } from 'react'
import { CompanyBalanceSheet } from '../../Types/company';
import { useOutletContext } from 'react-router';
import { getBalanceSheet } from '../../API/api';
import RatioList from '../RatioList/RatioList';

type Props = {}
const config = [
  {
    label: "Cash",
    render: (company: CompanyBalanceSheet) => company.cashAndCashEquivalents,
  },
  {
    label: "Inventory",
    render: (company: CompanyBalanceSheet) => company.inventory,
  },
  {
    label: "Other Current Assets",
    render: (company: CompanyBalanceSheet) => company.otherCurrentAssets,
  },
  {
    label: "Minority Interest",
    render: (company: CompanyBalanceSheet) => company.minorityInterest,
  },
  {
    label: "Other Non-Current Assets",
    render: (company: CompanyBalanceSheet) => company.otherNonCurrentAssets,
  },
  {
    label: "Long Term Debt",
    render: (company: CompanyBalanceSheet) => company.longTermDebt,
  },
  {
    label: "Total Debt",
    render: (company: CompanyBalanceSheet) => company.otherCurrentLiabilities,
  },
];

const BalanceSheet = (props: Props) => {
  const ticket=useOutletContext<string>();
  const [balanceSheet,setBalanceSheet] = useState<CompanyBalanceSheet>();
  useEffect(()=>{
    const getBalanceSheetInit = async () => {
      const result = await getBalanceSheet(ticket!);
      setBalanceSheet(result?.data[0]);
    }
    getBalanceSheetInit();
  },[]);
  return (
    <> 
         {
          balanceSheet?(
            <RatioList config={config} data={balanceSheet}/>
          ):(
            <h1>Company not found!</h1>
          )
         }
    </>
  )
}

export default BalanceSheet