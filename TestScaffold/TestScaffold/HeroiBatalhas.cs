using System;
using System.Collections.Generic;

namespace TestScaffold
{
    public partial class HeroiBatalhas
    {
        public int HeroId { get; set; }
        public int BatalhaId { get; set; }
        public int? HeroiId { get; set; }

        public virtual Batalhas Batalha { get; set; }
        public virtual Herois Heroi { get; set; }
    }
}
