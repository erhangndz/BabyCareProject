using BabyCareProject.Dtos.ProductDtos;

namespace BabyCareProject.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task<UpdateProductDto> GetById(string id);
        Task CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(string id);

    }
}
