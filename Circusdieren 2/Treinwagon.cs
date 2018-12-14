using System.Collections.Generic;

namespace Circusdieren_2
{
    class Treinwagon
    {
        public List<Dier> DierenAanBoord { get; private set; }
        public int OnBoard { get; private set; }
        private readonly int _nummer;

        public Treinwagon(int nummer)
        {
            OnBoard = 0;
            DierenAanBoord = new List<Dier>();
            _nummer = nummer;
        }

        public bool CanAddDier(Dier dier)
        {
            if(IsRuimte(dier) && !EtenElkaar(dier))
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool AddDier(Dier dier)
        {
            if (CanAddDier(dier))
            {
                DierenAanBoord.Add(dier);
                OnBoard += dier.Grootte;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsRuimte(Dier dier)
        {
            if (OnBoard == 10)
            {
                return false;
            }
            else if (dier.Grootte + OnBoard > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool EtenElkaar(Dier dier)
        {
            //Default
            bool etenelkaar = false; 

            //Vergelijkt of het dier niet opgegeten wordt door een dier aanboord
            //en vice versa
            foreach(Dier dierAb in DierenAanBoord)
            {
                //Controleert of het dier aanboord wel of geen vleeseter is
                if (dierAb.IsVleeseter || dier.IsVleeseter)
                {
                    //Mogen beide geen vleeseters zijn
                    if (dierAb.IsVleeseter && dier.IsVleeseter)
                    {
                        etenelkaar = true;
                    }
                    //Controleert of een planteneter groter is dan een aanwezige vleeseter
                    else if(dier.Grootte > dierAb.Grootte && dier.Grootte != dierAb.Grootte && !dier.IsVleeseter)
                    {
                        etenelkaar = false;
                    }else
                    {
                        etenelkaar = true;
                        break;
                    }
                }else
                {
                    if(dier.IsVleeseter && dierAb.Grootte >= dier.Grootte)
                    {
                        etenelkaar = true;
                        break;
                    }
                    else
                    {
                        etenelkaar = false;
                    }
                }
                
            }
            return etenelkaar;
        }

        public override string ToString()
        {
            string tostring = "Wagon " + _nummer;

            

            return tostring;
        }
    }
}
