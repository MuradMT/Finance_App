namespace api.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Stock, StockDto>();

        CreateMap<CreateStockDto, Stock>()
        ;

        CreateMap<Comment, CommentDto>()
        .ForMember(x=>x.CreatedBy, opt => opt.MapFrom(src => src.AppUser.UserName));
        CreateMap<CreateCommentDto, Comment>();

        CreateMap<CreateCommentDto, Comment>()
                .ForMember(dest => dest.StockId, opt => opt.MapFrom((src, dest, destMember, context) =>
                    context.Items["StockId"] != null ? (int)context.Items["StockId"] : (int?)null));
        //.ForMember(dest=>dest.Symbol,opt=>opt.Ignore());
        //This code helps us to ignore specific property
    }
}
