import React from 'react'

interface Props  {
  portfolioValue:string;
}

const CardPortfolio:React.FC<Props>= ({portfolioValue}: Props):JSX.Element=> {
  return (
    <>
       <h4>{portfolioValue}</h4>
       <button>Delete</button>
    </>
  )
}

export default CardPortfolio