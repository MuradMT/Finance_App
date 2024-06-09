
namespace api.Repositories;

public class CommentRepository(ApplicationDbContext _context) : BaseRepository<Comment, ApplicationDbContext>(_context), ICommentRepository
{
    public async Task<List<Comment>> Get_Comments_With_User_Id_Async()
    {
        return await _context.Comments.Include(a=>a.AppUser).ToListAsync();
    }

    public async Task<Comment?> Get_Comment_With_User_Id_Async(int id)
    {
        return await _context.Comments.Include(a=>a.AppUser).FirstOrDefaultAsync(x=>x.Id==id);
    }
}
