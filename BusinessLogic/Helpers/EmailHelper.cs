using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLogic.Helpers
{
    public class EmailHelper
    {
        private readonly IRepository<User> _userRepository;

        public EmailHelper(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid GetUserId(string email)
        {
            return _userRepository.List(u => u.EmailAddress == email).First().Id;
        }
    }
}
