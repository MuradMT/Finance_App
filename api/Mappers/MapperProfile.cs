namespace api.Mappers;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Stock,StockDto>();
        CreateMap<CreateStockDto,Stock>();

        CreateMap<Comment,CommentDto>();
        CreateMap<CreateCommentDto,Comment>();
    
        //.ForMember(dest=>dest.Symbol,opt=>opt.Ignore());
        //This code helps us to ignore specific property
    }
}
