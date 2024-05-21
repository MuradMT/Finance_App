


namespace api.Services;

public class CommentService(ICommentRepository _repository,IMapper _mapper,IConverter<Comment,UpdateCommentDto> _converter)
:BaseService<CreateCommentDto,CommentDto,Comment,UpdateCommentDto>(_repository,_mapper,_converter),ICommentService
{
}
