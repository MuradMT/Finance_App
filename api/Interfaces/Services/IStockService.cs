﻿namespace api.Interfaces.Services;

public interface IStockService:IService<CreateStockDto,UpdateStockDto, StockDto>
{
    Task<List<StockDto>> GetWithCommentsAllAsync();
    Task<StockDto?> GetWithCommentsByIdAsync(int id);
    Task<bool> StockExists(int id);
}
