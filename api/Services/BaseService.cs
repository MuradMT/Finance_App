

namespace api.Services;

public class BaseService<TCreateRequestDto, TResponseDto, TEntity, TUpdateRequestDto>
(IRepository<TEntity> _repository, IMapper _mapper, IConverter<TEntity, TUpdateRequestDto> _converter)
: IService<TCreateRequestDto,TUpdateRequestDto, TResponseDto>
 where TCreateRequestDto : ICreateRequestDto
 where TResponseDto : IResponseDto
 where TEntity : class, IEntity
 where TUpdateRequestDto : IUpdateRequestDto
{

    public async Task<TResponseDto> CreateAsync(TCreateRequestDto createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        await _repository.AddAsync(entity);
        return _mapper.Map<TResponseDto>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new NotFoundException(Messages<TEntity>.NotFound);
        }
        await _repository.DeleteAsync(entity);
    }

    public async Task<List<TResponseDto>> GetAllAsync()
    {
        var entitys = await _repository.GetAllAsync();
        return _mapper.Map<List<TResponseDto>>(entitys);
    }

    public async Task<TResponseDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is not null ? _mapper.Map<TResponseDto>(entity) : throw new NotFoundException(Messages<TEntity>.NotFound);
    }

    public async Task<TResponseDto> UpdateAsync(int id, TUpdateRequestDto updateDto)
    {
       var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new NotFoundException(Messages<TEntity>.NotFound);
        }
        _converter.Convert(entity, updateDto);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<TResponseDto>(entity);
    }
    
}
