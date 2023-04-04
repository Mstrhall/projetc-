using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PROJET_labo
{

    internal class BD
    {
        public static bool verifconexionTechnicien(string matricule, string mdp)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT count(*) FROM techniciens, employer  WHERE techniciens.matricule = @matricule AND techniciens.matricule = salarie.matricule AND Mot_de_passe = @mdp";
            command1.Parameters.AddWithValue("@matricule", matricule);
            command1.Parameters.AddWithValue("@mdp", mdp);
            int nb = Convert.ToInt16(command1.ExecuteScalar());
            if (nb == 0)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public static bool verifconexionResponsable(string matricule, string mdp)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT count(*) FROM responsables, salarie  WHERE responsables.matricule = @matricule AND responsables.matricule = salarie.matricule AND Mot_de_passe = @mdp";
            command1.Parameters.AddWithValue("@matricule", matricule);
            command1.Parameters.AddWithValue("@mdp", mdp);
            int nb = Convert.ToInt16(command1.ExecuteScalar());
            if (nb == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool verifconexionUtilisateur(string matricule, string mdp)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT count(*) FROM utilisateurs, salarie  WHERE utilisateurs.matricule = @matricule AND utilisateurs.matricule = salarie.matricule AND Mot_de_passe = @mdp";
            command1.Parameters.AddWithValue("@matricule", matricule);
            command1.Parameters.AddWithValue("@mdp", mdp);
            int nb = Convert.ToInt16(command1.ExecuteScalar());
            if (nb == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static List<incident> consultincident()
        {
            List<incident> Lesdemandes = new List<incident>();
            incident unedemande;
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM incident ";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unedemande = new incident(Convert.ToInt16(dataReader["numero"]), Convert.ToString(dataReader["etat"]), Convert.ToString(dataReader["niveau_urgence"]));
                Lesdemandes.Add(unedemande);
            }
            conn.Close();
            return Lesdemandes;
        }
        public static List<materiel> consultmateriel()
        {
            List<materiel> lesmateriaux = new List<materiel>();
            materiel unMateriel;
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM materiel ";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unMateriel= new materiel(Convert.ToInt16(dataReader["code"]), Convert.ToString(dataReader["caracteristique"]), Convert.ToString(dataReader["nom"]), Convert.ToString(dataReader["element_contractuel"]), Convert.ToString(dataReader["date_achat"]), Convert.ToString(dataReader["processeur"]), Convert.ToString(dataReader["memoire"]), Convert.ToString(dataReader["disque"]), Convert.ToString(dataReader["garantie_fournisseur"]), Convert.ToString(dataReader["affectation"]) );
                lesmateriaux.Add(unMateriel);
            }
            conn.Close();
            return lesmateriaux;
        }

        //---------------------------- AJOUT ---------------------------------
        public static void ajoutSalarie(employer unEmployer )
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO salarie Values (@matricule, @code, @mdp)";
            command1.Parameters.AddWithValue("@matricule", unEmployer.Matricule);
            command1.Parameters.AddWithValue("@code", unEmployer.Code);
            command1.Parameters.AddWithValue("@nom", unEmployer.Nom);
            command1.Parameters.AddWithValue("@prenom", unEmployer.Prenom);
            command1.ExecuteNonQuery();
            conn.Close();
        }
        public static void ajoutTechniciens(tehcnicien unTechnicien)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO techniciens VALUES (@code, @matricule, @nom, @prenom, @formation, @niveau, @competence)";
            command1.Parameters.AddWithValue("@code", unTechnicien.Code);
            command1.Parameters.AddWithValue("@matricule", unTechnicien.Matricule);
            command1.Parameters.AddWithValue("@nom", unTechnicien.Nom);
            command1.Parameters.AddWithValue("@prenom", unTechnicien.Prenom);
            command1.Parameters.AddWithValue("@formation", unTechnicien.Formation);
            command1.Parameters.AddWithValue("@niveau", unTechnicien.Niveau);
            command1.Parameters.AddWithValue("@competence", unTechnicien.Competences);
        
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void ajoutUtilisateurs(utilisateur unUtilisateur)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO utilisateurs VALUES (@code, @matricule, @nom)";
            command1.Parameters.AddWithValue("@code", unUtilisateur.Code);
            command1.Parameters.AddWithValue("@matricule", unUtilisateur.Matricule);
            command1.Parameters.AddWithValue("@nom", unUtilisateur.Nom);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void ajoutResponsables(responsable unResponsable)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO responsables VALUES (@code, @matricule, @nom, @prenom,@Date_Embauche, @affectation_budget)";
            command1.Parameters.AddWithValue("@code", unResponsable.Code);
            command1.Parameters.AddWithValue("@matricule", unResponsable.Matricule);
            command1.Parameters.AddWithValue("@nom", unResponsable.Nom);
            command1.Parameters.AddWithValue("@prenom", unResponsable.Prenom);
            command1.Parameters.AddWithValue("@date_Embauche", unResponsable.Date_embauche);
            command1.Parameters.AddWithValue("@region", unResponsable.Region);

            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void ajoutMateriel(materiel unMateriel)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO materiel VALUES (@code, @nom, @element_contractuel, @processeur, @memoire, @disque, @garantie , @garantie, @date,)";
            command1.Parameters.AddWithValue("@code", unMateriel.Code);
            command1.Parameters.AddWithValue("@nom", unMateriel.Nom);
            command1.Parameters.AddWithValue("@element_contractuel", unMateriel.Element_contractuel);
            command1.Parameters.AddWithValue("@processeur", unMateriel.Processeur);
            command1.Parameters.AddWithValue("@memoire", unMateriel.Memoire);
            command1.Parameters.AddWithValue("@disque", unMateriel.Disque);
            command1.Parameters.AddWithValue("@garantie", unMateriel.Garantie_fournisseur);
            command1.Parameters.AddWithValue("@affectation", unMateriel.Affectation);
            command1.Parameters.AddWithValue("@date", unMateriel.Date_achat);
          
            string req = command1.CommandText;
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void ajoutincident(incident unIcident)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO demande_intervention VALUES (@numero, @etat, @niveau_urgence)";
            command1.Parameters.AddWithValue("@numero", unIcident.Numero);
            command1.Parameters.AddWithValue("@etat", unIcident.Etat);
            command1.Parameters.AddWithValue("@niveau_urgence", unIcident.Niveau_urgence);

            command1.ExecuteNonQuery();
            conn.Close();
        }

        //------------------------- SUPRESSION ---------------------------------
        public static void supprimerEmployer(string Lematricule)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM employer WHERE matricule = @matricule";
            command1.Parameters.AddWithValue("@matricule", Lematricule);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void supprimerTechniciens(string Lematricule)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM technicien WHERE matricule = @matricule";
            command1.Parameters.AddWithValue("@matricule", Lematricule);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void supprimerUtilisateurs(string Lematricule)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM utilisateurs WHERE matricule = @matricule";
            command1.Parameters.AddWithValue("@matricule", Lematricule);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void supprimerResponsables(string Lematricule)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM responsables WHERE matricule = @matricule";
            command1.Parameters.AddWithValue("@matricule", Lematricule);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void supprimerMateriel(string Lematricule)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE INTO materiel WHERE matricule = @matricule";
            command1.Parameters.AddWithValue("@matricule", Lematricule);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        public static void supprimerincident(string Lematricule)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM incident WHERE matricule = @matricule";
            command1.Parameters.AddWithValue("@matricule", Lematricule);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        //------------------------MODIFICATION------------------------------

        public static void modifierEmployer()
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "";
            command1.ExecuteNonQuery();
        }

        public static void modifierTechniciens(tehcnicien unTechnicien, string Lematricule)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "UPDATE salarie SET niveau_intervention = '@niveau_intervention' WHERE matricule = @matricule ";
            command1.Parameters.AddWithValue("@matricule", Lematricule);
            command1.ExecuteNonQuery();
        }

        public static void modifierUtilisateurs()
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = " ";
            command1.ExecuteNonQuery();
        }

        public static void modifierResponsables()
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = " ";
            command1.ExecuteNonQuery();
        }

        public static void modifierincident(incident unIncident, int code)
        {
            string connString = "Server=127.0.0.1;Database = Projet;Uid = root;Password =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "UPDATE incident SET etat = 'resolut' WHERE matricule = @matricule  ";
            command1.Parameters.AddWithValue("@matricule", code);
            command1.ExecuteNonQuery();
        }


    }
}

