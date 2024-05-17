import React, { SyntheticEvent } from 'react'

interface Props  {
    onPortfolioDelete:(e:SyntheticEvent)=>void;
    portfolioValue:string;
}

const DeletePortfolio:React.FC<Props>= ({onPortfolioDelete,portfolioValue}: Props):JSX.Element=> {
  return (
    <div>
      <form onSubmit={onPortfolioDelete}>
        <input hidden={true} value={portfolioValue}/>
        <button>Delete</button>
      </form>
    </div>
  )
}

export default DeletePortfolio