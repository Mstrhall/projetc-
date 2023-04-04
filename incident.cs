using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJET_labo
{
    internal class incident
    {
        int numero;
        string etat;
        string niveau_urgence;

        public incident(int numero, string etat, string niveau_urgence)
        {
            this.numero = numero;
            this.Etat = etat;
            this.Niveau_urgence = niveau_urgence;
        }

        public int Numero { get => numero;  }
        public string Etat { get => etat; set => etat = value; }
        public string Niveau_urgence { get => niveau_urgence; set => niveau_urgence = value; }
    }
}
