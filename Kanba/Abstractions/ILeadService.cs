using Kanba.Models;

namespace Kanba.Abstractions;

public interface ILeadService
{
    ValueTask<IEnumerable<Lead>> GetLeadsAsync(CancellationToken cancellationToken = default);
    ValueTask<Lead?> GetLeadByIdAsync(int id, CancellationToken cancellationToken = default);
    ValueTask<Lead> CreateLeadAsync(Lead lead, CancellationToken cancellationToken = default);
    ValueTask<Lead> UpdateLeadAsync(Lead lead, CancellationToken cancellationToken = default);
    ValueTask<bool> DeleteLeadAsync(int id, CancellationToken cancellationToken = default);
}
