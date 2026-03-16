using SHIPS.V2.Model;
using SHIPS.V2.Service;
using SHIPS.V2.UI;
using System.ClientModel.Primitives;

UserService userService = new UserService(); //cria um novo userService, pra armazenar dados e jogar pro Service depois
ShipService shipService = new ShipService();
Console.WriteLine("Digite o username:");
string username = Console.ReadLine();

Console.WriteLine("Digite a password: ");
string password = Console.ReadLine();

User? user = userService.Login(username, password); //passa pela autenticação do Service

if (user != null)
{
    Console.WriteLine("Login realizado com sucesso!");
    Thread.Sleep(3000); //so pra deixar ler a primeira linha a tempo
    if (user.isadmin)
    {
        Console.WriteLine($"Bem vindo {user.username}.");
        //menu adm
        MenuAdmin.AdminMenu(user, userService, shipService);
    }
    else
    {
        Console.WriteLine($"Bem vindo {user.username}.");
        //menu clientesp
    }
}
else
    Console.WriteLine("username ou senha incorretos"); //se a carruagem que passou pelo Service retornou nulo