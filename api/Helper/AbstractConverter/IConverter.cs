namespace api.Helper.AbstractConverter;

public interface IConverter<TEntity,TDto>
{
    void Convert(TEntity entity,TDto dto);
}
