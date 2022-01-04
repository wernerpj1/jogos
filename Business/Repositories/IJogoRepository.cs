using Jogos.Business.Entities;
using System.Collections.Generic;


namespace Jogos.Business.Repositories
{
    public interface IJogoRepository
    {
        void AddGame(Jogo jogo);
        void Commit();
        void UpdateGame(Jogo jogo);
        IList<Jogo> GetByUser(int id);
        IList<Jogo> GetAll();
        Jogo GetById(int id);
        IList<Jogo> GetExclude();
    }
}
