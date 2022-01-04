using Jogos.Business.Entities;
using Jogos.Business.Repositories;
using Microsoft.EntityFrameworkCore;
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
            return _context.Jogo.Where(w => w.IsExclude == false).ToList();
        }

        public Jogo GetById(int id)
        {
            return _context.Jogo.FirstOrDefault(u => u.Id == id);
        }

        public IList<Jogo> GetByUser(int id)
        {
            return _context.Jogo.Include(i => i.User).Where(w => w.IdUser == id).ToList();
        }

        public IList<Jogo> GetExclude()
        {
            return _context.Jogo.Where(w => w.IsExclude == true).ToList();
        }

        public void UpdateGame(Jogo jogo)
        {
            _context.Update(jogo);
        }
    }
}
