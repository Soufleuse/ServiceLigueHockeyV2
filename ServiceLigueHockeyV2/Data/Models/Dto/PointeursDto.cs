using System;
using System.Collections.Generic;

namespace ServiceLigueHockey.Data.Models.Dto {
    
    public class PointeursDto
    {
        public TimeSpan MomentDuButMarque { get; set; } = TimeSpan.Zero;
        public int IdJoueurButMarque { get; set; } = default;
        public int? IdJoueurPremiereAssistance { get; set; } = null;
        public int? IdJoueurSecondeAssistance { get; set; } = null;
        
        public int IdPartie { get; set; }
        //public virtual partieBd MonCalendrier { get; set; } = default!;
    }
}