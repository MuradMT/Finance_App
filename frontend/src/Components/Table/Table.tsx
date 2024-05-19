
interface Props {
  data: any;
  config: any;
}



const Table = ({config,data}: Props) => {
  const renderedRows = data.map((company: any) => {
    return (
      <tr key={company.cik}>
        {
            config.map((config: any) =>{
                return <td className="p-3">{config.render(company)}</td>
            })
        }
      </tr>
    );
  });
  const renderedHeaders = config.map((config: any) => {
    return (
      <th
        className="p-4 uppercase tracking-wider text-xs text-left font-medium text-gray-500"
        key={config.label}
      >
        {config.label}
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
