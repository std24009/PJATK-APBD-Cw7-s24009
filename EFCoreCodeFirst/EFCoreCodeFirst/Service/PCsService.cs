using EFCoreCodeFirst.DTOs;
using EFCoreCodeFirst.Exceptions;
using EFCoreCodeFirst.Infrastructure;
using EFCoreCodeFirst.Models;
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

    public async Task<PCsResponse> AddAsync(CreatePCsRequest request, CancellationToken cancellationToken)
    {
        var pc = new PCs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PCsResponse(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePCsRequest request, CancellationToken cancellationToken)
    {
        /*var pc = await ctx.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }

        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;
        await ctx.SaveChangesAsync(cancellationToken);*/

        int affectedRows = await ctx.PCs.Where(e => e.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(e => e.Name, request.Name)
                .SetProperty(e => e.Weight, request.Weight)
                .SetProperty(e => e.Warranty, request.Warranty)
                .SetProperty(e => e.CreatedAt, request.CreatedAt)
                .SetProperty(e => e.Stock, request.Stock)
                , cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
}