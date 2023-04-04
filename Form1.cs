using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJET_labo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void boutton_ajout_mat_Click(object sender, EventArgs e)
        {
            materiel unMateriel = new materiel(Convert.ToInt16(Box_code_mat.Text), Box_caracteristique_mat.Text, box_nom_mat.Text, Box_contrat_mat.Text, Box_achat_mat.Text, box_processeur_mat.Text, Box_memoire_mat.Text, Box_disque_mat.Text, Box_garantie_mat.Text, Box_affecation_mat.Text);
            BD.ajoutMateriel(unMateriel);
        }

        private void boutton_incident_Click(object sender, EventArgs e)
        {
            incident incident = new incident(Convert.ToInt16(Box_poste_icident.Text), Box_probleme_icident.Text, Box_urgence_inicident.Text);
            BD.ajoutincident(incident);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tehcnicien tehcnicien = new tehcnicien(Convert.ToInt16(box_id_tech), box_matricule_tec.Text, Box_nom.Text, box_prenom_tec.Text, box_formation_tech.Text, box_niveau_tech.Text, box_competences_tech.Text);

            BD.ajoutTechniciens(tehcnicien);
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ajout_uti_Click(object sender, EventArgs e)
        {
            utilisateur unUti = new utilisateur(Convert.ToInt16(box_id_uti.Text), box_matricule_uti.Text, box_nom_uti.Text, box_prenom_uti.Text);
            BD.ajoutUtilisateurs(unUti);
        }

        private void boutton_liste_avancement_incident_Click(object sender, EventArgs e)
        {
            List<incident> Lesdemandes = BD.consultincident();
            foreach (incident inc in Lesdemandes)
            {
                liste_Avancement.Items.Add(inc.Numero + " " + inc.Etat);
            }
        }

        private void bouton_consult_mat_Click(object sender, EventArgs e)
        {
            List<materiel> lesmateriaux = BD.consultmateriel();
            foreach (materiel materiel in lesmateriaux)
            {
                listBox_constulation_mat.Items.Add(materiel.Code + " " + materiel.Nom + " ");
            }
        }

        private void bouton_supression_mat_Click(object sender, EventArgs e)
        {
            List<materiel> lesmateriaux = BD.consultmateriel();
            foreach (materiel materiel in lesmateriaux)
            {
                if (materiel.Code == listBox_supression_matt.SelectedIndex)
                {
                    BD.supprimerMateriel(Convert.ToString(materiel.Code));
                }
            }
        }

        private void prise_en_charge_Click(object sender, EventArgs e)
        {
            List<incident> Lesdemandes = BD.consultincident();
            foreach (incident inc in Lesdemandes)
                if (inc.Numero == listebox_consultation_incident.SelectedIndex)
                {
                    inc.Etat = "prit en charge ";


                }
        }

        private void button_modif_Click(object sender, EventArgs e)
        {
            List<incident> Lesdemandes = BD.consultincident();
            foreach (incident inc in Lesdemandes)
            {
                if (inc.Numero == listebox_consultation_incident.SelectedIndex)
                {
                    BD.modifierincident(inc, inc.Numero);                    
                }
            }
        }

        private void bouton_moif_tech_Click(object sender, EventArgs e)
        {

        }
    }
}
        