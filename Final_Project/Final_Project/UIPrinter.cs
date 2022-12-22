namespace Final_Project;

public class UIPrinter
{
    public UIPrinter()
    {
    }
    public void PrintInformation(List<List<string>> map)
    {
        Console.Clear();
        for (int line = 0; line < map.Count; line++)
        {
            for (int stolb = 0; stolb < map[line].Count; stolb++)
            {
                Console.Write($"{map[line][stolb]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}