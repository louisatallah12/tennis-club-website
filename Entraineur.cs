using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Entraineur : Competiteur
    {
        private double salaire;
        private DateTime entree;
        private string statut;

        public Entraineur(string nom, string prenom, string adresse, DateTime naissance,int telephone, string sexe, bool cotisation_payee, double classement,double salaire,DateTime entree,string statut, int point = 0, int victoire = 0, int defaite = 0) : base(nom, prenom, adresse, naissance,telephone, sexe,  cotisation_payee, classement, point, victoire, defaite)
        {
            this.entree = entree;
            this.statut = statut;
            this.salaire = salaire;
        }
        public override string ToString()
        {
            return "Nom/Prenom : " + this.Nom + "/" + this.Prenom + "\nType : Entraineur \nClassement : " + Classement + "\nSexe : " + Sexe + "\nCotisation : " + this.Prix+" \nSalaire :" + salaire + " € \nAncienneté :" + entree+"\nStatut : "+statut+ "\n ------------";
        }
    }
}
