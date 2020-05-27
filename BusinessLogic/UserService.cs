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
        public UserService(IRepository<DataLayer.Models.User> userRepository)
        {
            _userRepository = userRepository;
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
