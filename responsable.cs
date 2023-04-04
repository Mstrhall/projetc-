using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJET_labo
{
    internal class responsable
    {
        int code;//code du responsable 
        string matricule;// matricule du responsable 
        string nom; //nom du responsable 
        string prenom;// prenom du responsable 
        string date_embauche;// date embauche du responsable 
        string region; // region du responsable 

        public responsable(int code, string matricule, string nom, string prenom, string date_embauche, string region)
        {
            this.Code = code;
            this.Matricule = matricule;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Date_embauche = date_embauche;
            this.Region = region;
        }

        public int Code { get => code; set => code = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Date_embauche { get => date_embauche; set => date_embauche = value; }
        public string Region { get => region; set => region = value; }
    }
}
