using Agenda.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Interfaces.Services
{
    public interface IEntradaService : IService<Endereco>
    {
        IEnumerable<Endereco> ObterProdutosPorCodigo(string codigo);
        IEnumerable<Endereco> ObterProdutosPorDescricao(string descricao);
        IEnumerable<Endereco> ObterProdutosPorQuantidadeMaiorQue(int qtd);
        IEnumerable<Endereco> ObterProdutosPorQuantidadeMenorQue(int qtd);
        IEnumerable<Endereco> ObterProdutosPorValorUnitarioMaiorQue(decimal valor);
        IEnumerable<Endereco> ObterProdutosPorValorUnitarioMenorQue(decimal valor);
        IEnumerable<Endereco> ObterProdutosPorValorTotalMaiorQue(decimal valor);
        IEnumerable<Endereco> ObterProdutosPorValorTotalMenorQue(decimal valor);
        IEnumerable<Endereco> ObterProdutosPorDataEntradaEntre(DateTime dtInicio, DateTime dtFim);
    }
}
