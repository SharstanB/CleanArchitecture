using Domain.DataTransferObjects;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataSource;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BranchRepository : BaseRepository , IBranchRepository
{
    public BranchRepository(CompanyDbContext dbContext) 
        : base(dbContext)
    {
    }
    public Guid Insert(CreateBranchDto createBranch)
    {
       var branch = DbContext.Branches.Add(createBranch.ToEntity());
       return branch.Entity.Id;
    }

    public void Update(UpdateBranchDto updateBranch)
    { 
        DbContext.Branches.Update(updateBranch.ToEntity());
    }

    public async Task<IEnumerable<BaseBranchDto>> GetAll()
        => await DbContext.Branches.Select(branch => new BaseBranchDto()
        {
            Name = branch.Name,
            Location = branch.Address,
            CompanyId = branch.CompanyId,
            CreateDate = branch.CreateDate,
            ParentBranchId = branch.ParentBranchId,
            
        }).ToListAsync();

    public async Task<BaseBranchDto?> GetById(Guid id)
        => (await GetAll()).FirstOrDefault();


}