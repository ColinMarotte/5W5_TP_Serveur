using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Icone { get; set; } = "�";
        public int Turn { get; set; }
        public int value { get; set; }
    }
}
