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

    public static void MapStockEndpoints(this IEndpointRouteBuilder routes)
    {
        #region Get All Stocks

        routes.MapGet("/api/stocks", async Task<IResult> (IStockService _service) =>
        {
            try
            {
                var stocks = await _service.GetAllAsync();
                return TypedResults.Ok(stocks);

            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getAllStocks")
        .WithTags("Stocks")
        .Produces<List<StockDto>>(StatusCodes.Status200OK);
 
        #endregion
        
        #region Get Stock By ID

        routes.MapGet("/api/stock/{id}", async Task<IResult> ([FromRoute] int id,
        IStockService _service) =>
        {
            try
            {
                var stock = await _service.GetByIdAsync(id);

                return TypedResults.Ok(stock);
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
        .WithName("getStock")
        .WithTags("Stocks")
        .Produces<StockDto>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);
         
        #endregion
        
        #region Create Stock

        routes.MapPost("/api/stock", async Task<IResult> ([FromBody] CreateStockDto stockDto,
        IStockService _service) =>
        {
            try
            {
                var stock = await _service.CreateAsync(stockDto);
                return TypedResults.CreatedAtRoute(stock, "getStock", new { id = stock.Id });
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("addStock")
        .WithTags("Stocks")
        .Produces<StockDto>(StatusCodes.Status201Created);
         
        #endregion

        #region Update Stock

        routes.MapPut("/api/stock/{id}", async Task<IResult> ([FromRoute] int id, [FromBody] UpdateStockDto stockDto,
          IStockService _services) =>
        {
            try
            {
                var stock = await _services.UpdateAsync(id, stockDto);
                
                return TypedResults.Ok(stock);
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
        .WithName("updateStock")
        .WithTags("Stocks")
        .Produces<StockDto>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);
        
        #endregion

        #region Delete Stock

        routes.MapDelete("/api/stock/{id}", async Task<IResult> ([FromRoute] int id, IStockService _service) =>
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
        .WithName("deleteStock")
        .WithTags("Stocks")
        .Produces(StatusCodes.Status204NoContent)
        .Produces<string>(StatusCodes.Status404NotFound);
        
         #endregion
    }
       
}
