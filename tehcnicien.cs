using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJET_labo
{
    internal class tehcnicien
    {
        int code;//code tecnicien 
        string matricule;//matricule technicien
        string nom; // nom tehcnicien
        string prenom;// prenom technicien 
        string formation;//formation du technicien 
        string niveau;// niveau du technicien 
        string competences;//competences du technicien 

        public tehcnicien(int code, string matricule, string nom, string prenom, string formation, string niveau, string competences)
        {
            this.Code = code;
            this.Matricule = matricule;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Formation = formation;
            this.Niveau = niveau;
            this.Competences = competences;
        }

        public int Code { get => code; set => code = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Formation { get => formation; set => formation = value; }
        public string Niveau { get => niveau; set => niveau = value; }
        public string Competences { get => competences; set => competences = value; }
    }
}
