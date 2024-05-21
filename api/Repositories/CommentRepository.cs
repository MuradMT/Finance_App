namespace api.Repositories;

public class CommentRepository : BaseRepository<Comment, ApplicationDbContext>,ICommentRepository
{
    public CommentRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
