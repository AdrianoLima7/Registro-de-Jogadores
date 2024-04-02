using RegistroDeJogadores.Models;

namespace RegistroDeJogadores.Repositories;

public interface IJogadorRepository : IRepository<Jogador>
{
    Task<IEnumerable<Jogador>> GetJogadoresPorClubeAsync(int id);
}
