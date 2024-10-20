using FOV.Domain.DTOs;
using FOV.Domain.Entities.ComboAggregator;

namespace FOV.Infrastructure.Repository.IRepositories;
public interface IComboRepository : IGenericRepository<Combo>
{
    public Task<GetComboDetailResponse> GetComboDetail(Guid comboId);
}

