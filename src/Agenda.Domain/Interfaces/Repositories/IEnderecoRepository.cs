using Agenda.Domain.Entities;
using System;
using System.Linq;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IEntradaRepository : IRepository<Endereco>
    {
        IQueryable<Endereco> ObterProdutosPorCodigo(string codigo);
        IQueryable<Endereco> ObterProdutosPorDescricao(string descricao);
        IQueryable<Endereco> ObterProdutosPorQuantidadeMaiorQue(int qtd);
        IQueryable<Endereco> ObterProdutosPorQuantidadeMenorQue(int qtd);
        IQueryable<Endereco> ObterProdutosPorValorUnitarioMaiorQue(decimal valor);
        IQueryable<Endereco> ObterProdutosPorValorUnitarioMenorQue(decimal valor);
        IQueryable<Endereco> ObterProdutosPorValorTotalMaiorQue(decimal valor);
        IQueryable<Endereco> ObterProdutosPorValorTotalMenorQue(decimal valor);
        IQueryable<Endereco> ObterProdutosPorDataEntradaEntre(DateTime dtInicio, DateTime dtFim);
    }
}
