import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';

function App() {
  const [search, setSearch] = useState<string>("");
    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value)
        console.log(e)
    }
    const onClick=(e:SyntheticEvent)=>{
        alert(search)
    }
  return (
    <div>
      <Search onClick={onClick} handleChange={handleChange} search={search}/>
      <CardList />
    </div>
  );
}

export default App;
