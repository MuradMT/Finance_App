namespace api.Interfaces.Services;

public interface IService<TCreateRequestDto,TUpdateRequestDto ,TResponseDto>
 where TCreateRequestDto : ICreateRequestDto 
 where TResponseDto :IResponseDto 
 where TUpdateRequestDto : IUpdateRequestDto

{
    Task<List<TResponseDto>> GetAllAsync();
    Task<TResponseDto?> GetByIdAsync(int id);
    Task<TResponseDto> UpdateAsync(int id, TUpdateRequestDto updateDto);

    Task<TResponseDto> CreateAsync(TCreateRequestDto createDto);
    Task DeleteAsync(int id);
}
