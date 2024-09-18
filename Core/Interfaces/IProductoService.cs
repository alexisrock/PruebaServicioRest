using Domain.Common;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductoService
    {


        Task<List<ProductoResponse>> GetAll();
        Task<ProductoResponse> GetId(int Id);
        
        Task<BaseResponse> Create(ProductoRequest pruebaSeleccionRequest);
        Task<BaseResponse> Update(ProductoUpdateRequest pruebaSeleccionUpdateRequest);
        Task<BaseResponse> Delete(int id);
    }
}
