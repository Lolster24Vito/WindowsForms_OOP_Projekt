using DAL.REPO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;

namespace WindowsForms_OOP_Projekt.Forms
{
    public partial class LanguageGenderForm : Form
    {
        private const string HR = "hr", EN = "en";
        private const string USER_SETTINGS_PATH = DAL.Constants.ApiConstants.USER_SETTINGS_PATH;
        private UserSettings settings = new UserSettings();
        public static bool needToBeChecked = false;
        public LanguageGenderForm()
        {
            InitializeComponent();
        }
        private async void LanguageGenderForm_Shown(object sender, EventArgs e)
        {
           await LoadUserSettingsAsync();

        }

        private async Task LoadUserSettingsAsync()
        {
            string fileLines = await FileRepo.ReadFromFile(USER_SETTINGS_PATH);

            settings = UserSettings.ParseFromString(fileLines);
            //this if is unneeded remove it TODO
            if (needToBeChecked == true)
            {

                if(settings!=null || (settings.LanguageCode != null && settings.ChampionshipGroup != null))
                {
                    OpenNextForm();
                }
            }
            else
            {
                SetUIForSettings();
            }

            needToBeChecked = false;



        }

        private void SetUIForSettings()
        {
            if (settings == null) return;
            if (settings.LanguageCode == HR)
            {
                rbCroatian.Checked = true;
            }
            if (settings.LanguageCode == EN)
            {
                rbEnglish.Checked = true;
            }
            if (settings.ChampionshipGroup == ChampionshipType.Male)
            {
                cbChampionship.SelectedIndex = 1;
            }
            if (settings.ChampionshipGroup == ChampionshipType.Female)
            {
                cbChampionship.SelectedIndex = 0;


            }
        }

        private void SetCulture(string language)
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

        }



        private void cbChampionship_SelectedValueChanged(object sender, EventArgs e)
        {
            //label3.Text = cbChampionship.SelectedIndex.ToString();
            settings.ChampionshipGroup =(ChampionshipType)cbChampionship.SelectedIndex;

        }

        private void rbCroatian_CheckedChanged(object sender, EventArgs e)
        {

            CheckCheckedRadioButtons();
        }

        private void rbEnglish_CheckedChanged(object sender, EventArgs e)
        {
            CheckCheckedRadioButtons();
        }

        private void CheckCheckedRadioButtons()
        {

            if (rbCroatian.Checked)
            {
                settings.LanguageCode = HR;
                SetCulture(HR);


            }
            if (rbEnglish.Checked)
            {
                settings.LanguageCode = EN;
                SetCulture(EN);

            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //check validation
            if (!((rbCroatian.Checked || rbEnglish.Checked) && cbChampionship.SelectedIndex != -1))
            {
                MessageBox.Show("Molim vas popunite sve vrijednosti");
                this.DialogResult = DialogResult.None;
                return;
            }
            try
            {
                FileRepo.SaveToFile(settings.ToString(), USER_SETTINGS_PATH);

            }
            catch (Exception)
            {

                throw;
            }

            DialogResult =DialogResult.OK;
            //Write to file
            //TRY
            

            OpenNextForm();

        }

        private void OpenNextForm()
        {
            this.Close();
        }





        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            OpenNextForm();


        }

        internal void SetNextDialogueCheck(bool check)
        {
                needToBeChecked = check;

           
        }
    }
}
