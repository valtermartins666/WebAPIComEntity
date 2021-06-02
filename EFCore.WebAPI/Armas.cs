using System;
using System.Collections.Generic;

namespace EFCore.WebAPI
{
    public partial class Armas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int HeroiId { get; set; }

        public Herois Heroi { get; set; }
    }
}
