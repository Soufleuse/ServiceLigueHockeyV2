using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLigueHockey.Data.Models
{
    [Table("StatsEquipe")]
    public class StatsEquipeBd
    {
        public short AnneeStats { get; set; }
        public short NbPartiesJouees { get; set; } = default;

        public short NbVictoires { get; set; } = default;
        public short NbDefaites { get; set; } = default;
        public short? NbDefProlo { get; set; } = default;
        public int NbButsPour { get; set; } = 0;
        public int NbButsContre { get; set; } = 0;

        //[ForeignKey("Equipe")]
        public int EquipeId { get; set; }
        public virtual EquipeBd Equipe { get; set; } = default!;
    }
}
