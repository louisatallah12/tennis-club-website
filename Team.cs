using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Team : Competition
    {
        private int match_simple;
        private int match_double;
        private List< Equipe> equipe;
        public Team(string nom, string niveau, int age_min, double classement_max, int duree, int nb_match, int prix, int nb_joueur,string sexe_compet, int match_simple, int match_double, List< Equipe> equipe) : base(nom, niveau, age_min, classement_max, duree, nb_match, prix, nb_joueur,sexe_compet)
        {
            this.match_simple = match_simple;
            this.match_double = match_double;
            this.equipe = equipe;
        }
        public List<Equipe> Equipe
        {
            get { return equipe; }
        }
        public  override void Ajouter(Competiteur c,Equipe e)
        {
            int age = DateTime.Now.Year - c.Naissance.Year;
            if (c.Sexe==Sexe_Compet && age>=Age_Min && c.Classement>=Classment_Max)     //critères pour etre accepté dans la competition
            {
                e.Joueur.Add(c);
                Console.WriteLine("Le membre a bien été ajouté");
            }
            else
            {
                Console.WriteLine("Le joueur souhaitant participé n'est pas quallifié");
            }
        }
        public override void Verification()
        {
            int participants = 0;
            foreach(Equipe e in equipe)
            {
                participants += e.Joueur.Count;
            }
            if (participants < Nb_Joueur)       //si les participants sont inférieurs au nombre de joueur minimal alors la competition ne peut se dérouler
            {
                Console.WriteLine("La liste de joueur est incomplète, pour le moment la compétition "+Nom+" n'est pas valide");
            }
            else
            {
                Console.WriteLine("la competition " +Nom+" est prête à débuter");
            }
        }
        public override string ToString()
        {
            int participants=0;
            string msg= base.ToString()+"Type : Equipe \nNombre d'Equipes : "+equipe.Count+"\nParticipants : ";
            foreach(Equipe e in equipe)
            {
                participants += e.Joueur.Count;
            }
            msg += participants;
            return msg;
        }
    }
}
