
namespace api.Services;

public class CommentService(IUnitOfWork<Comment, ApplicationDbContext> _unitofwork, IMapper _mapper, IConverter<Comment, UpdateCommentDto> _converter)
: BaseService<Comment, ApplicationDbContext, CommentDto, CreateCommentDto, UpdateCommentDto>(_unitofwork, _mapper, _converter), ICommentService
{
    public async Task<CommentDto> CreateWithStockIdAsync(CreateCommentDto createDto,int stockId)
    {
        var entity = _mapper.Map<Comment>(createDto,opt => opt.Items["StockId"] = stockId);
        await _unitofwork.Repository.AddAsync(entity);
        return _mapper.Map<CommentDto>(entity);
    }

}
