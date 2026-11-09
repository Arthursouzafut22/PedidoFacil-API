using Microsoft.Extensions.Logging;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Categoria;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Mappers;
using PedidoFacil.Domain.Interfaces;

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

        public async Task<ApiResposta<CategoriaRespostaDTO>> CadastrarCategoria(CriarCategoriaDTO dto, Guid usuarioId)
        {
            var encontrarCategoriaNome = await _repository.EncontrarCategoriaPorNome(dto.Nome, usuarioId);
            var encontrarCategoriaOrdem = await _repository.EncontrarCategoriaPorOrdem(dto.Ordem, usuarioId);

            if (encontrarCategoriaNome is not null)
            {
                _logger.LogWarning("Tentativa de cadastro de uma categoria com nome já existente.");
                return ApiResposta<CategoriaRespostaDTO>.Conflict(RespostaMensagem.CategoriaComNomeJaCadastrado);
            }

            if (encontrarCategoriaOrdem is not null)
            {
                _logger.LogWarning("Tentativa de cadastro de uma categoria com uma posição já existente.");
                return ApiResposta<CategoriaRespostaDTO>.Conflict(RespostaMensagem.CategoriaComPosicaoJaCadastrada);
            }

            var categoria = CategoriaMapper.ModeloCategoria(dto, usuarioId);
            var criarCategoria = await _repository.Cadastrar(categoria);
            var resposta = CategoriaMapper.MapearParaCategoriaRespostaDTO(criarCategoria!);

            return ApiResposta<CategoriaRespostaDTO>.Ok(resposta, RespostaMensagem.CategoriaCadastradaComSucesso);
        }

        public async Task<ApiResposta<IEnumerable<CategoriaRespostaDTO>>> BuscarTodasCategoria(Guid usuarioId)
        {
            var categorias = await _repository.BuscarCategorias(usuarioId);

            if (!categorias.Any())
            {
                return ApiResposta<IEnumerable<CategoriaRespostaDTO>>
                    .Ok(null, RespostaMensagem.CategoriaNaoEncontrada);
            }

            var categoriasResposta = categorias.Select(c =>
                CategoriaMapper.MapearParaCategoriaRespostaDTO(c));

            return ApiResposta<IEnumerable<CategoriaRespostaDTO>>
                .Ok(categoriasResposta, RespostaMensagem.CategoriasRetornadasComSucesso);
        }

        public async Task<ApiResposta<CategoriaRespostaDTO>> BuscarCategoriaPorId(Guid? id, Guid? usuarioId)
        {
            if (id is null)
            {
                _logger.LogWarning("Tentativa de consultar uma categoria sem informa o ID.");
                return ApiResposta<CategoriaRespostaDTO>.BadRequest("O ID da categoria não foi informado na URL.");
            }

            var categoria = await _repository.BuscarCategoriaPorId(id);
            if (categoria is null)
            {
                _logger.LogWarning("Tentativa de consultar uma categoria inexistente.");
                return ApiResposta<CategoriaRespostaDTO>.NotFound(RespostaMensagem.CategoriaNaoEncontrada);
            }

            if (usuarioId != categoria?.UsuarioId)
            {
                _logger.LogWarning("Tentativa de consultar uma categoria que não pertence a este administrador.");
                return ApiResposta<CategoriaRespostaDTO>.Unauthorized("Você não tem permissão para acessar este recurso.");
            }

            var resposta = CategoriaMapper.MapearParaCategoriaRespostaDTO(categoria!);

            return ApiResposta<CategoriaRespostaDTO>.Ok(resposta, RespostaMensagem.CategoriaLocalizadaComSucesso);
        }

        public async Task<ApiResposta<CategoriaRespostaDTO>> AtualizarCategoria(
               AtualizarCategoriaDTO dto, Guid? id, Guid? usuarioId)
        {
            if (id is null)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria sem informar o ID.");
                return ApiResposta<CategoriaRespostaDTO>.BadRequest("O ID da categoria não foi informado na URL.");
            }

            var categoria = await _repository.BuscarCategoriaPorId(id);
            if (categoria is null)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria inexistente.");
                return ApiResposta<CategoriaRespostaDTO>.NotFound(RespostaMensagem.CategoriaNaoEncontrada);
            }

            if (categoria.UsuarioId != usuarioId)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria que não pertence a este administrador.");
                return ApiResposta<CategoriaRespostaDTO>.Unauthorized("Você não tem permissão para editar este recurso.");
            }

            var categoriaComMesmoNome = await _repository.EncontrarCategoriaPorNome(dto.Nome, usuarioId);
            if (categoriaComMesmoNome is not null && categoriaComMesmoNome.Id != categoria.Id)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria com nome já existente.");
                return ApiResposta<CategoriaRespostaDTO>.Conflict(RespostaMensagem.CategoriaComNomeJaCadastrado);
            }

            var categoriaComMesmaOrdem = await _repository.EncontrarCategoriaPorOrdem(dto.Ordem, usuarioId);
            if (categoriaComMesmaOrdem is not null && categoriaComMesmaOrdem.Id != categoria.Id)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria com uma posição já existente.");
                return ApiResposta<CategoriaRespostaDTO>.Conflict(RespostaMensagem.CategoriaComPosicaoJaCadastrada);
            }

            categoria.Nome = dto.Nome;
            categoria.Ordem = dto.Ordem;

            await _repository.Atualizar(categoria);
            var resposta = CategoriaMapper.MapearParaCategoriaRespostaDTO(categoria);

            return ApiResposta<CategoriaRespostaDTO>.Ok(resposta, RespostaMensagem.CategoriaAtualizadaComSucesso);
        }

        public async Task<ApiResposta<CategoriaRespostaDTO>> DeletarCategoria(Guid? id, Guid? usuarioId)
        {
            if (id is null)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria sem informar o ID.");
                return ApiResposta<CategoriaRespostaDTO>.BadRequest("O ID da categoria não foi informado na URL.");
            }

            var categoria = await _repository.BuscarCategoriaPorId(id);
            if (categoria is null)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria inexistente.");
                return ApiResposta<CategoriaRespostaDTO>.NotFound(RespostaMensagem.CategoriaNaoEncontrada);
            }

            if (categoria.UsuarioId != usuarioId)
            {
                _logger.LogWarning("Tentativa de atualizar uma categoria que não pertence a este administrador.");
                return ApiResposta<CategoriaRespostaDTO>.Unauthorized("Você não tem permissão para editar este recurso.");
            }

            await _repository.Deletar(categoria);

            return ApiResposta<CategoriaRespostaDTO>.Ok(null, "Categoria excluida com sucesso.");
        }
    }
}
