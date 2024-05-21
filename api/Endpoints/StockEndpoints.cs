using api.Data;
using api.Dtos.Stock.Request;
using api.Dtos.Stock.Response;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        routes.MapGet("/api/stocks", async Task<IResult> (IStockRepository _repository, IMapper _mapper) =>
        {
            try
            {
                var stocks = await _repository.GetAllAsync();
                return TypedResults.Ok(_mapper.Map<List<StockDto>>(stocks));

            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getAllStocks")
        .WithTags("Stocks")
        .Produces<List<StockDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/stock/{id}", async Task<Results<Ok<StockDto>, NotFound, ProblemHttpResult>> ([FromRoute] int id,
        IStockRepository _repository, IMapper _mapper) =>
        {
            try
            {
                var stock = await _repository.GetByIdAsync(id);

                return stock is not null ? TypedResults.Ok(_mapper.Map<StockDto>(stock)) : TypedResults.NotFound();
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getStock")
        .WithTags("Stocks");

        routes.MapPost("/api/stock", async Task<IResult> ([FromBody] CreateStockDto stockDto,
        IStockRepository _repository, IMapper _mapper) =>
        {
            try
            {
                var stock = _mapper.Map<Stock>(stockDto);
                await _repository.AddAsync(stock);
                return TypedResults.CreatedAtRoute(_mapper.Map<StockDto>(stock), "getStock", new { id = stock.Id });
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("addStock")
        .WithTags("Stocks")
        .Produces<StockDto>(StatusCodes.Status201Created);

        routes.MapPut("/api/stock/{id}", async Task<IResult> ([FromRoute] int id, [FromBody] UpdateStockDto stockDto,
          IStockRepository _repository, IMapper _mapper) =>
        {
            try
            {
                var stock = await _repository.GetByIdAsync(id);
                if (stock is null)
                {
                    return TypedResults.NotFound();
                }
                stock.Symbol = stockDto.Symbol;
                stock.CompanyName = stockDto.CompanyName;
                stock.Purchase = stockDto.Purchase;
                stock.LastDiv = stockDto.LastDiv;
                stock.Industry = stockDto.Industry;
                stock.MarketCap = stockDto.MarketCap;
                await _repository.UpdateAsync(stock);
                return TypedResults.Ok(_mapper.Map<StockDto>(stock));
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }

        })
        .WithName("updateStock")
        .WithTags("Stocks")
        .Produces<StockDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapDelete("/api/stock/{id}", async Task<IResult> ([FromRoute] int id, IStockRepository _repository) =>
        {
            try
            {
                var stock = await _repository.GetByIdAsync(id);
                if (stock is null)
                {
                    return TypedResults.NotFound();
                }
                await _repository.DeleteAsync(stock);
                return TypedResults.NoContent();
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("deleteStock")
        .WithTags("Stocks")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

    }
}
