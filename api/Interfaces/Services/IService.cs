namespace api.Interfaces.Services;

public interface IService<TCreateRequestDto,TResponseDto>
 where TCreateRequestDto : ICreateRequestDto 
 where TResponseDto :IResponseDto 

{
    Task<List<TResponseDto>> GetAllAsync();
    Task<TResponseDto?> GetByIdAsync(int id);

    Task<TResponseDto> CreateAsync(TCreateRequestDto createDto);
    Task DeleteAsync(int id);
}
