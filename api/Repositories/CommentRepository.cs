namespace api.Repositories;

public class CommentRepository(ApplicationDbContext _context) : BaseRepository<Comment, ApplicationDbContext>(_context),ICommentRepository
{
    
}
