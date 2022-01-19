using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    /// <summary>
    /// classe abstract car il n'y aura jamais de création d'instance de cette classe mais seulement de ses classes filles
    /// </summary>
    abstract class Membre : Acteur, ICout<Club>
    {
        private string sexe;
        private bool cotisation_payee;   //true = le membre a payé sa cotisation
        private int prix;              //prix de la cotisation
        public Membre(string nom, string prenom, string adresse, DateTime naissance,int telephone,string sexe, bool cotisation_payee) : base(nom, prenom, adresse, naissance,telephone)
        {
            this.sexe = sexe;
            this.cotisation_payee=  cotisation_payee;
            this.prix = 0;
        }
        public string Sexe
        {
            get { return sexe; }
        }
        public int Prix
        {
            get {return this.prix;}
            set { this.prix = value; }
        }
        public bool Cotisation_Payee
        {
            get { return this.cotisation_payee; }
            set { this.cotisation_payee = value; }
        }
        /// <summary>
        /// Methode qui calcule la cotisation de chaque membre en fonction de son age et de son lieu de residence par rapport au club
        /// </summary>
        /// <param name="c"><le club>
        /// <returns><retourne le prix>
        public virtual int Cout(Club c)
        {

            int age = Age();
            if (this.Adresse == c.Adresse)
            {
                if (age >= 18)
                {
                    this.prix = 200;
                }
                else
                {
                    this.prix = 130;
                }
            }
            else
            {
                if (age >= 18)
                {
                    this.prix = 280;
                }
                else
                {
                    this.prix = 180;
                }
            }
            return this.prix;
        }
        public string Verification_Paiement()
        {
            if (cotisation_payee == true)
            {
                return "Le membre " + Nom + "/" + Prenom + " a payé sa cotisation";
            }
            else
            {
                return "Le membre " + Nom + "/" + Prenom + " n'a pas payé sa cotisation";

            }
        }

    }
}
