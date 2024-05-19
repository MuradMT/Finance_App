using AutoMapper;

namespace api;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Stock,StockDto>();
        //.ForMember(dest=>dest.Symbol,opt=>opt.Ignore());
        //This code helps us to ignore specific property
    }
}
