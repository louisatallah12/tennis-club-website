using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Simple : Competition
    {
        private List<Competiteur> joueur;

        public Simple(string nom, string niveau, int age_min, double classement_max, List<Competiteur> joueur, int duree, int nb_match, int prix, int nb_joueur,string sexe_compet) : base(nom, niveau, age_min, classement_max, duree, nb_match, prix, nb_joueur,sexe_compet)
        {
            this.joueur = joueur;
        }
        public List<Competiteur> Joueur
        {
            get { return joueur; }
        }
        public override void Ajouter(Competiteur c,Equipe e =null)
        {
            int age = DateTime.Now.Year - c.Naissance.Year;
            if (c.Sexe == Sexe_Compet && age >= Age_Min && c.Classement >= Classment_Max)
            {
                joueur.Add(c);
                Console.WriteLine("Le membre a bien été ajouté");

            }
            else
            {
                Console.WriteLine("Le joueur souhaitant participé n'est pas quallifié");
            }
        }
        public override void Verification()
        {
            if (joueur.Count < Nb_Joueur)
            {
                Console.WriteLine("La liste de joueur est incomplète, pour le moment la compétition "+Nom+" n'est pas valide");
            }
            else
            {
                Console.WriteLine("la competition simple "+Nom+" est prête à débuter");
            }
        }

        public override string ToString()
        {
            return base.ToString()+"Type : Simple \nParticipants : "+ joueur.Count;

        }
    }
}
