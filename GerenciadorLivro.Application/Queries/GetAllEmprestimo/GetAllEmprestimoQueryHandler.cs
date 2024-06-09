﻿using GerenciadorLivro.Application.ViewModels;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.GetAllEmpresitmo
{
    public class GetAllEmprestimoQueryHandler : IRequestHandler<GetAllEmprestimoQuery, List<EmprestimoViewModel>>
    {
        private readonly IEmprestimoRepository _repository;
        public GetAllEmprestimoQueryHandler(IEmprestimoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<EmprestimoViewModel>> Handle(GetAllEmprestimoQuery request, CancellationToken cancellationToken)
        {
            var emprestimos = await _repository.GetAllAsync();
            var empresitmoViewModel = emprestimos.Select(e => new EmprestimoViewModel(e.Id, e.Usuario, e.IdLivro, e.Livro, e.DataEmprestimo));

            return empresitmoViewModel.ToList();
        }
    }
}