using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Circusdieren_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Dier> dieren = new List<Dier>();
        Trein trein = new Trein();
        Random rand = new Random();
        
        public MainWindow()
        {
            InitializeComponent();
            AddDieren();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            trein.CreateTrein(dieren);
            stopwatch.Stop();
            Label_time.Content = Convert.ToString(stopwatch.ElapsedMilliseconds) + " ms";
            Log();
        }
        private void AddDieren()
        {

            int[] groottes = new int[3];
            groottes[0] = 1;
            groottes[1] = 3;
            groottes[2] = 5;

            for (int i = 0; i < 1000; i++)
            {

                Dier dierI = new Dier(groottes[rand.Next(0, 3)], GetRandomBoolean(), "Dier " + Convert.ToString(i));
                dieren.Add(dierI);
            }


        }
        public bool GetRandomBoolean()
        {
            return rand.Next(0, 2) == 0;
        }

        private void Log()
        {
            
            foreach(Treinwagon treinwagon in trein.treinwagons) {
                List_treinen.Items.Add(treinwagon);
                Console.WriteLine(treinwagon.ToString());
}               
        }

        private void List_treinen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List_dieren.Items.Clear();
            int index = List_treinen.SelectedIndex;


            foreach(Dier dier in trein.treinwagons[index].dierenAanBoord)
            {
                List_dieren.Items.Add(dier);
            }
        }
    }
}
