import React, { useEffect, useState } from "react";
import { CompanyTenK } from "../../Types/company";
import { getTenK } from "../../API/api";
import Spinner from "../Spinner/Spinner";
import TenKFinderItem from "./TenKFinderItem/TenKFinderItem";

type Props = {
  ticker: string;
};

const TenKFinder = ({ ticker }: Props) => {
  const [companyData, setCompanyData] = useState<CompanyTenK[]>();
  useEffect(() => {
    const fetchTenKData = async () => {
      const result = await getTenK(ticker);
      setCompanyData(result?.data);
    };
    fetchTenKData();
  }, [ticker]);
  return (
    <div className="inline-flex rounded-md shadow-sm m-4">
      {companyData ? (
        companyData?.slice(0, 5).map((tenK) => {
          return <TenKFinderItem tenK={tenK} />;
        })
      ) : (
        <Spinner />
      )}
    </div>
  );
};

export default TenKFinder;
