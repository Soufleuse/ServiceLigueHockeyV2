namespace ServiceLigueHockey.Data.Models.Dto
{
    public class JoueurEquipeCompleteDto
    {
        public JoueurDto Joueur { get; set; } = default!;

        public EquipeJoueurDto EquipeJoueur { get; set; } = default!;
    }
}