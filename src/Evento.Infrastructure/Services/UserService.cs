using System;
using System.Threading.Tasks;
using Evento.Core.Domain;
using Evento.Core.Repositories;

namespace Evento.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }
        public async Task RegisterAsync(Guid userId, string email, string name, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"user with emial : '{email}' already exist");
            }
            user = new User(userId, role, name, email, password);
            await _userRepository.AddAsync(user);
        }
          public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null)
            {
                throw new Exception("Incalid credenital");
            }
            if(user.Password != password)
            {
                throw new Exception("Incalid credenital");
            }
        }
    }
}