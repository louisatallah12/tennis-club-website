using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Stage : Evenement
    {
        private List<Membre> mineur;
        private Entraineur entraineur;
        private bool paye;              //true or false si le stagiaire s'est acquité du montant
        private int age;
        private string niveau;
        
        public Stage(List<Membre> mineur,Entraineur entraineur,bool paye,int age,string niveau)
        {
            this.mineur = mineur;
            this.entraineur = entraineur;
            this.paye = paye;
            this.age = age;
            this.niveau = niveau;
        }
        /// <summary>
        /// Methode qui ajoute les nouveaux stagiaires selon les criteres de selection
        /// </summary>
        /// <param name="m"></param>
        public void AjouterSatgiaire(Membre m)
        {
            if (m.Age()==age && paye == true && mineur.Count<5)
            {
                mineur.Add(m);
                Console.WriteLine("Le membre a bien été ajouté au stage");
            }
            else
            {
                Console.WriteLine("Le membre n'est pas qualifié pour ce stage ou bien il ne reste plus de places");
            }
        }
    }
}
