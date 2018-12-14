namespace Circusdieren_2
{
    class Dier
    {
        // @Todo Properties van maken
        public int grootte { get; private set; }
        public bool isVleeseter { get; private set; }
        private string naam;

        public Dier(int grootte, bool isVleeseter, string naam)
        {
            this.grootte = grootte;
            this.isVleeseter = isVleeseter;
            this.naam = naam;
        }

        //Aparte tostring

        public string GetDetails()
        {
            string detailString = naam + ", " + grootte + " groot, " + "eet vlees: " + isVleeseter + ". ";

            return detailString;
        }
        public override string ToString()
        {
            string tostring = naam + ", " + grootte + " groot, " + "eet vlees: " + isVleeseter + ". ";
            
            return tostring;
        }
    }
}
