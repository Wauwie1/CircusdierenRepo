namespace Circusdieren_2
{
    class Dier
    {
        public int Grootte { get; private set; }
        public bool IsVleeseter { get; private set; }
        private readonly string _naam;

        public Dier(int grootte, bool isVleeseter, string naam)
        {
            Grootte = grootte;
            IsVleeseter = isVleeseter;
            _naam = naam;
        }

        public string GetDetails()
        {
            string detailString = _naam + ", " + Grootte + " groot, " + "eet vlees: " + IsVleeseter + ". ";

            return detailString;
        }
        public override string ToString()
        {
            string tostring = _naam + ", " + Grootte + " groot, " + "eet vlees: " + IsVleeseter + ". ";
            
            return tostring;
        }
    }
}
