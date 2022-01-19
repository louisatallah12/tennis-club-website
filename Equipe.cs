using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Equipe 
    {
        List<Competiteur> joueur;       //liste de joueur qui compose l'équipe
        string nom;             //le nom de l'équipe
        int numero;         //numero de l'equipe
        private static int n;           //compteur d'equipe pour attribuer les numeros d'equipe
        public Equipe(string nom,List<Competiteur> joueur,int numero)
        {
            this.nom = nom;
            this.joueur = joueur;
            this.numero = numero;
            n++;
        }
        public Equipe()
        {
            n++;
        }
        public List<Competiteur> Joueur
        {
            get { return joueur; }
        }
        public int N
        {
            get { return n; }
        }
        public string Nom
        {
            get { return nom; }
        }
        public override string ToString()
        {
            string msg = "Num Equipe : " + numero + "\nNom : " + nom+"\nMembres : "+joueur.Count+"\n";
            foreach(Competiteur c in joueur)
            {
                msg += c;
            }
            return msg;
        }
    }
}
