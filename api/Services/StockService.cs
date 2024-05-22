
namespace api.Services;

public class StockService
(IUnitOfWork<Stock, ApplicationDbContext> _unitofwork, IMapper _mapper, IConverter<Stock, UpdateStockDto> _converter,IStockRepository _repository)
: BaseService<Stock, ApplicationDbContext, StockDto, CreateStockDto, UpdateStockDto>(_unitofwork, _mapper, _converter), IStockService
{
    public async Task<List<StockDto>> GetWithCommentsAllAsync()
    {
        var stocks= await _repository.GetAllWithCommentsAsync();
        return _mapper.Map<List<StockDto>>(stocks);
    }

    public async Task<StockDto?> GetWithCommentsByIdAsync(int id)
    {
        var stock = _repository.GetWithCommentsByIdAsync(id);
        return stock is not null? _mapper.Map<StockDto>(stock) : throw new NotFoundException(Messages<Stock>.NotFound);
    }
}
