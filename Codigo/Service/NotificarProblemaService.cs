using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NotificarProblemaService : INotificarProblemaService
    {
        private readonly recolhakiContext _context;

        public NotificarProblemaService(recolhakiContext context)
        {
            _context = context;
        }

        public void Editar(Notificacao notificarproblema)
        {
            _context.Update(notificarproblema);
            _context.SaveChanges();
        }

        public int Inserir(Notificacao notificarproblema)
        {
            _context.Add(notificarproblema);
            _context.SaveChanges();
            return notificarproblema.IdNotificacao;
        }

        public Notificacao Obter(int IdNotificacao)
        {
            return _context.Notificacao.Find(IdNotificacao);
        }

        public IEnumerable<Notificacao> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notificacao> ObterTodos()
        {
            return _context.Notificacao;
        }

        public void Remover(int IdNotificacao)
        {
            var notificarProblema = _context.Notificacao.Find(IdNotificacao);
            _context.Remove(notificarProblema);
            _context.SaveChanges();
        }
    }
}
