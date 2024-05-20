import React, { useEffect, useState } from 'react'
import { CompanyBalanceSheet } from '../../Types/company';
import { useOutletContext } from 'react-router';
import { getBalanceSheet } from '../../API/api';
import RatioList from '../RatioList/RatioList';
import Spinner from '../Spinner/Spinner';

type Props = {}
const config = [
  {
    Label: "Cash",
    render: (company: CompanyBalanceSheet) => company.cashAndCashEquivalents,
  },
  {
    Label: "Inventory",
    render: (company: CompanyBalanceSheet) => company.inventory,
  },
  {
    Label: "Other Current Assets",
    render: (company: CompanyBalanceSheet) => company.otherCurrentAssets,
  },
  {
    Label: "Minority Interest",
    render: (company: CompanyBalanceSheet) => company.minorityInterest,
  },
  {
    Label: "Other Non-Current Assets",
    render: (company: CompanyBalanceSheet) => company.otherNonCurrentAssets,
  },
  {
    Label: "Long Term Debt",
    render: (company: CompanyBalanceSheet) => company.longTermDebt,
  },
  {
    Label: "Total Debt",
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
            <Spinner/>
          )
         }
    </>
  )
}

export default BalanceSheet