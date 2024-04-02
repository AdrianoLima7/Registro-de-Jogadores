using Microsoft.EntityFrameworkCore;
using RegistroDeJogadores.Context;
using RegistroDeJogadores.Models;

namespace RegistroDeJogadores.Repositories;

public class ClubeRepository : Repository<Clube>, IClubeRepository
{
    public ClubeRepository(AppDbContext context) : base(context)
    {
    }
}
