using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJET_labo
{
    internal class employer
    {
        int code; //code employer 
        string matricule;//matricule employer 
        string nom;//nom employer
        string prenom;//prenom employer 

        public employer(int code, string matricule, string nom, string prenom)
        {
            this.Code = code;
            this.Matricule = matricule;
            this.Nom = nom;
            this.Prenom = prenom;
        }

        public int Code { get => code; set => code = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
    }
}
