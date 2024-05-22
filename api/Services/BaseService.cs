

namespace api.Services;

public class BaseService<TEntity,TContext, TResponseDto,TCreateRequestDto, TUpdateRequestDto>
(IUnitOfWork<TEntity,TContext> _unitofwork, IMapper _mapper, IConverter<TEntity, TUpdateRequestDto> _converter)
: IService<TCreateRequestDto, TUpdateRequestDto, TResponseDto>
 where TEntity : class, IEntity
 where TContext : DbContext
 where TResponseDto : IResponseDto
 where TCreateRequestDto : ICreateRequestDto
 where TUpdateRequestDto : IUpdateRequestDto
{

    public async Task<TResponseDto> CreateAsync(TCreateRequestDto createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        await _unitofwork.Repository.AddAsync(entity);
        return _mapper.Map<TResponseDto>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitofwork.Repository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new NotFoundException(Messages<TEntity>.NotFound);
        }
        await _unitofwork.Repository.DeleteAsync(entity);
    }

    public async Task<List<TResponseDto>> GetAllAsync()
    {
        var entitys = await _unitofwork.Repository.GetAllAsync();
        return _mapper.Map<List<TResponseDto>>(entitys);
    }

    public async Task<TResponseDto?> GetByIdAsync(int id)
    {
        var entity = await _unitofwork.Repository.GetByIdAsync(id);
        return entity is not null ? _mapper.Map<TResponseDto>(entity) : throw new NotFoundException(Messages<TEntity>.NotFound);
    }

    public async Task<TResponseDto> UpdateAsync(int id, TUpdateRequestDto updateDto)
    {
        var entity = await _unitofwork.Repository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new NotFoundException(Messages<TEntity>.NotFound);
        }
        _converter.Convert(entity, updateDto);
        await _unitofwork.Repository.UpdateAsync(entity);
        return _mapper.Map<TResponseDto>(entity);
    }

}
