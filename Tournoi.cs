using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Tournoi : Evenement
    {
        private List<Membre> membre;
        private List<Entraineur> entraineur;

        public Tournoi(List<Membre> membre, List<Entraineur> entraineur)
        {
            this.membre = membre;
            this.entraineur = entraineur;
        }
        /// <summary>
        /// Methode qui verifie si le tournoi peut se derouler soit si il possede au moins dux entraineurs
        /// </summary>
        public void Verification()
        {
            if (entraineur.Count >= 2)
            {
                Console.WriteLine("Le tournoi peut se derouler");
            }
            else
            {
                int c = 2 - entraineur.Count;
                Console.WriteLine("Il manque encore " + c + " entraineur(s)");
            }
        }
    }
}
