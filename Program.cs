using e05.application;
using e05.domain;
using e05.infrastructure;
using Npgsql;

namespace e05;
class Program
{
    private static void Main(string[] args)
    {

        List<Developer> developers = new List<Developer>();

        using (NpgsqlConnection conn = DBConnection.Instance.GetConnection()) // using is used to ensure that the connection is closed when the program exits, ask to Pedro about this
        {

            conn.Open();

            using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM DEVELOPERS;", conn)) // This logic can be moved to a repository class
            {

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // int id = reader.GetInt32(0); not used currently

                    developers.Add(new Developer(
                        reader.GetString(1),
                        (DevType)Enum.Parse(typeof(DevType), reader.GetString(2)),
                        reader.GetInt32(3),
                        reader.GetDecimal(4)));
                }

                reader.Close();
            }
        }

        foreach (Developer developer in developers)
        {
            Console.WriteLine(developer); // Nice

            // https://github.com/pslcorp/perficient.training.content/tree/main/content/code%20challenges/05.%20developer%20salary%20calculator#increase-requirement

            decimal salary = SalaryCalculator.CalculateSalary(developer);

            Console.WriteLine("Resume:");
            Console.WriteLine($"Total salary: {salary}");
        }

        System.Console.WriteLine($"Total developers: {developers.Count}");

    }
}