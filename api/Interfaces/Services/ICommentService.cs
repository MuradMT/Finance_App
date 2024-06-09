namespace api.Interfaces.Services;

public interface ICommentService:IService<CreateCommentDto,UpdateCommentDto, CommentDto>
{
     Task<CommentDto> CreateWithStockIdAsync(CreateCommentDto createDto,int stockId,string userId);
     
     Task<CommentDto> GetComment_With_User_Id_Async(int id);

     Task<List<CommentDto>> Get_Comments_With_User_Id_Async();
}
