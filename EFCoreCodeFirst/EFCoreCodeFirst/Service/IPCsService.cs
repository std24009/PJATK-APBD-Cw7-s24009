using EFCoreCodeFirst.DTOs;

namespace EFCoreCodeFirst.Service;

public interface IPCsService
{
    Task<IEnumerable<PCsResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<PCsDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCsResponse> AddAsync(CreatePCsRequest request, CancellationToken cancellationToken);

}