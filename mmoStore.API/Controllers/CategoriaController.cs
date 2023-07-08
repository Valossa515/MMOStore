using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mmoStore.API.DTOs;
using mmoStore.API.Entities;
using mmoStore.API.Interfaces;

namespace mmoStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var categorias = _categoriaService.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var categorias = _categoriaService.GetById(id);
            if(categorias == null)
                return NotFound();
            return Ok(categorias);
        }
        [HttpPost("adicionar")]
        public IActionResult Add(CategoriaDTO objDto)
        {
            try
            {
                var categoria = new Categoria
                {
                    Nome = objDto.Nome,
                };
                _categoriaService.Add(categoria);
                return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar a categoria: {ex.Message}");
            }
            
        }
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var categoria = _categoriaService.GetById(id);
                if (categoria == null)
                    return NotFound();
                _categoriaService.Delete(categoria);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar a categoria: {ex.Message}");
            }
        }
        [HttpPut("atualizar/{id}")]
        public IActionResult Update(int id, CategoriaDTO objDto)
        {
            try
            {
                var categoria = _categoriaService.GetById(id);
                if( categoria == null)
                    return NotFound();
                categoria.Nome = objDto.Nome;
                _categoriaService.Update(categoria);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar a categoria: {ex.Message}");
            }
        }
    }
}
