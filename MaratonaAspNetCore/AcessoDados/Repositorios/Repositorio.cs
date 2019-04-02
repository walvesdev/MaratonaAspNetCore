using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBase.AcessoDados.Repositorios
{
    public abstract class Repositorio<T, TId> : IRepositorio<T, TId>, IDisposable where T : class
    {
        public ApplicationContext context;
        public DbSet<T> dbset;

        public Repositorio(ApplicationContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public void Atualizar(T entidade)
        {
            context.Update(entidade);
        }

        public void Excluir(T entidade)
        {
            context.Remove(entidade);
        }

        public void Inserir(T entidade)
        {
            context.Set<T>().Add(entidade);
        }

        public void SalvarAlteracoes()
        {
            context.SaveChanges();
        }

        public T SelecionarPorId(TId id)
        {
            return context.Set<T>().Find(id);
        }

        public Task<List<T>> SelecionarTodosAsync()
        {
            DbSet<T> dbset = context.Set<T>();
            var result =  dbset.ToListAsync();

            return Task.Run(()=> {
                return result;
            });
        }
        public List<T> SelecionarTodos()
        {
            DbSet<T> dbset = context.Set<T>();
            var result = dbset.ToList();
            
                return result;
           
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
