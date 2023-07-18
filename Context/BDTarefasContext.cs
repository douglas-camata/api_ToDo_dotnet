using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_API_ToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace dio_API_ToDo.Context
{
    public class BDTarefasContext : DbContext
    {
        public BDTarefasContext(DbContextOptions<BDTarefasContext> options) : base(options)
        {                        
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}