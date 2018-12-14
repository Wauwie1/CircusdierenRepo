using System.Collections.Generic;

namespace Circusdieren_2
{
    class Trein
    {
        public List<Treinwagon> Treinwagons { get; private set; }
        public List<Dier> AlleDieren { get; private set; }
        public Trein()
        {
            Treinwagons = new List<Treinwagon>();
            Treinwagon treinwagon = new Treinwagon(0);
            Treinwagons.Add(treinwagon);
            AlleDieren = new List<Dier>();
        }
        public void CreateTrein(List<Dier> dieren)
        {
            AlleDieren = dieren;
            foreach (Dier dier in AlleDieren)
            {
               AddDier(dier);
            }
            
        }

        private void AddDier(Dier dier)
        {
            bool animalIsAdded = false;
                for(int i = 0; i < Treinwagons.Count && !animalIsAdded; i++)
                {
                    if (Treinwagons[i].AddDier(dier))
                    {
                        animalIsAdded = true;
                    }
                    else if (i == Treinwagons.Count - 1)
                    {
                        Treinwagon newtreinwagon = new Treinwagon(i + 1);
                        Treinwagons.Add(newtreinwagon);
                        Treinwagons[i + 1].AddDier(dier);
                        animalIsAdded = true;
                    }
                
                }
            
        }
    }
}
