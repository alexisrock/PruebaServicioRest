using AutoMapper;
using Core.Interfaces;


using DataAccess.Interfaces;
using Domain.Common;

using Domain.DTO;
using Domain.Entities;


namespace Core.Repository
{
    public class ProductoService : IProductoService
    {

        private readonly IStoreProcedureRepository repository;

        private readonly IMapper mapper;

        public ProductoService(IStoreProcedureRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        public async Task<List<ProductoResponse>> GetAll()
        {
            var listPruebaSeleccion = await repository.GetAll();
            var list = MapperListesponse(listPruebaSeleccion);
            return list;
        }
        private List<ProductoResponse> MapperListesponse(List<Producto> listPruebaSeleccion)
        {
            List<ProductoResponse> listResponse = new List<ProductoResponse>();

            listPruebaSeleccion.ForEach(c =>
            {
                var Response = mapper.Map<ProductoResponse>(c);
                listResponse.Add(Response);
            });
            return listResponse;
        }
        public async Task<ProductoResponse> GetId(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var pruebaSeleccion = await repository.GetByIdProduct(Id);
                    var response = mapper.Map<ProductoResponse>(pruebaSeleccion);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public async Task<BaseResponse> Create(ProductoRequest pruebaSeleccionRequest)
        {
            var outPut = new BaseResponse();

            try
            {
                if (pruebaSeleccionRequest is not null)
                {

                    var producto = mapper.Map<ProductoAdd>(pruebaSeleccionRequest);
                    await repository.Insert(producto);
                    outPut.Mensaje = "Producto creado con éxito";
                    return outPut;
                }                
                outPut.Mensaje = "Error en el request";
                
            }
            catch (Exception ex)
            {

                outPut.Mensaje = ex.Message;
            }

            return outPut;
        }



        public async Task<BaseResponse> Update(ProductoUpdateRequest pruebaSeleccionUpdateRequest)
        {
            var outPut = new BaseResponse();
            try
            {
                if (pruebaSeleccionUpdateRequest is not null)
                {

                    var pruebaSeleccion = await repository.GetByIdProduct(pruebaSeleccionUpdateRequest.Id);
                    pruebaSeleccion.Description = pruebaSeleccionUpdateRequest.Description;
                    pruebaSeleccion.Name = pruebaSeleccionUpdateRequest.Name;
                    pruebaSeleccion.Stock = pruebaSeleccionUpdateRequest.Stock;
                    pruebaSeleccion.Price = pruebaSeleccionUpdateRequest.Price;
                    await repository.Update(pruebaSeleccion);
                    outPut.Mensaje = "Producto actualizada con éxito";
                }
                outPut.Mensaje = "Error en el request";

            }
            catch (Exception ex)
            {

                outPut.Mensaje = ex.Message;
            }

            return outPut;
        }
        public async Task<BaseResponse> Delete(int id)
        {


            var outPut = new BaseResponse();

            if (id > 0)
            {


                await repository.Delete(id);
                outPut.Mensaje = "Prueba eliminada con éxito";
            }
            else
            {
                outPut.Mensaje = "Error en el request";
            }

            return outPut;

        }

    }
}
