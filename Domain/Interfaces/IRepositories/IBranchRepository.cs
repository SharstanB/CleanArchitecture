using Domain.DataTransferObjects;

namespace Domain.Interfaces;

public interface IBranchRepository
{
     Guid Insert(CreateBranchDto createBranch);
     
     void Update(UpdateBranchDto updateBranch);

     Task<IEnumerable<BaseBranchDto>> GetAll();

     Task<BaseBranchDto?> GetById(Guid id);
}