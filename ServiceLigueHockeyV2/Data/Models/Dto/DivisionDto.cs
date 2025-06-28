using System;
using System.Collections.Generic;

namespace ServiceLigueHockey.Data.Models.Dto
{
    public class DivisionDto
    {
        public int Id { get; set; } = int.MinValue;

        public string NomDivision { get; set; } = default!;

        public int AnneeDebut { get; set; } = int.MinValue;

        public int? AnneeFin { get; set; } = null;

        public int ConferenceId { get; set; } = default!;

        public ConferenceDto ConferenceParent { get; set; } = default!;
    }
}