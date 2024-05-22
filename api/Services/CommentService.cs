namespace api.Services;

public class CommentService(IUnitOfWork<Comment,ApplicationDbContext> _unitofwork,IMapper _mapper,IConverter<Comment,UpdateCommentDto> _converter)
:BaseService<Comment,ApplicationDbContext,CommentDto,CreateCommentDto,UpdateCommentDto>(_unitofwork,_mapper,_converter),ICommentService
{
}
