

namespace api.Services;

public class CommentService(IUnitOfWork<Comment, ApplicationDbContext> _unitofwork, IMapper _mapper, IConverter<Comment, UpdateCommentDto> _converter,ICommentRepository _repository)
: BaseService<Comment, ApplicationDbContext, CommentDto, CreateCommentDto, UpdateCommentDto>(_unitofwork, _mapper, _converter), ICommentService
{
    public async Task<CommentDto> CreateWithStockIdAsync(CreateCommentDto createDto,int stockId,string userId)
    {
        var entity = _mapper.Map<Comment>(createDto,opt => opt.Items["StockId"] = stockId);
        entity.AppUserId=userId;
        await _unitofwork.Repository.AddAsync(entity);
        return _mapper.Map<CommentDto>(entity);
    }

    public async Task<CommentDto> GetComment_With_User_Id_Async(int id)
    {
        var comment= await _repository.Get_Comment_With_User_Id_Async(id);
        return _mapper.Map<CommentDto>(comment);
    }

    public async Task<List<CommentDto>> Get_Comments_With_User_Id_Async()
    {
        var comments=await _repository.Get_Comments_With_User_Id_Async();
        return _mapper.Map<List<CommentDto>>(comments);
    }
}
