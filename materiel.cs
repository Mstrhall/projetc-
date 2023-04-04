using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJET_labo
{
    internal class materiel
    {
        int code;
        string caracteristique;
        string nom;
        string element_contractuel;
        string date_achat;
        string processeur;
        string memoire;
        string disque;
        string garantie_fournisseur;
        string affectation;

        public materiel(int code, string caracteristique, string nom, string element_contractuel, string date_achat, string processeur, string memoire, string disque, string garantie_fournisseur, string affectation)
        {
            this.code = code;
            this.caracteristique = caracteristique;
            this.nom = nom;
            this.element_contractuel = element_contractuel;
            this.date_achat = date_achat;
            this.processeur = processeur;
            this.memoire = memoire;
            this.disque = disque;
            this.garantie_fournisseur = garantie_fournisseur;
            this.affectation = affectation;
        }

        public int Code { get => code; set => code = value; }
        public string Caracteristique { get => caracteristique; set => caracteristique = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Element_contractuel { get => element_contractuel; set => element_contractuel = value; }
        public string Date_achat { get => date_achat; set => date_achat = value; }
        public string Processeur { get => processeur; set => processeur = value; }
        public string Memoire { get => memoire; set => memoire = value; }
        public string Disque { get => disque; set => disque = value; }
        public string Garantie_fournisseur { get => garantie_fournisseur; set => garantie_fournisseur = value; }
        public string Affectation { get => affectation; set => affectation = value; }
    }
}
