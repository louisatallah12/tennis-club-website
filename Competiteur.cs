using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Competiteur : Membre, IComparable
    {
        private double classement;
        private int point;
        private int victoire;
        private int defaite;

        public Competiteur(string nom, string prenom, string adresse, DateTime naissance,int telephone, string sexe, bool cotisation_payee,double classement,int point=0,int victoire=0,int defaite=0) : base(nom, prenom, adresse, naissance,telephone, sexe,  cotisation_payee)
        {
            this.classement = classement;
            this.point = point;
            this.victoire = victoire;
            this.defaite = defaite;
        }
        public double Classement
        {
            get { return classement; }
        }
        public int Point
        {
            get { return point; }
            set { point = value; }
        }
        public int Victoire
        {
            get { return victoire; }
            set { victoire = value; }
        }
        public int Defaite
        {
            get { return defaite; }
            set { defaite = value; }
        }
        /// <summary>
        /// on retourne le montant et on y ajoute le cout de la gestion qui est de 20€
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override int Cout(Club c)
        {
            return base.Cout(c)+20;
        }
        /// <summary>
        /// Compare le classement entre les competiteurs du mieux classé au moins bien classé
        /// </summary>
        /// <param name="o"><utilisation de IComparable donc CompareTo prend un type object en parametre>
        /// <returns></returns>
        public int CompareTo(object o)
        {
            int result = 0;
            if (classement < (o as Competiteur).Classement) result = -1;
            if (classement > (o as Competiteur).Classement) result = 1;
            return result;
        }
        /// <summary>
        /// Methodes affectant les points aux joueurs suivant les résultats des matchs joués
        /// </summary>
        /// <returns></returns>
        public int Matches_Joués()  //retourne le nombre de matchs joués d'un joueur
        {
            return victoire + defaite;
        }
        public void MatchSimpleGagné()
        {
            point += 2;
            victoire += 1;
        }
        public void MatchDoubleGagné()
        {
            point += 1;
            victoire += 1;
        }
        public void MatchPerdu()
        {
            defaite += 1;
        }
        public void MatchAnnulé()
        {
            point -= 1;
            defaite += 1;       //on considere que le match annulé compte comme une defaite 
        }
        public void StatistiqueJoueur()
        {
        
            Console.WriteLine("Nom/Prenom : " + Nom + "/" + Prenom + "\nMatchs disputés : " + Matches_Joués() + "\nMatchs perdus : " + defaite + "\nMatch remportés : " + victoire);
            Console.WriteLine("--------------------------------------------");
        }

        public override string ToString()
        {
            return "Nom/Prenom : " +this.Nom+"/"+this.Prenom +"\nType : Competition \nClassement : "+classement+ "\nSexe : " + Sexe + "\nCotisation : " + this.Prix + "\n ------------\n";
        }
    }
}
