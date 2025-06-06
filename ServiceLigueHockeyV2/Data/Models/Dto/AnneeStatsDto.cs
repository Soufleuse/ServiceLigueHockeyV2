using System;
using System.Collections.Generic;

namespace ServiceLigueHockey.Data.Models.Dto {
    public class AnneeStatsDto {
        public short AnneeStats { get; set; } = 1850;

        // Sert pour l'affichage dans les Combo boxes
        public string DescnCourte { get; set; } = string.Empty;

        public string DescnLongue { get; set; } = string.Empty;

        //public virtual ICollection<PartieDto> listePartie { get; set; } = default!;
    }
}