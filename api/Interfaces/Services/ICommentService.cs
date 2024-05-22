namespace api.Interfaces.Services;

public interface ICommentService:IService<CreateCommentDto,UpdateCommentDto, CommentDto>
{
     Task<CommentDto> CreateWithStockIdAsync(CreateCommentDto createDto,int stockId);

}
