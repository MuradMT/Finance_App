namespace api.Services;

public class StockService
(IUnitOfWork<Stock,ApplicationDbContext> _unitofwork,IMapper _mapper,IConverter<Stock,UpdateStockDto> _converter)
:BaseService<Stock,ApplicationDbContext,StockDto,CreateStockDto,UpdateStockDto>(_unitofwork,_mapper,_converter),IStockService
{
   
}
