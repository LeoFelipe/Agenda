using System;
using System.Collections.Generic;

namespace Agenda.Application.Interfaces
{
    public interface IAppService<VM> : IDisposable where VM : class
    {
        void Remover(int id);
        VM Adicionar(VM vm);
        VM Atualizar(VM vm);
        VM ObterPorId(int id);
        IEnumerable<VM> ObterTodos();
    }
}
