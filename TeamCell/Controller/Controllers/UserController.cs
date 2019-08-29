using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Model;
using Model.Models;
using Controller.Methods;
namespace Controller
{
    public class UserController
    {
        //private readonly TeamCellContext _dbContext = new TeamCellContext();
        //public UserController(TeamCellContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        private User convertToUser(TempUser userTmp)
        {
            var user = new User();
            user.UserName = userTmp.UserName;
            user.Salt = Cryptographic.GenerateSalt();
            user.Password = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(userTmp.Password), user.Salt);
            user.IdEmployee = userTmp.IdEmployee;
            user.Status = userTmp.Status;
            return user;
        }
        public List<User> getUsersActive()
        {
            try
            {
                using(TeamCellContext _dbContext = new TeamCellContext())
                {
                    var listUser = _dbContext.User.Include(x => x.Employee).Where(x => x.Status == true).ToList();
                    return listUser;
                }
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        public bool addUser(TempUser userTmp)
        {
            try
            {
                using (TeamCellContext _dbContext = new TeamCellContext())
                {
                    User user = convertToUser(userTmp);
                    _dbContext.User.Add(user);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool editUser(TempUser userTmp)
        {
            try
            {
                 using(TeamCellContext _dbContext = new TeamCellContext())
                 {
                    User user = convertToUser(userTmp);
                    var userEdit = _dbContext.User.FirstOrDefault(x => x.IdUser == user.IdUser);
                    userEdit.UserName = user.UserName;
                    userEdit.Password = user.Password;
                    userEdit.IdEmployee = user.IdEmployee;
                    _dbContext.SaveChanges();
                    return true;
                 }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteUser(int idUser)
        {
            try
            {
                 using(TeamCellContext _dbContext = new TeamCellContext())
                 {
                    var delUser = _dbContext.User.FirstOrDefault(x => x.IdUser == idUser);
                    delUser.Status = false;
                    _dbContext.SaveChanges();
                    return true;
                 }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public User getUserXId(int idUser)
        {
            try
            {
                 using(TeamCellContext _dbContext = new TeamCellContext())
                 {
                    var user = _dbContext.User.Include(x => x.Employee).FirstOrDefault(x => x.IdUser == idUser);
                    return user;
                 }
            }
            catch (Exception)
            {
                return new User();
            }
        }

        public bool tryLogin(string userName, string password)
        {
            try
            {
                 using(TeamCellContext _dbContext = new TeamCellContext())
                 {
                    var user = _dbContext.User.FirstOrDefault(x => x.UserName == userName);
                    if (user != null)
                    {
                        byte[] hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), user.Salt);

                        if (hashedPassword.SequenceEqual(user.Password))
                            return true;
                        else
                            return false;
                    }
                    return false;
                 }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public int getEmpXCredenciales(string userName, string password)
        {
            try
            {
                using (TeamCellContext _dbContext = new TeamCellContext())
                {
                    var user = _dbContext.User.FirstOrDefault(x => x.UserName == userName);
                    if (user != null)
                    {
                        byte[] hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), user.Salt);

                        if (hashedPassword.SequenceEqual(user.Password))
                            return user.IdEmployee;
                        else
                            return 0;
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
