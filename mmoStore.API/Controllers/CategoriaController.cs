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
        [HttpPost]
        public IActionResult Add(CategoriaDTO objDto)
        {
            var categoria = new Categoria
            {
                Nome = objDto.Nome,
            };
            _categoriaService.Add(categoria);
            return CreatedAtAction(nameof(GetById), new {id = categoria.Id}, categoria);
        }
    }
}
