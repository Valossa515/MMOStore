using Microsoft.EntityFrameworkCore;
using mmoStore.API.Entities;
using mmoStore.API.Interfaces;
using mmoStore.API.Persistence;

namespace mmoStore.API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MmoStoreDbContext _dbContext;

        public CategoriaRepository(MmoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<Categoria> GetAll()
        {
            return _dbContext.Categorias.ToList();
        }

        public Categoria GetById(int id) {
            return _dbContext.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Categoria categoria)
        {
            _dbContext.Categorias.Add(categoria);
            _dbContext.SaveChanges();
        }
        public void Delete(Categoria categoria)
        {
            _dbContext.Categorias.Remove(categoria);
            _dbContext.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _dbContext.SaveChanges();
        }
    }
}
