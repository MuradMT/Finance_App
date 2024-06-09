namespace api.Interfaces.Repositories;

public interface ICommentRepository:IRepository<Comment>
{
    Task<List<Comment>> Get_Comments_With_User_Id_Async();
    Task<Comment?> Get_Comment_With_User_Id_Async(int id);
}
