using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface INotificarProblemaService
    {
        void Editar(Notificacao notificarproblema);
        int Inserir(Notificacao notificarproblema);
        Notificacao Obter(int IdNotificacao);
        IEnumerable<Notificacao> ObterPorNome(string nome);
        IEnumerable<Notificacao> ObterTodos();
        void Remover(int IdNotificacao);

    }
}
