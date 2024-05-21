using api.Data;
using api.Interfaces;
using api.Models;

namespace api;

public class CommentRepository : BaseRepository<Comment, ApplicationDbContext>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext _context) : base(_context)
    {
    }
}
