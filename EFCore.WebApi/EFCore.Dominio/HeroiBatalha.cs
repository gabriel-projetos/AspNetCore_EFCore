using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class HeroiBatalha
    {
        //Muitos herois podem participar de muitas batalhas
        //A Propriedade de id e referente a classe precisam ter o mesmo nome seguido de id
        //Nome{id}
        //se não, não é criado a classe correta
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; }
        public int BatalhaId { get; set; }        
        public Batalha Batalha { get; set; }
    }
}
