using Imunobiologico.EntityFramework.Base;
using Imunobiologico.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Imunobiologico.Repositorio.Base
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntidade> DbSet;

        public RepositorioBase(DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntidade>();
        }

        public TEntidade Adicionar(TEntidade entidade)
        {
            AdicionarCore(entidade);
            DbSet.Add(entidade);

            DbContext.SaveChanges();

            return entidade;
        }

        public TEntidade Atualizar(TEntidade entidade)
        {
            AtualizarCore(entidade);
            DbSet.Attach(entidade);
            DbContext.Entry(entidade).State = EntityState.Modified;
            
            DbContext.SaveChanges();

            return entidade;
        }

        public TEntidade Apagar(TEntidade entidade)
        {
            ApagarCore(entidade);
            DbSet.Remove(entidade);
            DbContext.SaveChanges();
            return entidade;
        }

        public virtual TEntidade Obter(int id)
        {
            return DbSet.Find(id);
        }

        public virtual List<TEntidade> Listar()
        {
            return DbSet.ToList();
        }

        protected internal virtual void AdicionarCore(TEntidade entidade) { }
        protected internal virtual void AtualizarCore(TEntidade entidade) { }
        protected internal virtual void ApagarCore(TEntidade entidade) { }
    }
}
