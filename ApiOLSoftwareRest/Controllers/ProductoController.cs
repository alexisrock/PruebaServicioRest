using Core.Interfaces;
using Core.Repository;
using Domain.Common;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOLSoftwareRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductoController : ControllerBase
    {



        private readonly IProductoService _pruebaSeleccionService;

        public ProductoController(IProductoService pruebaSeleccionService)
        {
            _pruebaSeleccionService = pruebaSeleccionService;
        }




        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listproducto = await _pruebaSeleccionService.GetAll();
                return Ok(listproducto);
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [HttpGet, Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var producto = await _pruebaSeleccionService.GetId(id);
                if (producto is not null)
                    return Ok(producto);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        

        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductoRequest pruebaSeleccionRequest)
        {
            try
            {
                var result = await _pruebaSeleccionService.Create(pruebaSeleccionRequest);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }



        [HttpPut, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] ProductoUpdateRequest pruebaSeleccionUpdateRequest)
        {
            try
            {
                var result = await _pruebaSeleccionService.Update(pruebaSeleccionUpdateRequest);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [HttpDelete, Route("[action]/{id}")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _pruebaSeleccionService.Delete(id);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
