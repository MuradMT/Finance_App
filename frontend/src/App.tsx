import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { CompanySearch } from './Types/company';
import { searchCompanies } from './API/api';
import ListPortfolio from './Components/Portfolio/ListPortfolio/ListPortfolio';

function App() {
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);
  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value)
    console.log(e)
  }

  const onPortfolioCreate = (e: any) => {
    e.preventDefault();
    const exists=portfolioValues.find((value)=>value===e.target[0].value);
    if(exists) return;
    const updatedPortfolio = [...portfolioValues, e.target[0].value];
    setPortfolioValues(updatedPortfolio);
  };


  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search);
    if (typeof result === "string") {
      setServerError(result);
      console.log(serverError);
    }
    else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
      console.log(searchResult)
    }
  }


  return (
    <div>
      <Search onSearchSubmit={onSearchSubmit} handleSearchChange={handleSearchChange} search={search} />
      <ListPortfolio portfolioValues={portfolioValues} />
      <CardList searchResult={searchResult} onPortfolioCreate={onPortfolioCreate} />
      {serverError && <div>Unable to connect to API</div>}
    </div>
  );
}

export default App;
