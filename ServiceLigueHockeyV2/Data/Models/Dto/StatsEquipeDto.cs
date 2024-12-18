using System;
using System.Collections.Generic;

namespace ServiceLigueHockey.Data.Models.Dto
{
    public class StatsEquipeDto
    {
        public short AnneeStats { get; set; }
        public short NbPartiesJouees { get; set; }

        public short NbVictoires { get; set; }
        public short NbDefaites { get; set; }
        public short? NbDefProlo { get; set; }
        public int NbButsPour { get; set;}
        public int NbButsContre { get; set; }

        public int EquipeId { get; set; }
        public virtual EquipeBd Equipe { get; set; } = default!;
    }
}