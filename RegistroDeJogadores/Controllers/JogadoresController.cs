using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroDeJogadores.Context;
using RegistroDeJogadores.Models;
using RegistroDeJogadores.Repositories;

namespace RegistroDeJogadores.Controllers;

[Route("[controller]")]
[ApiController]
public class JogadoresController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public JogadoresController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    /// <summary>
    /// Obter todos jogadores de um Clube
    /// </summary>
    /// <returns>Uma lista de jogadores de um Clube</returns>
    [HttpGet("Clubes/{id}")]
    public async Task<ActionResult<IEnumerable<Jogador>>> GetJogadorePorClube(int id)
    {
        var jogadores = await _uof.JogadorRepository.GetJogadoresPorClubeAsync(id);
        if (jogadores is null)
        {
            return NotFound("Nenhum jogador encontrado...");
        }

        return Ok(jogadores);
    }

    /// <summary>
    /// Obter todos os jogadores 
    /// </summary>
    /// <returns>Uma lista de todos jogadores </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Jogador>>> Get()
    {
        var jogadores = await _uof.JogadorRepository.GetAllAsync();
        if (jogadores is null)
        {
            return NotFound("Não jogador foi registrado...");
        }
        return Ok(jogadores);
    }

    /// <summary>
    /// Obter um Jogador atraves do Id
    /// </summary>
    /// <returns>Um Jogador</returns>
    [HttpGet("id:int", Name = "ObterJogador")]
    public ActionResult<Jogador> GetJogador(int id)
    {
        var jogador = _uof.JogadorRepository.Get(j => j.JogadorId == id);
        if (jogador is null)
        {
            return NotFound("Esse jogador não existe...");
        }

        return Ok(jogador);
    }

    /// <summary>
    /// Adiciona um novo Jogador ao sistema
    /// </summary>
    /// <returns>Um novo Jogador</returns>
    [HttpPost]
    public ActionResult Post(Jogador jogador)
    {
        if (jogador is null)
        {
            return BadRequest("Jogador inválido...");
        }
        var jogadorCriado = _uof.JogadorRepository.Create(jogador);
        _uof.Commit();
        
        return new CreatedAtRouteResult("ObterJogador", new { id = jogadorCriado.JogadorId } , jogadorCriado);
    }

    /// <summary>
    /// Atualiza informações de um Jogador
    /// </summary>
    /// <returns>Um Jogador com dados atualizados</returns>
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Jogador jogador)
    {
        if (id != jogador.JogadorId)
        {
            return BadRequest("Jogador não encontrado...");
        }
        var jogadorAtualizado = _uof.JogadorRepository.Update(jogador);
        _uof.Commit();

        return Ok(jogadorAtualizado);
    }

    /// <summary>
    /// Apaga um jogador do sistema
    /// </summary>
    /// <returns>Um jogador removido</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var jogador = await _uof.JogadorRepository.Get(j => j.JogadorId ==id);
        if (jogador is null)
        {
            return NotFound("Jogador não encontrado...");
        }
        var jogadorExcluido = _uof.JogadorRepository.Delete(jogador);
        _uof.Commit();

        return Ok(jogadorExcluido);
    }
}
