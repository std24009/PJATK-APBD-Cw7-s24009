using EFCoreCodeFirst.DTOs;
using EFCoreCodeFirst.Exceptions;
using EFCoreCodeFirst.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Service;

public class PCsService(DatabaseContext ctx) : IPCsService
{
    public async Task<IEnumerable<PCsResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCsResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PCsDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(e => e.Id == id)
            .Select(pc => new PCsDetailsResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.Components.Select(comp => new PCComponentDetailsResponse(
                    comp.Amount,
                    new ComponentDetailsResponse(
                        comp.Components.Code,
                        comp.Components.Name,
                        comp.Components.Description,
                        new ManufacturerDetailsResponse(
                            comp.Components.ComponentManufacturers.Id,
                            comp.Components.ComponentManufacturers.Abbreviation,
                            comp.Components.ComponentManufacturers.FullName,
                            comp.Components.ComponentManufacturers.FoundationDate
                        ),
                        new TypeDetailsResponse(
                            comp.Components.ComponentTypes.Id,
                            comp.Components.ComponentTypes.Abbreviation,
                            comp.Components.ComponentTypes.Name
                        )
                    )
                )).ToList()
            )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"PC with id {id} not found");
    }
}