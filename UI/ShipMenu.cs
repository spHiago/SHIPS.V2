using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHIPS.V2.Service;
using SHIPS.V2.Model;

namespace SHIPS.V2.UI
{
    public class ShipMenu
    {
        public static void Show(ShipService shipService)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("=== INICIALIZANDO ===");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("=== GERENCIADOR DE BARCOS ===");
                Thread.Sleep(1000);
                Console.WriteLine("1 - Criar barco");
                Console.WriteLine("2 - Listar todos os bracos");
                Console.WriteLine("3 - Listar barco por ID");
                Console.WriteLine("4 - Delete por ID");
                Console.WriteLine("5 - Update por ID");
                Console.WriteLine("0 - Sair");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Criar barcos...");
                        Ship createShip = new Ship();
                        Console.Clear();

                        Console.WriteLine("Digite o tipo do barco:");
                        createShip.shipType = Console.ReadLine();

                        Console.WriteLine("Digite a cor do barco:");
                        createShip.color = Console.ReadLine();

                        Console.WriteLine("Digite o ID de rank do barco (1 - 5");
                        Console.WriteLine("1 - Super Rico");
                        Console.WriteLine("2 - Rico");
                        Console.WriteLine("3 - Classe Media");
                        Console.WriteLine("4 - Pobre");
                        Console.WriteLine("5 - Imigrante");
                        createShip.rank_id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o preço do barco");
                        createShip.price = Console.ReadLine();

                        shipService.Create(createShip);
                        Console.WriteLine("Barco criado com sucesso!");
                        break;

                        case "2":
                        Console.Clear();
                        List <Ship> shipList = shipService.RetrieveAll();

                        foreach (Ship s in shipList)
                            Console.WriteLine($"ID : {s.id} \n Tipo: {s.shipType} \n Cor: {s.color} \n Nivel de Rank: {s.rank_id} \n Preço: {s.price}");
                        break;

                        case "3":
                        Console.Clear();
                        Console.WriteLine("Digite o ID:");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Ship shipFound = shipService.RetrieveById(Id);

                        if (shipFound != null)
                            Console.WriteLine($"ID: {shipFound.id} \n  Tipo: {shipFound.shipType}.");
                        else
                            Console.WriteLine("Barco nao encontrado.");
                        break;

                        case "4":
                        Console.Clear();
                        Console.WriteLine("Digite o ID do barco a ser deletado:");
                        int delShip = Convert.ToInt32(Console.ReadLine());

                        shipService.Delete(delShip);
                        Console.WriteLine("Barco deletado.");
                        break;

                        case "5":
                        Console.Clear();
                        Ship updatedShip = new Ship();
                        Console.WriteLine("Digite o ID do barco a ser atualizado:");
                        updatedShip.id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Novo tipo de barco:");
                        updatedShip.shipType = Console.ReadLine();
                        Console.WriteLine("Nova cor:");
                        updatedShip.color = Console.ReadLine();
                        Console.WriteLine("Novo ID de rank:");
                        updatedShip.rank_id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Novo preço");
                        updatedShip.price = Console.ReadLine();

                        shipService.Update(updatedShip);
                        Console.WriteLine("Barco atualizado com sucesso"); 
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
