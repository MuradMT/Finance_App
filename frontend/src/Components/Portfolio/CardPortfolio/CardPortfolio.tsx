import React, { SyntheticEvent } from 'react'
import DeletePortfolio from '../DeletePortfolio/DeletePortfolio';

interface Props  {
  portfolioValue:string;
  onPortfolioDelete: (e: SyntheticEvent) => void;
}

const CardPortfolio:React.FC<Props>= ({portfolioValue,onPortfolioDelete,}: Props):JSX.Element=> {
  return (
    <>
       <h4>{portfolioValue}</h4>
       <DeletePortfolio onPortfolioDelete={onPortfolioDelete} portfolioValue={portfolioValue}/>
    </>
  )
}

export default CardPortfolio