using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataLayer;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class UserService : IService<User>
    {
        private readonly IRepository<DataLayer.Models.User> _userRepository;
        public UserService()
        {
            _userRepository = new Repository<DataLayer.Models.User>();
        }
        public void Add(User item)
        {
            var user = new DataLayer.Models.User()
            {
                EmailAddress = item.EmailAddress,
            };
            _userRepository.Add(user);
        }
    }
}
