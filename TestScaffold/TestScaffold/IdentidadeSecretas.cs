using System;
using System.Collections.Generic;

namespace TestScaffold
{
    public partial class IdentidadeSecretas
    {
        public int Id { get; set; }
        public string NomeReal { get; set; }
        public int HeroiId { get; set; }

        public virtual Herois Heroi { get; set; }
    }
}
