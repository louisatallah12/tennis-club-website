using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    abstract class Competition : Evenement, ICout<Competiteur>
    {
        private string sexe_compet;         //genre de la competion : Masculin ou Feminin
        private int age_min;                //age minimal pour y participer
        private string nom;                 //nom de la competition
        private string niveau;
        private double classement_max;
        private int duree;        //durée en jours
        private int nb_match;       //nombre de match que reserve l'évenement
        private int prix;       //prix de la competition
        private int nb_joueur;          //nombre de joueur minimal
        private static int nombre_competition;      //compteur 

        public Competition(string nom,string niveau,int age_min,double classement_max,int duree,int nb_match,int prix,int nb_joueur,string sexe_compet)
        {
            this.sexe_compet = sexe_compet;
            this.age_min = age_min;
            this.classement_max = classement_max;
            this.nom = nom;
            this.niveau = niveau;
            this.duree = duree;
            this.prix = prix;
            this.nb_joueur = nb_joueur;
            this.nb_match = nb_match;
            nombre_competition++;
        }
        /// <summary>
        /// propriété permettant de connaitre le nombre de compétitions déjà créées
        /// </summary>
        public int Nombre_Competition
        {
            get { return nombre_competition; }
        }
        public int Nb_Joueur
        {
            get { return nb_joueur; }
        }
        public string Sexe_Compet
        {
            get { return sexe_compet; }
        }
        public int Age_Min
        {
            get { return age_min; }
        }
        public double Classment_Max
        {
            get { return classement_max; }
        }
        public string Nom
        {
            get { return nom; }
        }
        /// <summary>
        /// Methode abstract qui permet d'ajouter des participants à la competition - Les 2 classes filles (Team & Simple) utilisent la meme signature de fonction mais le contenu n'est pas similaire
        /// </summary>
        /// <param name="c"><le competiteur>
        /// <param name="e"><equipe dans laquelle il est ajouté>
        public abstract void Ajouter(Competiteur c,Equipe e);
        /// <summary>
        /// Utilisation de l'interface ICout
        /// </summary>
        /// <param name="c"><Competiteur>
        /// <returns><le prix de la competition affecté au membre>
        public int Cout(Competiteur c)
        {
            return c.Prix = prix;      //Le prix de la competition s'enregistre sur le profil du competiteur qui devra s'en acquiter
        }
        /// <summary>
        /// Methode abstract pour vérifier si la competition peut être lancée
        /// </summary>
        public abstract void Verification();
        
        public override string ToString()
        {
            return "Competition : "+nom+"\n";
        }
    }
}
