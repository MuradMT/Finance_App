import React from "react";
import { testIncomeStatementData } from "./testData";

interface Props {}

type Company = (typeof data)[0];

const data = testIncomeStatementData;

const configs = [
  {
    Label: "Year",
    render: (company: Company) => company.acceptedDate,
  },
  {
    Label: "Cost of Revenue",
    render: (company: Company) => company.revenue,
  },
];

const Table = (props: Props) => {
  const renderedRows = data.map((company: Company) => {
    return (
      <tr key={company.cik}>
        {configs.map((config: any) => {
          return (
            <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
              {config.render(company)}
            </td>
          );
        })}
      </tr>
    );
  });
  const renderedHeaders = configs.map((config: any) => {
    return (
      <th
        className="p-4 uppercase tracking-wider text-xs text-left font-medium text-gray-500"
        key={config.Label}
      >
        {config.Label}
      </th>
    );
  });
  return (
    <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8">
      <table className="min-w-full divide-y divide-gray-200 m-5">
        <thead className="bg-gray-50">{renderedHeaders}</thead>
        <tbody>{renderedRows}</tbody>
      </table>
    </div>
  );
};

export default Table;
