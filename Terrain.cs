using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    class Terrain
    {
        private int numero;     //numero de terrain
        private bool libre;     //true si le terrain est libre et peut donc être réseervé

        public Terrain(int numero,bool libre=true)      //on part du principe que un terrain créé est libre par defaut
        {
            this.numero = numero;
            this.libre = libre;
        }
        public int Numero
        {
            get { return numero; }
        }
        public bool Libre
        {
            get { return libre; }
            set { libre = value; }
        }
        public override string ToString()
        {
            string msg = "Terrain numero : " + numero+"\nLibre : ";
            if (libre == true)
            {
                msg += "Oui";
            }
            else
            {
                msg += "Non";
            }
            return msg;
        }
    }
}
