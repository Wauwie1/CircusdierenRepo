using System.Collections.Generic;

namespace Circusdieren_2
{
    class Trein
    {
        public List<Treinwagon> treinwagons { get; private set; }
        public List<Dier> alleDieren { get; private set; }
        public Trein()
        {
            treinwagons = new List<Treinwagon>();
            Treinwagon treinwagon = new Treinwagon(0);
            treinwagons.Add(treinwagon);
            alleDieren = new List<Dier>();
        }
        public void CreateTrein(List<Dier> dieren)
        {
            alleDieren = dieren;
            foreach (Dier dier in alleDieren)
            {
               AddDier(dier);
            }
            
        }

        private void AddDier(Dier dier)
        {
            bool animalIsAdded = false;
                for(int i = 0; i < treinwagons.Count && !animalIsAdded; i++)
                {
                    if (treinwagons[i].AddDier(dier))
                    {
                        animalIsAdded = true;
                    }
                    else if (i == treinwagons.Count - 1)
                    {
                        Treinwagon newtreinwagon = new Treinwagon(i + 1);
                        treinwagons.Add(newtreinwagon);
                        treinwagons[i + 1].AddDier(dier);
                        animalIsAdded = true;
                    }
                
                }
            
        }
    }
}
