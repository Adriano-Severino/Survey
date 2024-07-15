using Microsoft.EntityFrameworkCore;
using Survey.Api.Data;
using Survey.Core.Handlers;
using Survey.Core.Models;
using Survey.Core.Requests.Luminarias;
using Survey.Core.Responses;

namespace Survey.Api.Handlers
{
    /// <summary>
    /// Serviço da luminaria.
    /// </summary>
    /// <param name="context"></param>
    public class LuminariaHandler(AppDbContext context) : ILuminariaHandler
    {
        /// <summary>
        /// Metodo responsavel por buscar todos as luminarias
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Luminaria>?>> GetAllAsync(GetAllLuminariasRequest request)
        {
            var query =
                    context.Luminarias
                        .AsTracking();

            var luminarias = await query
                    .Skip(request.Skip)
                    .Take(request.PageSize)
                    .ToListAsync();

            var count = luminarias.Count;

            return new PagedResponse<List<Luminaria>?>(luminarias, count, request.PageNumber, request.PageSize);
        }

        /// <summary>
        /// Metodo responsavel por buscar uma luminaria por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> GetByIdAsync(GetLuminariaByIdRequest request)
        {
            var luminaria =
         await context.Luminarias
             .Include(x => x.Estado)
             .AsTracking()
             .FirstOrDefaultAsync(x => x.Id == request.Id);

            return luminaria is null
                ? new Response<Luminaria?>(null, 404, "A luminaria não encontrada")
                : new Response<Luminaria?>(luminaria);
        }

        /// <summary>
        /// Metodo responsavel por criar uma luminaria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> CreateAsync(CreateLuminariaRequest request)
        {
            var luminaria = new Luminaria();
            luminaria.Imagem = request.Imagem;
            luminaria.Estado = request.Estado;

            try
            {
                await context.Luminarias.AddAsync(luminaria);
                await context.SaveChangesAsync();
                return new Response<Luminaria?>(luminaria, 201, "Luminaria criada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Luminaria?>(null, 500, "Não foi possive criar a luminaria");
            }
        }

        /// <summary>
        /// Metodo responsavel por atualizar uma luminaria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> UpdateAsync(UpdateLuminariaRequest request)
        {
            var luminaria =
          await context.Luminarias
              .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (luminaria is null)
                return new Response<Luminaria?>(null, 404, "A luminaria não encontrada");

            luminaria.Id = request.Id;
            luminaria.Imagem = request.Imagem;
            luminaria.Estado = request.Estado;
            try
            {
                context.Luminarias.Update(luminaria);
                await context.SaveChangesAsync();
                return new Response<Luminaria?>(luminaria, message: "Luminaria atualizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Luminaria?>(null, 500, "Não foi possive atualizar a luminaria");
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar uma luminaria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Luminaria?>> DeleteAsync(DeleteLuminariaRequest request)
        {
            var luminaria =
            await context.Luminarias
                .Include(x => x.Estado)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (luminaria is null)
                return new Response<Luminaria?>(null, 404, "A luminaria não encontrada");

            try
            {
                context.Luminarias.Remove(luminaria);
                await context.SaveChangesAsync();
                return new Response<Luminaria?>(luminaria, message: "Luminaria deletada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Luminaria?>(null, 500, "Não foi possivel atualizar a luminaria");
            }
        }
    }
}
