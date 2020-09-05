using System;
using System.Collections.Generic;

namespace TestScaffold
{
    public partial class Batalhas
    {
        public Batalhas()
        {
            HeroiBatalhas = new HashSet<HeroiBatalhas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public virtual ICollection<HeroiBatalhas> HeroiBatalhas { get; set; }
    }
}
