using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHIPS.V2.Model
{
    public class Ship
    {
        public int id {  get; set; }
        public string shipType { get; set; }
        public string color { get; set; }
        public int rank_id { get; set; }
        public string price { get; set; }
    }
}
