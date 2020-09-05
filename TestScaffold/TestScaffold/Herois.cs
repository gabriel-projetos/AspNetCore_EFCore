using System;
using System.Collections.Generic;

namespace TestScaffold
{
    public partial class Herois
    {
        public Herois()
        {
            Armas = new HashSet<Armas>();
            HeroiBatalhas = new HashSet<HeroiBatalhas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual IdentidadeSecretas IdentidadeSecretas { get; set; }
        public virtual ICollection<Armas> Armas { get; set; }
        public virtual ICollection<HeroiBatalhas> HeroiBatalhas { get; set; }
    }
}
