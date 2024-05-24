

using api.Endpoints.APIResponse;

namespace api.Endpoints;

public static class CommentEndpoints
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
                return TypedResults.Ok(new DataResponse<List<CommentDto>>(StatusCodes.Status200OK,Messages<Comment>.GetAll,comments));
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getAllComments")
        .WithTags("Comments")
        .WithSummary(Messages<Comment>.GetAll)
        .Produces<DataResponse<List<CommentDto>>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError);

        #endregion

        #region Get Comment By ID

        routes.MapGet("/{id:int}", async Task<IResult> ([FromRoute] int id,
        ICommentService _service) =>
        {
            try
            {
                var comment = await _service.GetByIdAsync(id);

                return TypedResults.Ok(new DataResponse<CommentDto>(StatusCodes.Status200OK,Messages<Comment>.GetById,comment));
            }
            catch (NotFoundException e)
            {
                return TypedResults.NotFound(new Response(StatusCodes.Status404NotFound,e.Message));
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getComment")
        .WithTags("Comments")
        .WithSummary(Messages<Comment>.GetById)
        .Produces<DataResponse<CommentDto>>(StatusCodes.Status200OK)
        .Produces<Response>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);

        #endregion

        #region Create Comment
        //One to Many Create Example
        routes.MapPost("/{stockId:int}", async Task<IResult> ([FromRoute]int stockId,[FromBody] CreateCommentDto commentDto,
        ICommentService _service,IStockService _stockService) =>
        {
            try
            {
                if (!await _stockService.StockExists(stockId)){
                    return TypedResults.BadRequest(new Response(StatusCodes.Status400BadRequest,Messages<Stock>.Does_Not_Exist));
                }
                var comment = await _service.CreateWithStockIdAsync(commentDto, stockId);
                return TypedResults.CreatedAtRoute(new DataResponse<CommentDto>(StatusCodes.Status201Created,Messages<Comment>.Create,comment), "getComment", new { id = comment.Id });
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("addComment")
        .WithTags("Comments")
        .WithSummary(Messages<Comment>.Create)
        .WithRequestValidation<CreateCommentDto>()
        .Produces<DataResponse<CommentDto>>(StatusCodes.Status201Created)
        .Produces<Response>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError);
        #endregion

        #region  Update Comment

        routes.MapPut("/{id:int}", async Task<IResult> ([FromRoute] int id, [FromBody] UpdateCommentDto commentDto,
        ICommentService _services) =>
      {
          try
          {
              var comment = await _services.UpdateAsync(id, commentDto);

              return TypedResults.Ok(new DataResponse<CommentDto>(StatusCodes.Status200OK,Messages<Comment>.Update,comment));
          }
          catch (NotFoundException e)
          {
              return TypedResults.NotFound(new Response(StatusCodes.Status404NotFound,e.Message));
          }
          catch (Exception e)
          {
              return TypedResults.Problem(e.Message, statusCode: 500);
          }

      })
      .WithName("updateComment")
      .WithTags("Comments")
      .WithSummary(Messages<Comment>.Update)
      .WithRequestValidation<UpdateCommentDto>()
      .Produces<DataResponse<CommentDto>>(StatusCodes.Status200OK)
      .Produces<Response>(StatusCodes.Status400BadRequest)
      .Produces<Response>(StatusCodes.Status404NotFound)
      .Produces(StatusCodes.Status500InternalServerError);
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
                return TypedResults.NotFound(new Response(StatusCodes.Status404NotFound,e.Message));
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("deleteComment")
        .WithTags("Comments")
        .WithSummary(Messages<Comment>.Delete)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<Response>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);
        #endregion
    }
}
