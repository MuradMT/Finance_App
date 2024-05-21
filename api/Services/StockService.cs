namespace api.Services;

public class StockService
(IStockRepository _repository,IMapper _mapper,IConverter<Stock,UpdateStockDto> _converter)
:BaseService<CreateStockDto,StockDto,Stock,UpdateStockDto>(_repository,_mapper,_converter),IStockService
{
   
}
