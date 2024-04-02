using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroDeJogadores.Context;
using RegistroDeJogadores.DTOs;
using RegistroDeJogadores.DTOs.Mappings;
using RegistroDeJogadores.Models;
using RegistroDeJogadores.Repositories;

namespace RegistroDeJogadores.Controllers;

[Route("[controller]")]
[ApiController]
public class ClubesController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public ClubesController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClubeDTO>>> Get()
    {
        var clubes = await _uof.ClubeRepository.GetAllAsync();
        if (clubes is null)
        {
            return NotFound("Nenhum clube foi registrado...");
        }

        var clubesDto = clubes.ToClubeDTOList();
        
        return Ok(clubesDto);
    }

    [HttpGet("id:int", Name = "ObterClube")]
    public async Task<ActionResult<ClubeDTO>> GetId(int id) 
    {
        var clube = await _uof.ClubeRepository.Get(c => c.ClubeId == id);
        if (clube is null) 
        { 
            return NotFound("Esse Clube não existe...");
        }

        var clubeDto = clube.ToClubeDTO();

        return Ok(clubeDto);
    }

    [HttpPost]
    public ActionResult<ClubeDTO> Post(ClubeDTO clubeDto)
    {
        if (clubeDto is null)
        {
            return BadRequest("Clube inválido...");
        }

        var clube = clubeDto.ToClube();

        var novoClube = _uof.ClubeRepository.Create(clube);
        _uof.Commit();

        var novoClubeDto = novoClube.ToClubeDTO();

        return new CreatedAtRouteResult("ObterClube", new { id = novoClubeDto.ClubeId }, novoClubeDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ClubeDTO> Put(int id, ClubeDTO clubeDto)
    {
        if (id != clubeDto.ClubeId)
        {
            return BadRequest("Clube não encontrado...");
        }

        var clube = clubeDto.ToClube();

        var clubeAtualizado =_uof.ClubeRepository.Update(clube);
        _uof.Commit();

        var clubeAtualizadoDto = clubeAtualizado.ToClubeDTO();

        return Ok(clubeAtualizadoDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ClubeDTO>> Delete(int id)
    {
        var clube = await _uof.ClubeRepository.Get(c => c.ClubeId == id);
        if (clube is null)
        {
            return NotFound("Esse clube não existe...");
        }
        var clubeExcluido = _uof.ClubeRepository.Delete(clube);
        _uof.Commit();

        var clubeExcluidoDto = clube.ToClubeDTO();

        return Ok(clubeExcluidoDto);
    }

}
