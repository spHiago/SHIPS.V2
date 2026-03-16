using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHIPS.V2.Model;
using SHIPS.V2.Repository;

namespace SHIPS.V2.Service
{
    public class ShipService
    {
        private ShipRepository shipRepository = new ShipRepository();

        public Ship Create(Ship ship)
        {
            return shipRepository.Create(ship);
        }

        public Ship? RetrieveById(int id)
        {
            return shipRepository.RetrieveById(id);
        }

        public List<Ship> RetrieveAll()
        {
            return shipRepository.RetrieveAll();
        }

        public void Update(Ship ship)
        {
            shipRepository.Update(ship);
        }

        public void Delete(int id)
        {
            shipRepository.Delete(id);
        }
    }
}
