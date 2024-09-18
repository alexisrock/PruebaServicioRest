using Domain.DTO;
using Domain.Entities;

namespace Core.Profile
{
    public class PruebaSeleccionProfile : AutoMapper.Profile
    {

        public PruebaSeleccionProfile() 
        {

            CreateMap<Producto, ProductoResponse>()
             .ReverseMap();

            CreateMap<ProductoAdd, ProductoRequest>()
            .ReverseMap();


        }
    }
}
