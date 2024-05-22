namespace api.Helpers.AbstractConverter;

public interface IConverter<TEntity, TDto>
where TEntity : class, IEntity
where TDto : class, IUpdateRequestDto
{
    void Convert(TEntity entity, TDto dto);
}
