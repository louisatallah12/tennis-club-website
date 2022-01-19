using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ATALLAH_Louis_TD_A
{
    class Loisir : Membre
    {
        public Loisir(string nom, string prenom, string adresse, DateTime naissance,int telephone, string sexe, bool cotisation_payee) : base(nom, prenom, adresse, naissance,telephone, sexe,  cotisation_payee)
        {

        }
        /// <summary>
        /// Methode permettant à un membre Loisir de reserver un terrain
        /// </summary>
        /// <param name="c"></param>
        public void ReserverTerrain(Club c)     
        {
            bool res = false;
            for (int i = 0; i < c.Terrains.Count; i++)
            {
                if (c.Terrains.ElementAt(i).Value.Libre == true && res==false)
                {
                    res = true;
                    c.Terrains.ElementAt(i).Value.Libre = false;
                    Console.WriteLine("Vous avez  reservé le terrain numero : " + c.Terrains.ElementAt(i).Key);
                }
                
            }
            if (res == false)
            {
                Console.WriteLine("Desolé, il ne reste plus de terrains disponibles");
            }
        }
        public override string ToString()
        {
            return "Nom/Prenom : " + this.Nom + "/" + this.Prenom + "\nType : Loisir \nSexe : "+Sexe+"\nCotisation : "+this.Prix+ "\n ------------\n";
        }
    }
}
