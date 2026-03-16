using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHIPS.V2.Model;
using SHIPS.V2.Repository;
        

namespace SHIPS.V2.Service
{
    public class UserService
    {
       private UserRepository userRepository = new UserRepository(); //sintaxe padrao dizendo que vai jogar oq ta aqui pro repository


        public User? Login(string username, string password) //autenticaçao de login
        {
            User? user = userRepository.GetbyUsername(username); //sintaxe dizendo que o username sera jogado pro GetbyUsername que ta no repositorio

            if (user != null && user.password == password) //se a password pega la do DB coincidir com a pass recebida do console, retorna user
                return user;
            else
                return null; //se nao coincidir, retorna nulo e da erro la no repo
        }
        public User Create(User user)
        {
            if (string.IsNullOrEmpty(user.username)) //se ta nulo ou vazio
                throw new ArgumentNullException("Username nao pode ser vazio.");
            if (user.password == null || user.password.Length < 2) //se nulo ou < 2
                throw new ArgumentException("A senha deve conter no minino 6 caracteres");
            return userRepository.Create(user); //se passar, o user vai pro repo
        }

        public User? RetrieveById(int id)
        {
           return userRepository.RetrievedById(id);
        }

        public List<User> RetrieveAll()
        {
            return userRepository.RetrieveAll();
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }
        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}
