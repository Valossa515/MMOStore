﻿using mmoStore.API.Entities;

namespace mmoStore.API.Interfaces
{
    public interface ICategoriaService
    {
        public List<Categoria> GetAll();
        public Categoria GetById(int id);
        public void Add(Categoria categoria);
        public void Delete(Categoria categoria);
        public void Update(Categoria categoria);
    }
}
