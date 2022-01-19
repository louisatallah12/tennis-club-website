using System;
using System.Collections.Generic;
using System.Text;

namespace ATALLAH_Louis_TD_A
{
    interface ICout<T>
    {
        /// <summary>
        /// Interface créée pour calculer le coup d'inscription de chaque membre ou le montant d'une competition
        /// </summary>
        /// <param name="val"></param>
        /// <returns><retourn le montant>
        int Cout(T val);
    }
}
