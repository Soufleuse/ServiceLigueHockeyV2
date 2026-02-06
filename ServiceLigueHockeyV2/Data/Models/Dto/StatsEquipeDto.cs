using System;
using System.Collections.Generic;

namespace ServiceLigueHockey.Data.Models.Dto
{
    public class StatsEquipeDto
    {
        public short AnneeStats { get; set; } = default;
        public short NbPartiesJouees { get; set; } = default;

        public short NbVictoires { get; set; } = default;
        public short NbDefaites { get; set; } = default;
        public short? NbDefProlo { get; set; } = default;
        public int NbButsPour { get; set; } = 0;
        public int NbButsContre { get; set; } = 0;

        public int EquipeId { get; set; }
        public virtual EquipeDto Equipe { get; set; } = default!;
    }
}