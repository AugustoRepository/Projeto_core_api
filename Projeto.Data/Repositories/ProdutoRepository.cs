using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Projeto.Data.Contexts;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private DataContext context;

        public ProdutoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Inserir(Produto obj)
        {
            context.Entry(obj).State = EntityState.Added;//grava
            context.SaveChanges();
        }

        public void Alterar(Produto obj)
        {
            context.Entry(obj).State = EntityState.Modified;//att
            context.SaveChanges();
        }

        public void Excluir(Produto obj)
        {
            context.Entry(obj).State = EntityState.Deleted;//excluir
            context.SaveChanges();
        }

        public List<Produto> ConsultarTodos()
        {
            return context.Set<Produto>().ToList();
        }

        public Produto ConsultarPorId(int id)
        {
            return context.Set<Produto>().Find(id);
        }
    }
}
