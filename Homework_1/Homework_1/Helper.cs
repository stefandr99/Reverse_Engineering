namespace Homework_1;

public static class Helper
{
    public static void WriteToFile(string fileName, List<string> lines)
    {
        File.WriteAllLines($"../../../{fileName}", lines);
    }

    public static List<string> ReadLines(string filePath)
    {
        return File.ReadAllLines(filePath).ToList();
    }
}
