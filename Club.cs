using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Club
    {
        private string nom;
        private int compet;             //nombre de competitions à réaliser pour le club
        private string adresse;
        private List<Administratif> personnel;
        private List<Membre> membre;
        private SortedList<int,Terrain> terrains;

        public Club(string nom,int compet,string adresse, List<Administratif> personnel, List<Membre> membre, SortedList<int,Terrain> terrains)
        {
            this.compet = compet;
            this.nom = nom;
            this.adresse = adresse;
            this.personnel = personnel;
            this.membre = membre;
            this.terrains = terrains;
        }
        public string Adresse
        {
            get { return adresse; }
        }
        public int Compet
        {
            get { return compet; }
        }
        public SortedList<int,Terrain> Terrains
        {
            get { return terrains; }
        }
        /// <summary>
        /// Methode qui remet un terrain libre donc il peut à nouveau être reserver
        /// </summary>
        /// <param name="t"></param>
        public void LibererTerrain(Terrain t)
        {
            t.Libre = true;
        }
        public override string ToString()
        {
            string msg= "le club "+nom+" possede " + membre.Count + " membres dont : \n" ;
            foreach(Membre m in membre)
            {
                msg += m + "\n";
            }
            msg += "Avec comme personnel administratif : \n";
            foreach (Administratif m in personnel)
            {
                msg += m + "\n";
            }
            return msg;
        }
    }
}
