using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLigueHockey.Data.Models
{
    [Table("StatsEquipe")]
    public class StatsEquipeBd
    {
        public short AnneeStats { get; set; }
        public short NbPartiesJouees { get; set; }

        public short NbVictoires { get; set; }
        public short NbDefaites { get; set; }
        public short? NbDefProlo { get; set; }
        public int NbButsPour { get; set;}
        public int NbButsContre { get; set; }

        //[ForeignKey("Equipe")]
        public int EquipeId { get; set; }
        public virtual EquipeBd Equipe { get; set; } = default!;
    }
}
