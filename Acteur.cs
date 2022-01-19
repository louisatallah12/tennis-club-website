using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Acteur
    {
        private string nom;
        private string prenom;
        private string adresse;
        private DateTime naissance;
        private int telephone;

        public Acteur(string nom,string prenom,string adresse, DateTime naissance,int telephone)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.naissance = naissance;
            this.telephone = telephone;
        }
        public string Nom
        {
            get { return nom; }
        }
        public string Prenom
        {
            get { return prenom; }
        }

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public int Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public DateTime Naissance
        {
            get { return naissance; }
        }
        public int Age()
        {
            return DateTime.Now.Year - this.naissance.Year;
        }
    }
}
