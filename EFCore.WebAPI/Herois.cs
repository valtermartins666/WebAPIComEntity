using System;
using System.Collections.Generic;

namespace EFCore.WebAPI
{
    public partial class Herois
    {
        public Herois()
        {
            Armas = new HashSet<Armas>();
            HeroisBatalhas = new HashSet<HeroisBatalhas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public IdentidadesSecretas IdentidadesSecretas { get; set; }
        public ICollection<Armas> Armas { get; set; }
        public ICollection<HeroisBatalhas> HeroisBatalhas { get; set; }
    }
}
