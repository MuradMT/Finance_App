using api.Dtos.Stock.Request;
using api.Dtos.Stock.Response;
using api.Models;
using AutoMapper;

namespace api.Mappers;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Stock,StockDto>();
        CreateMap<CreateStockDto,Stock>();
    
        //.ForMember(dest=>dest.Symbol,opt=>opt.Ignore());
        //This code helps us to ignore specific property
    }
}
