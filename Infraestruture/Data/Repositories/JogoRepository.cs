using Jogos.Business.Entities;
using Jogos.Business.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Jogos.Infraestruture.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogoDbContext _context;

        public JogoRepository(JogoDbContext context)
        {
            _context = context;
        }

        public void AddGame(Jogo jogo)
        {
            _context.Jogo.Add(jogo);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Jogo> GetAll()
        {
            return _context.Jogo.ToList();
        }

        public IList<Jogo> GetByUser(int id)
        {
            return _context.Jogo.Where(w => w.IdUser == id).ToList();
        }
    }
}
