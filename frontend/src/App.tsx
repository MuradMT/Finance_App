import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { CompanySearch } from './Types/company';
import { searchCompanies } from './API/api';

function App() {
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string|null>(null);

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value)
    console.log(e)
  }
  const onClick =async (e: SyntheticEvent) => {
     const result=await searchCompanies(search);
     if(typeof result==="string"){
        setServerError(result);
        console.log(serverError);
     }
     else if(Array.isArray(result.data)){
       setSearchResult(result.data);
       console.log(searchResult)
     }
  }
  return (
    <div>
      <Search onClick={onClick} handleChange={handleChange} search={search} />
      {/* {1===1?<h1>True</h1>:<h1>False</h1>} */}
      {serverError&&<h1>{serverError}</h1>}
      <CardList searchResult={searchResult}/>
    </div>
  );
}

export default App;
