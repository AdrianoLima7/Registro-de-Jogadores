namespace RegistroDeJogadores.Repositories;

public interface IUnitOfWork
{
    IClubeRepository ClubeRepository { get; }

    IJogadorRepository JogadorRepository { get; }

    void Commit();
}
