using System;

namespace ComlinkStore.Domain.Entities
{
    public class User
    {
        protected User() { }
        public User(string username, string password)
        {
            Id = 0;
            Username = username;
            Password = password;

            Register();
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public void Register()
        {
            if (Username.Length <= 3)
                throw new Exception("Usuário Inválido");

            if (Password.Length <= 3)
                throw new Exception("Senha Inválida");
        }

        public bool Authenticate(string password)
        {
            return Password == password;
        }
    }
}
