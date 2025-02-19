using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class StartingCard
    {
        public StartingCard() { }
        public int Id { get; set; }
        public virtual Card Card { get; set; }
    }
}
