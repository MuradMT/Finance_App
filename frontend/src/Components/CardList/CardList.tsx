import React from 'react'
import Card from '../Card/Card'

interface Props {

}

const CardList:React.FC<Props>= (props: Props):JSX.Element => {
  return (
    <div>
      <Card companyName='Microsoft' ticker='MSFT' price={100}/>
      <Card companyName='Tesla' ticker='TSL' price={200}/>
      <Card companyName='Amazon' ticker='AMZN' price={250}/>
    </div>
  );
}

export default CardList