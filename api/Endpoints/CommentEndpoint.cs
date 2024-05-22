namespace api.Endpoints;

public static class CommentEndpoint
{

    public static void MapCommentEndpoints(this IEndpointRouteBuilder routes)
    {

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

        #region Get Comment By ID

        routes.MapGet("/api/comment/{id}", async Task<IResult> ([FromRoute] int id,
        ICommentService _service) =>
        {
            try
            {
                var comment = await _service.GetByIdAsync(id);

                return TypedResults.Ok(comment);
            }
            catch (NotFoundException e)
            {
                return TypedResults.NotFound(e.Message);
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getComment")
        .WithTags("Comments")
        .Produces<CommentDto>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

        #endregion

        #region Create Comment
        //One to Many Create Example
        routes.MapPost("/api/comment/{stockId}", async Task<IResult> ([FromRoute]int stockId,[FromBody] CreateCommentDto commentDto,
        ICommentService _service,IStockService _stockService) =>
        {
            try
            {
                if (!await _stockService.StockExists(stockId)){
                    return TypedResults.BadRequest(Messages<Stock>.Does_Not_Exist);
                }
                var comment = await _service.CreateWithStockIdAsync(commentDto, stockId);
                return TypedResults.CreatedAtRoute(comment, "getComment", new { id = comment.Id });
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("addComment")
        .WithTags("Comments")
        .Produces<CommentDto>(StatusCodes.Status201Created)
        .Produces<string>(StatusCodes.Status400BadRequest);
        #endregion

        #region  Update Comment

        routes.MapPut("/api/comment/{id}", async Task<IResult> ([FromRoute] int id, [FromBody] UpdateCommentDto commentDto,
        ICommentService _services) =>
      {
          try
          {
              var comment = await _services.UpdateAsync(id, commentDto);

              return TypedResults.Ok(comment);
          }
          catch (NotFoundException e)
          {
              return TypedResults.NotFound(e.Message);
          }
          catch (Exception e)
          {
              return TypedResults.Problem(e.Message, statusCode: 500);
          }

      })
      .WithName("updateComment")
      .WithTags("Comments")
      .Produces<CommentDto>(StatusCodes.Status200OK)
      .Produces<string>(StatusCodes.Status404NotFound);
        #endregion

        #region Delete Comment
        routes.MapDelete("/api/comment/{id}", async Task<IResult> ([FromRoute] int id, ICommentService _service) =>
        {
            try
            {
                await _service.DeleteAsync(id);
                return TypedResults.NoContent();
            }
            catch (NotFoundException e)
            {
                return TypedResults.NotFound(e.Message);
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("deleteComment")
        .WithTags("Comments")
        .Produces(StatusCodes.Status204NoContent)
        .Produces<string>(StatusCodes.Status404NotFound);
        #endregion
    }
}
