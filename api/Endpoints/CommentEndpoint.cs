

namespace api.Endpoints;

public static class CommentEndpoint
{

    public static void MapCommentEndpoints(this IEndpointRouteBuilder app)
    {
        var routes = app.MapGroup("/api/comment").WithOpenApi();

        #region  Get All Comments

        routes.MapGet("",async Task<IResult> (ICommentService _service) =>
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
        .WithSummary(ConstantMessages.GetAllComments)
        .Produces<List<CommentDto>>(StatusCodes.Status200OK);

        #endregion

        #region Get Comment By ID

        routes.MapGet("/{id:int}", async Task<IResult> ([FromRoute] int id,
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
        .WithSummary(ConstantMessages.GetCommentById)
        .Produces<CommentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        #endregion

        #region Create Comment
        //One to Many Create Example
        routes.MapPost("/{stockId:int}", async Task<IResult> ([FromRoute]int stockId,[FromBody] CreateCommentDto commentDto,
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
        .WithSummary(ConstantMessages.CreateComment)
        .WithRequestValidation<CreateCommentDto>()
        .Produces<CommentDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);
        #endregion

        #region  Update Comment

        routes.MapPut("/{id:int}", async Task<IResult> ([FromRoute] int id, [FromBody] UpdateCommentDto commentDto,
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
      .WithSummary(ConstantMessages.UpdateComment)
      .WithRequestValidation<UpdateCommentDto>()
      .Produces<CommentDto>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status400BadRequest)
      .Produces(StatusCodes.Status404NotFound);
        #endregion

        #region Delete Comment
        routes.MapDelete("/{id:int}", async Task<IResult> ([FromRoute] int id, ICommentService _service) =>
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
        .WithSummary(ConstantMessages.DeleteComment)
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
        #endregion
    }
}
