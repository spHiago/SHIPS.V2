using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHIPS.V2.Model;
using SHIPS.V2.Repository;
using SHIPS.V2.Service;

namespace SHIPS.V2.UI
{
    public class MenuAdmin
    {
        public static void AdminMenu(User user, UserService userService, ShipService shipService)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU ADMIN ===");
                Console.WriteLine("1 - Gerenciar Users");
                Console.WriteLine("2 - Gerenciar Ships");
                Console.WriteLine("0 - Sair");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        UserMenu.Show(userService);
                        break;

                    case "2":
                        ShipMenu.Show(shipService);
                        break;

                    case "0":
                        return;
                }
            }
        }
    }
}