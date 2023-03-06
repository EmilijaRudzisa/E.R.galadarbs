using System.Data.Common;
using System.Data.SqlClient;

namespace registracija2
{
    public class Registracijasreposetey
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=Kalendara_registracija;TrustServerCertificate=True;Integrated Security=True;";

        public void Add(Profils profils)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string insertKalendara_registracija = @"
                INSERT INTO dbo.Kalendara_registracija( Vards, Uzvards, Epasts, Parole, Parole1)
                VALUES ( @vards, @uzvards, @epasts, @parole, @parole1);";

            // Uztaisām vaicājuma komandu
            DbCommand insertProfilsCommand = sqlConnection.CreateCommand();

            insertProfilsCommand.CommandText = insertKalendara_registracija;
            insertProfilsCommand.CommandType = System.Data.CommandType.Text;

            DbParameter vardsParameter = insertProfilsCommand.CreateParameter();
            vardsParameter.ParameterName = "vards";
            vardsParameter.Value = profils.Vards;

            // Nodefinējam @uzvards parametru un tā vērtību
            DbParameter uzvardsParameter = insertProfilsCommand.CreateParameter();
            uzvardsParameter.ParameterName = "uzvards";
            uzvardsParameter.Value = profils.Uzvards;

            // Nodefinējam @epasts parametru un tā vērtību
            DbParameter epastsParameter = insertProfilsCommand.CreateParameter();
            epastsParameter.ParameterName = "epasts";
            epastsParameter.Value = profils.Epasts;

            // Nodefinējam @parole parametru un tā vērtību
            DbParameter paroleParameter = insertProfilsCommand.CreateParameter();
            paroleParameter.ParameterName = "parole";
            paroleParameter.Value = profils.Parole;

            // Nodefinējam @parole1 parametru un tā vērtību
            DbParameter parole1Parameter = insertProfilsCommand.CreateParameter();
            parole1Parameter.ParameterName = "parole1";
            parole1Parameter.Value = profils.Parole1;

            // Pievienojam kopējam parametru sarakstam
            insertProfilsCommand.Parameters.Add(vardsParameter);
            insertProfilsCommand.Parameters.Add(uzvardsParameter);
            insertProfilsCommand.Parameters.Add(epastsParameter);
            insertProfilsCommand.Parameters.Add(paroleParameter);
            insertProfilsCommand.Parameters.Add(parole1Parameter);


            insertProfilsCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<Profils> GetAll()
        {
            List<Profils> profils = new List<Profils>();

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string selectKalendara_registracijaSql = "SELECT * FROM dbo.Kalendara_registracija;";

            DbCommand selectProfilsCommand = sqlConnection.CreateCommand();

            selectProfilsCommand.CommandText = selectKalendara_registracijaSql;
            selectProfilsCommand.CommandType = System.Data.CommandType.Text;

            DbDataReader dataReader = selectProfilsCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Profils profilsFromDatabase = new Profils();

                profilsFromDatabase.Id = (int)dataReader["ID"];
                profilsFromDatabase.Vards = (string)dataReader["Vards"];
                profilsFromDatabase.Uzvards = (string)dataReader["Uzvards"];
                profilsFromDatabase.Epasts = (string)dataReader["Epasts"];
                profilsFromDatabase.Parole = (string)dataReader["Parole"];
                profilsFromDatabase.Parole1 = (string)dataReader["Parole1"];

                profils.Add(profilsFromDatabase);
            }

            sqlConnection.Close();

            return profils; 
        }

        internal Profils FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
