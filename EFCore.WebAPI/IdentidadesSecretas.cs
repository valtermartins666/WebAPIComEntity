using System;
using System.Collections.Generic;

namespace EFCore.WebAPI
{
    public partial class IdentidadesSecretas
    {
        public int Id { get; set; }
        public string NomeReal { get; set; }
        public int HeroiId { get; set; }

        public Herois Heroi { get; set; }
    }
}
