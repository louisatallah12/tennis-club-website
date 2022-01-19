using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Administratif : Acteur, IComparable<Administratif>
    {
        private double salaire;
        private DateTime entree;

        public Administratif(string nom, string prenom, string adresse, DateTime naissance,int telephone,double salaire,DateTime entree) :base(nom, prenom, adresse, naissance,telephone)
        {
            this.entree = entree;
            this.salaire = salaire;
        }
        public double Salaire
        {
            get { return salaire; }
        }
        public DateTime Entree
        {
            get { return entree; }
        }
        public int CompareTo(Administratif a)
        {
            return salaire.CompareTo(a.Salaire);
        }
        public override string ToString()
        {
            return "Salarié Nom/Prenom :"+Nom+"/"+Prenom+" \nSalaire :"+salaire+" € \nAncienneté :"+entree+"\n-------------";
        }
    }
}
