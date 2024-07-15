using Microsoft.EntityFrameworkCore;
using Survey.Api.Data;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Levantamentos;
using Survey.Core.Responses;

namespace Survey.Api.Handlers
{
    /// <summary>
    /// Serviço de levantamento.
    /// </summary>
    /// <param name="context"></param>
    public class LevantamentoHandler(AppDbContext context) : ILevantamentoHandler
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os levantamentos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Levantamento>?>> GetAllAsync(GetAllLevantamentosRequest request)
        {
            var query =
                context.Levantamentos
                    .Include(x => x.Bloco)
                    .ThenInclude(bloco => bloco.Pavimentos)
                    .ThenInclude(pavimento => pavimento.Luminarias)
                    .ThenInclude(luminarias => luminarias.Estado)
                    .AsTracking();

            var levantamentos = await query
                    .Skip(request.Skip)
                    .Take(request.PageSize)
                    .ToListAsync();

            var count = levantamentos.Count;

            return new PagedResponse<List<Levantamento>?>(levantamentos, count, request.PageNumber, request.PageSize);
        }

        /// <summary>
        /// Metodo responsavel por criar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> CreateAsync(CreateLevantamentoRequest request)
        {
            var levantamento = new Levantamento();
            levantamento.FuncionarioId = request.FuncionarioId;
            levantamento.Descricao = request.Descricao;
            levantamento.Bloco = request.Bloco;

            try
            {
                await context.Levantamentos.AddAsync(levantamento);
                await context.SaveChangesAsync();
                return new Response<Levantamento?>(levantamento, 201, "Levantamento criada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Levantamento?>(null, 500, "Não foi possive criar uma levantamento");
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar um levantamento por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> GetByIdAsync(GetLevantamentoByIdRequest request)
        {
            var levantamento =
           await context.Levantamentos
               .Include(x => x.Bloco)
               .ThenInclude(bloco => bloco.Pavimentos)
               .ThenInclude(pavimento => pavimento.Luminarias)
               .ThenInclude(luminarias => luminarias.Estado)
               .AsTracking()
               .FirstOrDefaultAsync(x => x.Id == request.Id);

            return levantamento is null
                ? new Response<Levantamento?>(null, 404, "O levantamento não encontrado")
                : new Response<Levantamento?>(levantamento);
        }

        /// <summary>
        /// Metodo responsavel por atualizar um levantamento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> UpdateAsync(UpdateLevantamentoRequest request)
        {
            var levantamento =
            await context.Levantamentos
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (levantamento is null)
                return new Response<Levantamento?>(null, 404, "A levantamento não encontrado");

            levantamento.Descricao = request.Descricao;
            levantamento.Bloco = request.Bloco;
            levantamento.Concluded = request.Concluded;
            try
            {
                context.Levantamentos.Update(levantamento);
                await context.SaveChangesAsync();
                return new Response<Levantamento?>(levantamento, message: "Levantamento atualizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Levantamento?>(null, 500, "Não foi possive atualizar a levantamento");
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar um levantamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Levantamento?>> DeleteAsync(DeleteLevantamentoRequest request)
        {
            var levantamento =
            await context.Levantamentos
                .Include(x => x.Bloco)
                .ThenInclude(bloco => bloco.Pavimentos)
                .ThenInclude(pavimento => pavimento.Luminarias)
                .ThenInclude(luminarias => luminarias.Estado)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (levantamento is null)
                return new Response<Levantamento?>(null, 404, "O levantamento não encontrado");

            try
            {
                context.Levantamentos.Remove(levantamento);
                await context.SaveChangesAsync();
                return new Response<Levantamento?>(levantamento, message: "Levantamento deletada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Levantamento?>(null, 500, "Não foi possivel atualizar o levantamento");
            }
        }

    }
}