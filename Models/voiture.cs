namespace GestionVoitures.Models
{
	public class Voiture
	{
		public int Id { get; set; }
		public string Marque { get; set; } = string.Empty;
		public string Modele { get; set; } = string.Empty;
		public int Annee { get; set; }
		public decimal PrixJour { get; set; }
		public bool EstDisponible { get; set; }
	}
}