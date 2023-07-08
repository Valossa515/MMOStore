using mmoStore.API.Entities;
using mmoStore.API.Interfaces;

namespace mmoStore.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<Categoria> GetAll()
        {
            return _categoriaRepository.GetAll();
        }

        public Categoria GetById(int id) {
            return _categoriaRepository.GetById(id);
        }
        public void Add(Categoria categoria)
        {
            _categoriaRepository.Add(categoria);
        }

    }
}
