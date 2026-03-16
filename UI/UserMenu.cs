using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHIPS.V2.Model;
using SHIPS.V2.Repository;
using SHIPS.V2.Service;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace SHIPS.V2.UI
{
    public class UserMenu
    {
        public static void Show(UserService userService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== INICIALIZANDO ===");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("=== GERENCIADOR DE USUARIOS ===");
                Thread.Sleep(1000);
                Console.WriteLine("1 - Criar usuario");
                Console.WriteLine("2 - Listar todos os usuarios");
                Console.WriteLine("3 - Listar usuarios por ID");
                Console.WriteLine("4 - Delete por ID");
                Console.WriteLine("5 - Update por ID");
                Console.WriteLine("0 - Sair");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Criar usuario...");
                        User newUser = new User();

                        Console.WriteLine("Digite o username:");
                        newUser.username = Console.ReadLine();

                        Console.WriteLine("Digite a password:");
                        newUser.password = Console.ReadLine();

                        Console.WriteLine("É administrador? (true/false)");
                        newUser.isadmin = Convert.ToBoolean(Console.ReadLine());


                        userService.Create(newUser);
                        Console.WriteLine("Usuário criado com sucesso!");
                        break;

                    case "2":
                        List<User> users = userService.RetrieveAll(); //cria uma lista = todos os usuarios

                        foreach (User u in users) //a cada (qualquer variavel) em users, faça console.writeline
                            Console.WriteLine($"ID: {u.id} || Username: {u.username} || Admin: {u.isadmin}");
                        break;

                    case "3":
                        Console.WriteLine("Digite o ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        User? userFound = userService.RetrieveById(id); //cria um objeto provisorio userFound que é o retrievebyid

                        if (userFound != null) //se achou...
                            Console.WriteLine($"ID: {userFound.id} || Username: {userFound.username}.");
                        else //caso contrário...
                            Console.WriteLine("Usuario nao encontrado");
                        break;

                    case "4":

                        Console.WriteLine("Digite o ID do usuário para apagar:");
                        int delId = Convert.ToInt32(Console.ReadLine());

                        userService.Delete(delId);

                        Console.WriteLine("Usuário apagado.");

                        break;

                    case "5":

                        User updateUser = new User();
                        Console.WriteLine("Digite o ID do usuário para atualizar:");
                        updateUser.id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Novo username:");
                        updateUser.username = Console.ReadLine();
                        Console.WriteLine("Nova password:");
                        updateUser.password = Console.ReadLine();
                        Console.WriteLine("é admin ? (true/false");

                        userService.Update(updateUser);
                        Console.WriteLine("usuario atualizado com sucesso.");
                        break;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}