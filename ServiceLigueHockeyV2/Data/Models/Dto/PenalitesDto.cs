using System;
using System.Collections.Generic;

namespace ServiceLigueHockey.Data.Models.Dto {
    
    public class PenalitesDto
    {
        public TimeSpan MomentDelaPenalite { get; set; } = TimeSpan.Zero;

        public int IdJoueurPenalise { get; set; } = default;
        public virtual JoueurDto joueurPenalise { get; set; } = default!;

        // Oui oui, un joueur peut avoir plus qu'une pénalité au même moment.
        //public virtual ICollection<Penalite_TypePenaliteDto> listePenalites { get; set; } = default!;
        
        public int IdPartie { get; set; }
        //public virtual PartieDto MaPartie { get; set; } = default!;
    }
}