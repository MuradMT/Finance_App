import React, { ChangeEvent, SyntheticEvent, useState } from 'react'

interface Props  {
    onClick:(e:SyntheticEvent)=>void;
    handleChange:(e: ChangeEvent<HTMLInputElement>)=>void;
    search:string|undefined;
}

const Search: React.FC<Props> = ({onClick,handleChange,search}: Props): JSX.Element => {
    
    return (
        <div>
            <input value={search} onChange={(e) => { handleChange(e) }}></input>
            <button onClick={(e)=>onClick(e)}>Click me</button>
            
        </div>
    )
}

export default Search