using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data.Models;
using ServiceLigueHockey.Data.Models.Dto;

namespace ServiceLigueHockey.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Partie : ControllerBase
    {
        private readonly ServiceLigueHockeyContext _context;

        public Partie(ServiceLigueHockeyContext context)
        {
            _context = context;
        }

        // GET: api/Partie
        [HttpGet]
        public ActionResult<IQueryable<PartieDto>> GetPartieDto()
        {
            var listeParties = from MonCalendrier in _context.parties
                               select new PartieDto
                               {
                                    IdPartie = MonCalendrier.IdPartie,
                                    IdEquipeHote = MonCalendrier.IdEquipeHote,
                                    IdEquipeVisiteuse = MonCalendrier.IdEquipeVisiteuse,
                                    AnneeStats = MonCalendrier.AnneeStats,
                                    DatePartieJouee = MonCalendrier.DatePartieJouee,
                                    NbreButsComptesParHote = MonCalendrier.NbreButsComptesParHote,
                                    NbreButsComptesParVisiteur = MonCalendrier.NbreButsComptesParVisiteur,
                                    AFiniEnProlongation = MonCalendrier.AFiniEnProlongation,
                                    AFiniEnTirDeBarrage = MonCalendrier.AFiniEnTirDeBarrage,
                                    EstUnePartieDeSerie = MonCalendrier.EstUnePartieDeSerie,
                                    EstUnePartiePresaison=MonCalendrier.EstUnePartiePresaison,
                                    EstUnePartieSaisonReguliere = MonCalendrier.EstUnePartieSaisonReguliere,
                                    SommairePartie = MonCalendrier.SommairePartie
                               };

            return Ok(listeParties);
        }

        // GET: api/Partie/5
        [HttpGet("{idPartie}")]
        public async Task<ActionResult<PartieDto>> GetPartieDto(int idPartie)
        {
            var partieBd = await _context.parties.FindAsync(idPartie);

            if (partieBd == null)
            {
                return NotFound();
            }

            var PartieDto = new PartieDto
            {
                IdPartie = partieBd.IdPartie,
                IdEquipeHote = partieBd.IdEquipeHote,
                IdEquipeVisiteuse = partieBd.IdEquipeVisiteuse,
                AnneeStats = partieBd.AnneeStats,
                DatePartieJouee = partieBd.DatePartieJouee,
                NbreButsComptesParHote = partieBd.NbreButsComptesParHote,
                NbreButsComptesParVisiteur = partieBd.NbreButsComptesParVisiteur,
                AFiniEnProlongation = partieBd.AFiniEnProlongation,
                AFiniEnTirDeBarrage = partieBd.AFiniEnTirDeBarrage,
                EstUnePartieDeSerie = partieBd.EstUnePartieDeSerie,
                EstUnePartiePresaison=partieBd.EstUnePartiePresaison,
                EstUnePartieSaisonReguliere = partieBd.EstUnePartieSaisonReguliere,
                SommairePartie = partieBd.SommairePartie
            };

            return Ok(PartieDto);
        }

        // PUT: api/Partie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idPartie}")]
        public async Task<IActionResult> PutPartie(int idPartie, PartieDto partie)
        {
            if (idPartie != partie.IdPartie)
            {
                return BadRequest();
            }

            var partieBd = new CalendrierBd
            {
                IdPartie = partie.IdPartie,
                IdEquipeHote = partie.IdEquipeHote,
                IdEquipeVisiteuse = partie.IdEquipeVisiteuse,
                AnneeStats = partie.AnneeStats,
                DatePartieJouee = partie.DatePartieJouee,
                NbreButsComptesParHote = partie.NbreButsComptesParHote,
                NbreButsComptesParVisiteur = partie.NbreButsComptesParVisiteur,
                AFiniEnProlongation = partie.AFiniEnProlongation,
                AFiniEnTirDeBarrage = partie.AFiniEnTirDeBarrage,
                EstUnePartieDeSerie = partie.EstUnePartieDeSerie,
                EstUnePartiePresaison = partie.EstUnePartiePresaison,
                EstUnePartieSaisonReguliere = partie.EstUnePartieSaisonReguliere,
                SommairePartie = partie.SommairePartie
            };

            _context.Entry(partieBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!partieBdExists(idPartie))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Partie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartieDto>> PostPartieDto(PartieDto partie)
        {
            var partieBd = new CalendrierBd
            {
                IdPartie = partie.IdPartie,
                IdEquipeHote = partie.IdEquipeHote,
                IdEquipeVisiteuse = partie.IdEquipeVisiteuse,
                AnneeStats = partie.AnneeStats,
                DatePartieJouee = partie.DatePartieJouee,
                NbreButsComptesParHote = partie.NbreButsComptesParHote,
                NbreButsComptesParVisiteur = partie.NbreButsComptesParVisiteur,
                AFiniEnProlongation = partie.AFiniEnProlongation,
                AFiniEnTirDeBarrage = partie.AFiniEnTirDeBarrage,
                EstUnePartieDeSerie = partie.EstUnePartieDeSerie,
                EstUnePartiePresaison=partie.EstUnePartiePresaison,
                EstUnePartieSaisonReguliere = partie.EstUnePartieSaisonReguliere,
                SommairePartie = partie.SommairePartie
            };

            _context.parties.Add(partieBd);
            await _context.SaveChangesAsync();

            partie.IdPartie = partieBd.IdPartie;

            return CreatedAtAction("PostPartieDto", partie);
        }

        // DELETE: api/Partie/5
        [HttpDelete("{idPartie}")]
        public async Task<IActionResult> DeletePartie(int idPartie)
        {
            var partieBd = await _context.parties.FindAsync(idPartie);
            if (partieBd == null)
            {
                return NotFound();
            }

            _context.parties.Remove(partieBd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool partieBdExists(int idPartie)
        {
            return _context.parties.Any(e => e.IdPartie == idPartie);
        }
    }
}
