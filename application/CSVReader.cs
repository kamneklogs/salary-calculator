using e05.domain;

namespace e05.application;

public class CSVReader
{

    public static List<Developer> ReadCSV(string path)
    {
        var csv = File.ReadAllLines(path);
        var developers = new List<Developer>();

        foreach (var line in csv.Skip(1)) // Skip the first line because it's the header
        {
            var values = line.Split(',');
            var developer = new Developer(
                values[0],
                (DevType)Enum.Parse(typeof(DevType), values[1]),
                int.Parse(values[2]),
                decimal.Parse(values[3])
            );
            developers.Add(developer);
        }
        return developers;
    }
}