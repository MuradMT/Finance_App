import React, { SyntheticEvent } from 'react'

interface Props {
  onPortfolioCreate:(e:SyntheticEvent)=>void;
  symbol:string;
}

const AddPortfolio:React.FC<Props> = ({onPortfolioCreate,symbol}: Props):JSX.Element => {
  return (
    <form onSubmit={onPortfolioCreate}>
      <input readOnly={true} hidden={true} value={symbol}/>
      <button type='submit' className='button'>Add</button>
    </form>
  )
}

export default AddPortfolio