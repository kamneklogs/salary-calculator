using e05.application;
using e05.domain;

namespace e05
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<Developer> devs = CSVReader.ReadCSV("developers.csv");

            foreach (var dev in devs)
            {
                Console.WriteLine(dev);
            }
        }
    }
}
