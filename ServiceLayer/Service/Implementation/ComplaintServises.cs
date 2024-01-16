using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Service.Contract;

namespace ServiceLayer.Service.Implementation
{
    public class ComplaintServises : IGeneric<Complaint>
    {
        private readonly AppDbContext _appDbContext;

        public ComplaintServises(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        #region public
        public async Task<List<Complaint>> GetAllAsync(long? id = 0, long? adminId = 0)
        {
            try
            {
                return await getAllAsync(id, adminId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Complaint> GetByIdAsync(long id)
        {
            try
            {
                return await getByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Complaint> CreateAsync(Complaint model)
        {
            try
            {
                return await createAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Complaint> UpdateAsync(Complaint model)
        {
            try
            {
                return await updateAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Complaint> DeleteAsync(long id)
        {
            try
            {
                return await deleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Complaint> UpdateStatusAsync(long complaintId, int newStatusId, long adminId)
        {
            try
            {
                return await updateStatusAsync(complaintId, newStatusId, adminId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region private
        private async Task<List<Complaint>> getAllAsync(long? userId = 0, long? adminId = 0)
        {
            try
            {
                List<Complaint> complaints = new List<Complaint>();
                List<string> strings = new List<string>();
                if (userId == 0)
                {
                    var query = await _appDbContext.Complaint.Where(d => d.isDelete == false).ToListAsync();
                    if (adminId == 0)
                    {
                        query = query.Where(a => a.AssignUsersId == null || a.AssignUsersId == "").ToList();
                        return query.Count > 0 ? query : new List<Complaint>();
                    }
                    foreach (var comp in query)
                    {
                        if (comp.AssignUsersId != null && comp.AssignUsersId != "")
                        {
                            strings = new List<string>();
                            strings.AddRange(comp.AssignUsersId.Split(','));
                            if (strings.Any(item => item.Contains(adminId.ToString())))
                            {
                                complaints.Add(comp);
                            }
                        }
                    }
                }
                else
                {
                    var query = _appDbContext.Set<Complaint>().Where(d => d.isDelete == false && d.UserId == userId);
                    complaints = await query.ToListAsync();
                }

                // Return the retrieved complaints
                return complaints ?? new List<Complaint>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<Complaint> getByIdAsync(long id)
        {
            try
            {
                var query = _appDbContext.Set<Complaint>()
                                  .Where(d => d.ComplaintId == id && d.isDelete == false);

                Complaint complaint = await query.FirstOrDefaultAsync();

                return complaint ?? new Complaint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<Complaint> createAsync(Complaint model)
        {
            try
            {
                model.StatusId = 1;
                model.isDelete = false;
                model.AssignUsersId = null;

                _appDbContext.Entry(model).State = EntityState.Added;
                await _appDbContext.SaveChangesAsync();

                // Check if the entity is still attached after SaveChanges
                if (_appDbContext.Entry(model).State == EntityState.Unchanged)
                {
                    return model;
                }
                else
                {
                    return new Complaint();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<Complaint> updateAsync(Complaint model)
        {
            try
            {
                var existingEntity = _appDbContext.Complaint.Find(model.ComplaintId);
                if (existingEntity == null)
                    return new Complaint();

                _appDbContext.Entry(existingEntity).State = EntityState.Detached;

                _appDbContext.Entry(model).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
                if (_appDbContext.Entry(model).State == EntityState.Unchanged)
                {
                    return model;
                }
                else
                {
                    return new Complaint();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<Complaint> deleteAsync(long id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    entity.isDelete = true;

                    _appDbContext.Entry(entity).State = EntityState.Modified;
                    await _appDbContext.SaveChangesAsync();

                    // Check if the save operation was successful
                    if (_appDbContext.Entry(entity).State == EntityState.Unchanged)
                    {
                        return entity;
                    }
                    else
                    {
                        return new Complaint();
                    }
                }
                return new Complaint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<Complaint> updateStatusAsync(long complaintId, int newStatusId, long adminId)
        {
            try
            {
                //newStatusId = 2 Ass Approve
                //newStatusId = 3 Ass Reject
                var userModel = _appDbContext.Users.Find(adminId);
                if (userModel != null && userModel.RoleId == 1)
                {
                    var complaint = await _appDbContext.Complaint
                    .Where(d => d.isDelete == false && d.ComplaintId == complaintId)
                    .FirstOrDefaultAsync();

                    if (complaint != null && complaint.StatusId == 1) //StatusId = 1 Is a Pending
                    {
                        // Update only the Status property
                        complaint.StatusId = newStatusId;

                        _appDbContext.Entry(complaint).State = EntityState.Modified;

                        await _appDbContext.SaveChangesAsync();

                        if (_appDbContext.Entry(complaint).State == EntityState.Unchanged)
                        {
                            return complaint;
                        }
                    }
                }
                return new Complaint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
