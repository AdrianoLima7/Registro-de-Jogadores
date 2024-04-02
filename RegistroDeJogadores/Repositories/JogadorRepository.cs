using Microsoft.EntityFrameworkCore;
using RegistroDeJogadores.Context;
using RegistroDeJogadores.Models;

namespace RegistroDeJogadores.Repositories;

public class JogadorRepository : Repository<Jogador> ,IJogadorRepository
{
    public JogadorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Jogador>> GetJogadoresPorClubeAsync(int id)
    {
        var jogadores = await GetAllAsync();
        return jogadores.Where(c => c.ClubeId == id);
    }
}