using Microsoft.Extensions.Logging;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Categoria;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Mappers;
using PedidoFacil.Domain.Interfaces;
using CategoriaModel = PedidoFacil.Domain.Models.Categoria;

namespace PedidoFacil.Application.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly ILogger<CategoriaService> _logger;

        public CategoriaService(ICategoriaRepository repository, ILogger<CategoriaService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApiResposta<CategoriaRespostaDTO>> CadastrarCategoria(CriarCategoriaDTO dto)
        {
            var encontrarCategoriaNome = await _repository.EncontrarCategoriaPorNome(dto.Nome);
            var encontrarCategoriaOrdem = await _repository.EncontrarCategoriaPorOrdem(dto.Ordem);

            if (encontrarCategoriaNome is not null)
            {
                _logger.LogWarning("Tentativa de cadastro de uma categoria com nome já existente.");
                return ApiResposta<CategoriaRespostaDTO>.Conflict("Já existe uma categoria cadastrada com esse nome.");
            }

            if (encontrarCategoriaOrdem is not null)
            {
                _logger.LogWarning("Tentativa de cadastro de uma categoria com uma posição já existente.");
                return ApiResposta<CategoriaRespostaDTO>.Conflict("Já existe uma categoria cadastrada com essa pocisão.");
            }

            var categoria = CategoriaMapper.ModeloCategoria(dto);
            var criarCategoria = await _repository.Cadastrar(categoria);
            var resposta = CategoriaMapper.MapearParaCategoriaRespostaDTO(criarCategoria!);

            return ApiResposta<CategoriaRespostaDTO>.Ok(resposta, "Categoria cadastrada com sucesso.");
        }
    }
}
