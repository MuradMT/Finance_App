import axios from 'axios'
import { CompanyBalanceSheet, CompanyCashFlow, CompanyCompData, CompanyIncomeStatement, CompanyKeyMetrics, CompanyProfile, CompanySearch } from '../Types/company'
import { error } from 'console';
interface SearchResponse {
    data: CompanySearch[]
}
export const searchCompanies = async (query: string) => {
    try {
        const data = await axios.get<SearchResponse>(
            `https://financialmodelingprep.com/api/v3/search?query=${query}&limit=10&exchange=NASDAQ&apikey=${process.env.REACT_APP_API_KEY}`
        );
        return data;
    } catch (error:any) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
};

export const getCompanyProfile=async (query:string)=>{
    try {
        const data = await axios.get<CompanyProfile[]>(
            `https://financialmodelingprep.com/api/v3/profile/${query}?apikey=${process.env.REACT_APP_API_KEY}`
        );
        return data;
    } catch (error:any) {
        console.log("error message from API: ", error);
    }
}

export const getKeyMetrics=async (query:string)=>{
    try {
        const data = await axios.get<CompanyKeyMetrics[]>(
            `https://financialmodelingprep.com/api/v3/key-metrics-ttm/${query}?apikey=${process.env.REACT_APP_API_KEY}`
        );
        return data;
    } catch (error:any) {
        console.log("error message from API: ", error);
    }
}

export const getIncomeStatement=async (query:string)=>{
    try {
        const data = await axios.get<CompanyIncomeStatement[]>(
            `https://financialmodelingprep.com/api/v3/income-statement/${query}?limit=40&apikey=${process.env.REACT_APP_API_KEY}`
        );
        return data;
    } catch (error:any) {
        console.log("error message from API: ", error);
    }
}


export const getBalanceSheet=async (query:string)=>{
    try {
        const data = await axios.get<CompanyBalanceSheet[]>(
            `https://financialmodelingprep.com/api/v3/balance-sheet-statement/${query}?limit=40&apikey=${process.env.REACT_APP_API_KEY}`
        );
        return data;
    } catch (error:any) {
        console.log("error message from API: ", error);
    }
}

export const getCashFlow=async (query:string)=>{
    try {
        const data = await axios.get<CompanyCashFlow[]>(
            `https://financialmodelingprep.com/api/v3/cash-flow-statement/${query}?limit=40&apikey=${process.env.REACT_APP_API_KEY}`
        );
        return data;
    } catch (error:any) {
        console.log("error message from API: ", error);
    }
}

export const getCompData = async (query: string) => {
    try {
      const data = await axios.get<CompanyCompData[]>(
        `https://financialmodelingprep.com/api/v4/stock_peers?symbol=${query}&apikey=${process.env.REACT_APP_API_KEY}`
      );
      return data;
    } catch (error: any) {
      console.log("error message: ", error.message);
    }
  };