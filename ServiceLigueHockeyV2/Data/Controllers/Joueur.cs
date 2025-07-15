using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data.Models;
using ServiceLigueHockey.Data.Models.Dto;

namespace ServiceLigueHockey.Data.Controllers
{
    /*
     * Controlleur pour JoueurBd
     */
    [ApiController]
    [Route("api/[controller]")]
    public class Joueur : ControllerBase
    {
        private readonly ServiceLigueHockeyContext _context;

        public Joueur(ServiceLigueHockeyContext context)
        {
            _context = context;
        }

        // GET: api/Joueur
        [HttpGet]
        public ActionResult<IQueryable<JoueurDto>> GetJoueurBd()
        {
            var listeJoueur = from joueur in _context.joueur
                              select new JoueurDto
                              {
                                  Id = joueur.Id,
                                  Prenom = joueur.Prenom,
                                  Nom = joueur.Nom,
                                  VilleNaissance = joueur.VilleNaissance,
                                  PaysOrigine = joueur.PaysOrigine,
                                  DateNaissance = joueur.DateNaissance
                              };
            return Ok(listeJoueur);
        }

        // GET: api/Joueur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JoueurDto>> GetJoueurBd(int id)
        {
            var joueurBd = await _context.joueur.FindAsync(id);

            if (joueurBd == null)
            {
                return NotFound();
            }

            var joueurDto = new JoueurDto
            {
                Id = joueurBd.Id,
                Prenom = joueurBd.Prenom,
                Nom = joueurBd.Nom,
                VilleNaissance = joueurBd.VilleNaissance,
                PaysOrigine = joueurBd.PaysOrigine,
                DateNaissance = joueurBd.DateNaissance
            };

            return Ok(joueurDto);
        }

        // GET: api/joueur/obtenirprenomnom/6
        [HttpGet("obtenirprenomnom/{JoueurId}")]
        public ActionResult<string> GetPrenomNomJoueur(int joueurId)
        {
            var lecture = from item in _context.joueur
                          where item.Id == joueurId
                          select new string(item.Prenom + " " + item.Nom);

            if (lecture == null)
            {
                return NotFound();
            }

            var strPrenomNomJoueur = lecture.FirstOrDefault();

            return Ok(strPrenomNomJoueur);
        }

        // PUT: api/Joueur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoueurBd(int id, JoueurBd joueurBd)
        {
            Console.WriteLine("Entrée dans PutJoueurBd");
            if (id != joueurBd.Id)
            {
                return BadRequest();
            }

            _context.Entry(joueurBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueurBdExists(id))
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

        // POST: api/Joueur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JoueurDto>> PostJoueurDto(JoueurDto joueur)
        {
            var joueurBd = new JoueurBd
            {
                Id = joueur.Id,
                Prenom = joueur.Prenom,
                Nom = joueur.Nom,
                DateNaissance = joueur.DateNaissance,
                VilleNaissance = joueur.VilleNaissance,
                PaysOrigine = joueur.PaysOrigine
            };

            try
            {
                _context.joueur.Add(joueurBd);
                await _context.SaveChangesAsync();

                joueur.Id = joueurBd.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CreatedAtAction("PostJoueurDto", joueur);
        }

        // DELETE: api/Joueur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoueurBd(int id)
        {
            var joueurBd = await _context.joueur.FindAsync(id);
            if (joueurBd == null)
            {
                return NotFound();
            }

            _context.joueur.Remove(joueurBd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JoueurBdExists(int id)
        {
            return _context.joueur.Any(e => e.Id == id);
        }
        
        [HttpPost("ajouterJoueurEtEquipe")]
        public async Task<ActionResult> AjouterJoueurEtEquipe([FromBody] JoueurEquipeCompleteDto donnees)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                // Créer le joueur
                var joueurBd = new JoueurBd
                {
                    Prenom = donnees.Joueur.Prenom,
                    Nom = donnees.Joueur.Nom,
                    DateNaissance = donnees.Joueur.DateNaissance,
                    VilleNaissance = donnees.Joueur.VilleNaissance,
                    PaysOrigine = donnees.Joueur.PaysOrigine
                };
                
                _context.joueur.Add(joueurBd);
                await _context.SaveChangesAsync(); // Sauvegarde pour obtenir l'ID du joueur
                
                // Créer la relation équipe-joueur
                var equipeJoueurBd = new EquipeJoueurBd
                {
                    EquipeId = donnees.EquipeJoueur.EquipeId,
                    JoueurId = joueurBd.Id, // Utiliser l'ID généré
                    NoDossard = donnees.EquipeJoueur.NoDossard,
                    DateDebutAvecEquipe = donnees.EquipeJoueur.DateDebutAvecEquipe,
                    DateFinAvecEquipe = donnees.EquipeJoueur.DateFinAvecEquipe
                };
                
                _context.equipeJoueur.Add(equipeJoueurBd);
                await _context.SaveChangesAsync();
                
                // Confirmer la transaction
                await transaction.CommitAsync();
                
                // Retourner les données complètes incluant le nom complet du joueur
                var equipeJoueurDto = new EquipeJoueurDto
                {
                    JoueurId = joueurBd.Id,
                    EquipeId = donnees.EquipeJoueur.EquipeId,
                    PrenomNomJoueur = $"{joueurBd.Prenom} {joueurBd.Nom}",
                    DateDebutAvecEquipe = donnees.EquipeJoueur.DateDebutAvecEquipe,
                    DateFinAvecEquipe = donnees.EquipeJoueur.DateFinAvecEquipe,
                    NoDossard = donnees.EquipeJoueur.NoDossard
                };
                
                return Ok(new { 
                    Message = "Joueur et relation équipe-joueur créés avec succès", 
                    JoueurId = joueurBd.Id,
                    EquipeJoueur = equipeJoueurDto
                });
            }
            catch (Exception ex)
            {
                // Annuler la transaction en cas d'erreur
                await transaction.RollbackAsync();
                return BadRequest($"Erreur lors de l'insertion : {ex.Message}");
            }
        }
    }
}