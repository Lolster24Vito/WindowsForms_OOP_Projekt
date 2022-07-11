using DAL.Models;
using DAL.REPO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp_Projekt
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class UserSettingsWindow : Window
    {
        private const string HR = "hr", EN = "en";
        private const string USER_SETTINGS_PATH = DAL.Constants.ApiConstants.USER_SETTINGS_PATH;
        private UserSettings settings = new UserSettings();
        public static bool needToBeChecked = false;

        private  List<Point> resolutions = new List<Point> {
           new Point(960,540), new Point(1024,768),new Point(1366,768)
        };


        public UserSettingsWindow()
        {
            InitializeComponent();
            LoadResolutionsComboBox();
            LoadSettings();
        }

        private void LoadResolutionsComboBox()
        {
            cbResolutions.Items.Clear();
            cbResolutions.ItemsSource = resolutions;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfFormValid())
            {

                try
                {
                    FileRepo.SaveToFile(settings.ToString(), USER_SETTINGS_PATH);
                }
                catch (Exception)
                {

                    throw;
                }
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Niste popunili sve vrijednosti");
            }
        }

        private bool CheckIfFormValid()
        {
            return ((rbCroatian.IsChecked==true||rbEnglish.IsChecked==true)&&cbChampionship.SelectedIndex!=-1&&cbWindowMode.SelectedIndex!=-1);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }
        private async void LoadSettings()
        {
           await LoadUserSettingsAsync();

        }

        private void LanguageChanged(object sender, RoutedEventArgs e)
        {
            CheckRadioButtons();
        }

        private void CheckRadioButtons()
        {
            if (rbCroatian.IsChecked==true)
            {
                SetCulture(HR);
                settings.LanguageCode = HR;


            }
            if (rbEnglish.IsChecked==true)
            {
                SetCulture(EN);
                settings.LanguageCode = EN;

            }
        }

        private void SetCulture(string language)
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void cbChampionship_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.ChampionshipGroup = (ChampionshipType)cbChampionship.SelectedIndex;

        }

        private void cbWindowMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbWindowMode.SelectedIndex == 1)
            {
                settings.IsFullscreen = false;

            }
            if (cbWindowMode.SelectedIndex == 0)
            {
                settings.IsFullscreen=true;
            }
            
        }

        private void cbResolutions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.Resolution =(Point)cbResolutions.SelectedItem;
        }

        private async Task LoadUserSettingsAsync()
        {
            try
            {
                string fileLines = await FileRepo.ReadFromFile(USER_SETTINGS_PATH);

                settings = UserSettings.ParseFromString(fileLines);

                if (settings.LanguageCode == HR)
                {
                    rbCroatian.IsChecked = true;
                }
                if (settings.LanguageCode == EN)
                {
                    rbEnglish.IsChecked = true;
                }
                if (settings.ChampionshipGroup == ChampionshipType.Male)
                {
                    cbChampionship.SelectedIndex = 1;
                }
                if (settings.ChampionshipGroup == ChampionshipType.Female)
                {
                    cbChampionship.SelectedIndex = 0;
                }
                if (settings.IsFullscreen)
                {
                    cbWindowMode.SelectedIndex = 0;
                }
                else {
                    cbWindowMode.SelectedIndex = 1;

                }
                foreach (Point item in cbResolutions.Items)
                {
                    if (item == settings.Resolution)
                    {
                        cbResolutions.SelectedItem = item;
                        break;
                    }
                }



                needToBeChecked = false;
            }
            catch (Exception)
            {

                throw;
            }
            



        }
        

    }
}
