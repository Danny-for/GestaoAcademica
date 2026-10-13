using GestaoAcademica.Api.Data;
using GestaoAcademica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly AppDbContext _context;

    public AlunosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Alunos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> ListarTodos()
    {
        var alunos = await _context.Alunos
            .AsNoTracking()
            .OrderBy(aluno => aluno.Id)
            .ToListAsync();

        return Ok(alunos);
    }

    // GET: api/Alunos/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Aluno>> BuscarPorId(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno is null)
            return NotFound(new { mensagem = $"Aluno com ID {id} não encontrado." });

        return Ok(aluno);
    }

    // POST: api/Alunos
    [HttpPost]
    public async Task<ActionResult<Aluno>> Criar([FromBody] Aluno aluno)
    {
        aluno.Id = 0;
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = aluno.Id }, aluno);
    }

    // PUT: api/Alunos/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Aluno dados)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno is null)
            return NotFound(new { mensagem = $"Aluno com ID {id} não encontrado." });

        aluno.Nome = dados.Nome;
        aluno.Email = dados.Email;
        aluno.Curso = dados.Curso;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Alunos/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno is null)
            return NotFound(new { mensagem = $"Aluno com ID {id} não encontrado." });

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
