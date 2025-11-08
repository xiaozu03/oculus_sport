using System;
using System.Threading.Tasks;

namespace oculus_sport.Services.Auth
{
    public class FirebaseAuthService : IAuthService
    {
        public Task<bool> LoginAsync(string email, string password)
        {
            // Implementation for Firebase login
            throw new NotImplementedException();
        }

        public Task<bool> SignUpAsync(string email, string password)
        {
            // Implementation for Firebase sign up
            throw new NotImplementedException();
        }

        public void Logout()
        {
            // Implementation for Firebase logout
            throw new NotImplementedException();
        }
    }
}
