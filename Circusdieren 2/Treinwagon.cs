using System.Collections.Generic;

namespace Circusdieren_2
{
    class Treinwagon
    {
        public List<Dier> dierenAanBoord { get; private set; }
        public int onBoard { get; private set; }
        private int nummer;

        public Treinwagon(int nummer)
        {
            onBoard = 0;
            dierenAanBoord = new List<Dier>();
            this.nummer = nummer;
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
                dierenAanBoord.Add(dier);
                onBoard += dier.grootte;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsRuimte(Dier dier)
        {
            if (onBoard == 10)
            {
                return false;
            }
            else if (dier.grootte + onBoard > 10)
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
            foreach(Dier dierAB in dierenAanBoord)
            {
                //Controleert of het dier aanboord wel of geen vleeseter is
                if (dierAB.isVleeseter || dier.isVleeseter)
                {
                    //Mogen beide geen vleeseters zijn
                    if (dierAB.isVleeseter && dier.isVleeseter)
                    {
                        etenelkaar = true;
                    }
                    //Controleert of een planteneter groter is dan een aanwezige vleeseter
                    else if(dier.grootte > dierAB.grootte && dier.grootte != dierAB.grootte && !dier.isVleeseter)
                    {
                        etenelkaar = false;
                    }else
                    {
                        etenelkaar = true;
                        break;
                    }
                }else
                {
                    if(dier.isVleeseter && dierAB.grootte >= dier.grootte)
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
            string tostring = "Wagon " + nummer;

            

            return tostring;
        }
    }
}
