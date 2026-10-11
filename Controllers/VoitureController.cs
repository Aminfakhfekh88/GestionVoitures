using Microsoft.AspNetCore.Mvc;
using GestionVoitures.Models;
using System.Linq;
using System.Collections.Generic;

namespace GestionVoitures.Controllers
{
    public class VoitureController : Controller
    {
        // 1. Liste STATIQUE en mémoire vive (RAM - Random Access Memory) partagée entre les requêtes
        private static List<Voiture> _voitures = new List<Voiture>
        {
            new Voiture { Id = 1, Marque = "Toyota", Modele = "Yaris", Annee = 2022, PrixJour = 80.00m, EstDisponible = true },
            new Voiture { Id = 2, Marque = "Renault", Modele = "Clio 5", Annee = 2023, PrixJour = 95.00m, EstDisponible = true },
            new Voiture { Id = 3, Marque = "Volkswagen", Modele = "Golf 8", Annee = 2021, PrixJour = 140.00m, EstDisponible = false }
        };

        // ========================================================
        // 1. AFFICHER LA LISTE DES VOITURES (READ)
        // Requête HTTP GET: /Voiture ou /Voiture/Index
        // ========================================================
        public IActionResult Index()
        {
            return View(_voitures);
        }

        // ========================================================
        // 2. AJOUTER UNE VOITURE (CREATE)
        // ========================================================
        // Requête HTTP GET: /Voiture/Create (Affiche le formulaire d'ajout vide)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Requête HTTP POST: /Voiture/Create (Reçoit et enregistre la voiture soumise)
        [HttpPost]
        public IActionResult Create(Voiture nouvelleVoiture)
        {
            // Attribution automatique d'un nouvel identifiant (ID) unique
            int nouvelId = _voitures.Any() ? _voitures.Max(v => v.Id) + 1 : 1;
            nouvelleVoiture.Id = nouvelId;

            // Ajout dans la liste statique en mémoire
            _voitures.Add(nouvelleVoiture);

            // Redirection vers l'affichage de la liste
            return RedirectToAction(nameof(Index));
        }

        // ========================================================
        // 3. MODIFIER UNE VOITURE (UPDATE)
        // ========================================================
        // Requête HTTP GET: /Voiture/Edit/2 (Affiche le formulaire pré-rempli avec la voiture existante)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var voiture = _voitures.FirstOrDefault(v => v.Id == id);
            if (voiture == null)
            {
                return NotFound(); // Erreur 404 si la voiture n'existe pas
            }
            return View(voiture);
        }

        // Requête HTTP POST: /Voiture/Edit/2 (Valide et applique les modifications saisies)
        [HttpPost]
        public IActionResult Edit(Voiture voitureModifiee)
        {
            var voitureExistante = _voitures.FirstOrDefault(v => v.Id == voitureModifiee.Id);
            if (voitureExistante == null)
            {
                return NotFound();
            }

            // Mise à jour des valeurs de l'objet existant
            voitureExistante.Marque = voitureModifiee.Marque;
            voitureExistante.Modele = voitureModifiee.Modele;
            voitureExistante.Annee = voitureModifiee.Annee;
            voitureExistante.PrixJour = voitureModifiee.PrixJour;
            voitureExistante.EstDisponible = voitureModifiee.EstDisponible;

            return RedirectToAction(nameof(Index));
        }

        // ========================================================
        // 4. SUPPRIMER UNE VOITURE (DELETE)
        // ========================================================
        // Requête HTTP GET: /Voiture/Delete/3 (Affiche la page de confirmation de suppression)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var voiture = _voitures.FirstOrDefault(v => v.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }
            return View(voiture);
        }

        // Requête HTTP POST: /Voiture/Delete/3 (Effectue la suppression définitive dans la liste)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var voiture = _voitures.FirstOrDefault(v => v.Id == id);
            if (voiture != null)
            {
                _voitures.Remove(voiture);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}