using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Technical.Evaluation.Domain.Entitites.Usuarios;

namespace Usuarios.Technical.Evaluation.infrastructure.Context
{
    public interface IContextDatabase
    {
        public DbSet<User> _Usuario { get; set; }
        int SaveChanges();
    }
}
