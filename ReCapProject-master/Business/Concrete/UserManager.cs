using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult DeleteById(int id)
        {
            var deletedUser = _userDal.Get(u=>u.UserId==id);
            _userDal.Delete(deletedUser);
           return new SuccessResult();
                
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==id));
        }

        public IResult Update(int userId, User user)
        {
            var updatedUser = _userDal.Get(u=>u.UserId==userId);
            user.UserId = updatedUser.UserId;
            _userDal.Update(user); 
            return new SuccessResult();
        }
    }
}
