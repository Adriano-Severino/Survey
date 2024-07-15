using Microsoft.EntityFrameworkCore;
using Survey.Api.Data;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Pavimentos;
using Survey.Core.Responses;

namespace Survey.Api.Handlers
{
    /// <summary>
    /// Serviço do pavimento.
    /// </summary>
    /// <param name="context"></param>
    public class PavimentoHandler(AppDbContext context) : IPavimentoHandler
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os pavimentos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Pavimento>?>> GetAllAsync(GetAllPavimentosRequest request)
        {
            var query =
                context.Pavimentos
                    .AsTracking();

            var pavimentos = await query
                    .Skip(request.Skip)
                    .Take(request.PageSize)
                    .ToListAsync();

            var count = pavimentos.Count;

            return new PagedResponse<List<Pavimento>?>(pavimentos, count, request.PageNumber, request.PageSize);
        }

        /// <summary>
        /// Metodo responsavel por buscar um pavimento por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> GetByIdAsync(GetPavimentoByIdRequest request)
        {
            var pavimento =
          await context.Pavimentos
              .Include(x => x.Luminarias)
              .ThenInclude(luminarias => luminarias.Estado)
              .AsTracking()
              .FirstOrDefaultAsync(x => x.Id == request.Id);

            return pavimento is null
                ? new Response<Pavimento?>(null, 404, "O pavimento não encontrado")
                : new Response<Pavimento?>(pavimento);
        }

        /// <summary>
        /// Metodo responsavel por criar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> CreateAsync(CreatePavimentoRequest request)
        {
            var pavimento = new Pavimento();
            pavimento.Descricao = request.Descricao;
            pavimento.Nome = request.Nome;

            try
            {
                await context.Pavimentos.AddAsync(pavimento);
                await context.SaveChangesAsync();
                return new Response<Pavimento?>(pavimento, 201, "Pavimento criada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Pavimento?>(null, 500, "Não foi possive criar uma Pavimento");
            }
        }

        /// <summary>
        /// Metodo responsavel por atualizar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> UpdateAsync(UpdatePavimentoRequest request)
        {
            var pavimento =
           await context.Pavimentos
               .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (pavimento is null)
                return new Response<Pavimento?>(null, 404, "A pavimento não encontrado");

            pavimento.Descricao = request.Descricao;
            try
            {
                context.Pavimentos.Update(pavimento);
                await context.SaveChangesAsync();
                return new Response<Pavimento?>(pavimento, message: "Pavimento atualizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Pavimento?>(null, 500, "Não foi possive atualizar o pavimento");
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar um pavimento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Pavimento?>> DeleteAsync(DeletePavimentoRequest request)
        {
            var pavimento =
            await context.Pavimentos
                .Include(x => x.Luminarias)
                .ThenInclude(luminarias => luminarias.Estado)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (pavimento is null)
                return new Response<Pavimento?>(null, 404, "O pavimento não encontrado");

            try
            {
                context.Pavimentos.Remove(pavimento);
                await context.SaveChangesAsync();
                return new Response<Pavimento?>(pavimento, message: "Pavimento deletada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Pavimento?>(null, 500, "Não foi possivel atualizar o pavimento");
            }
        }

    }
}
