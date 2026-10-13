using GestaoAcademica.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Aluno> Alunos => Set<Aluno>();
}
