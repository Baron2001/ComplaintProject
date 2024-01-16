using RepositoryLayer;
using ServiceLayer.Service.Contract;

namespace ServiceLayer.Service.Implementation
{
    public class UserServises : IUsers
    {
        private readonly AppDbContext _appDbContext;

        public UserServises(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //public string AddUsers(Users user)
        //{
        //    try
        //    {
        //        _appDbContext.Users.Add(user);
        //        _appDbContext.SaveChanges();
        //        return "su";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //public string DeleteUsers(long id)
        //{
        //    try
        //    {
        //        var userModel = _appDbContext.Users.Find(id);
        //        _appDbContext.Users.Remove(userModel);
        //        _appDbContext.SaveChanges();
        //        return "su";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //public Users Get(long id)
        //{
        //    return _appDbContext.Users.Find(id);
        //}

        //public List<Users> GetAll()
        //{
        //    return _appDbContext.Users.ToList();
        //}

        //public string UpdateUsers(Users user)
        //{
        //    try
        //    {
        //        var userModel = _appDbContext.Users.Find(user.userId);
        //        if (userModel != null)
        //        {
        //            userModel.userName = user.userName;
        //            _appDbContext.Users.Update(userModel);
        //            _appDbContext.SaveChanges();
        //            return "success";
        //        }
        //        return "faild";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
