namespace registracija2
{
    public class Profils
    {
        public int Id { get; set; }
        public string Vards { get; set; }
        public string Uzvards { get; set; }
        public string Epasts { get; set; }
        public string Parole { get; set; }
        public string Parole1 { get; set; }

        internal static void Add(Profils profilsFromDatabase)
        {
            throw new NotImplementedException();
        }
    }
}
