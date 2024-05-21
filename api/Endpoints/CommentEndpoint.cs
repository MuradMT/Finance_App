namespace api.Endpoints;

public static class CommentEndpoint
{

    public static void MapCommentEndpoints(this IEndpointRouteBuilder routes){

        #region  Get All Comments

        routes.MapGet("/api/comments", async Task<IResult> (ICommentService _service) =>
        {
            try
            {
                var comments = await _service.GetAllAsync();
                return TypedResults.Ok(comments);
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getAllComments")
        .WithTags("Comments")
        .Produces<List<CommentDto>>(StatusCodes.Status200OK);
        
        #endregion
    }
}
