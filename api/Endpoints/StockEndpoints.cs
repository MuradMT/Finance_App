

using api.Endpoints.APIResponse;

namespace api.Endpoints;

#region History of async/await
//These keywords firstly introduced by c#
#endregion
#region Reason why remove and update do not have async functionality
//The reason why Delete() and Update() does not allow await is:
//- It does not involve any immediate database interaction when called, merely a state change in memory
//- does not involve waiting and is a quick in-memory operation, 
//making it asynchronous would not provide any benefits and could even lead to less efficient resource utilization.
#endregion

public static class StockEndpoints
{

    public static void MapStockEndpoints(this IEndpointRouteBuilder app)
    {
        var routes = app.MapGroup("/api/stocks").WithOpenApi();
        #region Get All Stocks

        routes.MapGet("", async Task<IResult> (
             [FromQuery] string? symbol,
             [FromQuery] string? companyName,
             [FromQuery] string? sortBy,
             [FromQuery] bool? isDescending,
             [FromQuery] int? page,
             [FromQuery] int? pageSize,
             IStockService _service) =>
        {
            try
            {
                var stocks = await _service.GetWithCommentsAllAsync(new StockQuery(symbol, companyName, sortBy, isDescending??false,page??1,pageSize??10));
                return TypedResults.Ok(new DataResponse<List<StockDto>>(StatusCodes.Status200OK,Messages<Stock>.GetAll, stocks));

            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message,statusCode:500);;
            }
        })
        .WithName("getAllStocks")
        .WithTags("Stocks")
        .WithSummary(Messages<Stock>.GetAll)
        .Produces<DataResponse<List<StockDto>>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError);

        #endregion

        #region Get Stock By ID

        routes.MapGet("/{id:int}", async Task<IResult> ([FromRoute] int id,
        IStockService _service) =>
        {
            try
            {
                var stock = await _service.GetWithCommentsByIdAsync(id);

                return TypedResults.Ok(new DataResponse<StockDto>(StatusCodes.Status200OK,Messages<Stock>.GetById,stock));
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
        .WithName("getStock")
        .WithTags("Stocks")
        .WithSummary(Messages<Stock>.GetById)
        .Produces<DataResponse<StockDto>>(StatusCodes.Status200OK)
        .Produces<Response>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);

        #endregion

        #region Create Stock

        routes.MapPost("", async Task<IResult> ([FromBody] CreateStockDto stockDto,
        IStockService _service) =>
        {
            try
            {
                var stock = await _service.CreateAsync(stockDto);
                return TypedResults.CreatedAtRoute(new DataResponse<StockDto>(StatusCodes.Status201Created,Messages<Stock>.Create,stock), "getStock", new { id = stock.Id });
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("addStock")
        .WithTags("Stocks")
        .WithSummary(Messages<Stock>.Create)
        .WithRequestValidation<CreateStockDto>()
        .Produces<DataResponse<StockDto>>(StatusCodes.Status201Created)
        .Produces<Response>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError);

        #endregion

        #region Update Stock

        routes.MapPut("/{id:int}", async Task<IResult> ([FromRoute] int id, [FromBody] UpdateStockDto stockDto,
          IStockService _services) =>
        {
            try
            {
                var stock = await _services.UpdateAsync(id, stockDto);

                return TypedResults.Ok(new DataResponse<StockDto>(StatusCodes.Status200OK,Messages<Stock>.Update,stock));
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
        .WithName("updateStock")
        .WithTags("Stocks")
        .WithSummary(Messages<Stock>.Update)
        .WithRequestValidation<UpdateStockDto>()
        .Produces<DataResponse<StockDto>>(StatusCodes.Status200OK)
        .Produces<Response>(StatusCodes.Status400BadRequest)
        .Produces<Response>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);

        #endregion

        #region Delete Stock

        routes.MapDelete("/{id:int}", async Task<IResult> ([FromRoute] int id, IStockService _service) =>
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
        .WithName("deleteStock")
        .WithTags("Stocks")
        .WithSummary(Messages<Stock>.Delete)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<Response>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);

        #endregion
    }

}
