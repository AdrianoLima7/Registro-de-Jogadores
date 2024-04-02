using RegistroDeJogadores.Context;

namespace RegistroDeJogadores.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClubeRepository? _clubeRepository;
        private IJogadorRepository? _jogadorRepository;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IClubeRepository ClubeRepository => _clubeRepository = _clubeRepository ?? new ClubeRepository(_context);

        public IJogadorRepository JogadorRepository => _jogadorRepository = _jogadorRepository ?? new JogadorRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose() 
        { 
            _context?.Dispose();
        }
    }
}
