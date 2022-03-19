using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Technical.Evaluation.Domain.Entitites.Usuarios;
using Usuarios.Technical.Evaluation.infrastructure.Context;

namespace Puchage.Technical.Evaluation.infrastructure.Context
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {

        }
        public DbSet<User> _Usuario { get; set; }
        public DbContext Instance => this;


    }
}
