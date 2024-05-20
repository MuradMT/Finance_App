import React, { useEffect } from "react";
import { CompanyCompData } from "../../Types/company";
import { getCompData } from "../../API/api";
import CompFinderItem from "./CompFinderItem/CompFinderItem";

type Props = {
  ticker: string;
};

const CompFinder = ({ ticker }: Props) => {
  const [compData, setCompData] = React.useState<CompanyCompData>();
  useEffect(() => {
    const fetchCompData = async () => {
      const result = await getCompData(ticker);
      setCompData(result?.data[0]);
    };
    fetchCompData();
  }, [ticker]);
  return (
    <div className="inline-flex rounded-md shadow-sm m-4">
      {compData?.peersList.map((ticker) => {
        return <CompFinderItem ticker={ticker} />;
      })}
    </div>
  );
};

export default CompFinder;
