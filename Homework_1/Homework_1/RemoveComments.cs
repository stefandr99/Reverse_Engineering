namespace Homework_1;

internal class RemoveComments
{
    private static readonly string _entireLineComm = "//";
    private static readonly string _beginMultiLineComm = "/*";
    private static readonly string _endMultiLineComm = "*/";

    internal static List<string> Decomment(string filePath)
    {
        var lines = Helper.ReadLines(filePath);
        
        for (var index = 0; index < lines.Count; index++)
        {
            var line = lines[index];
            var i = 0;
            while (i + 1 < line.Length)
            {
                GetNextCommStart(line, ref i);
                if (i + 1 < line.Length && $"{line.ElementAt(i)}{line.ElementAt(i + 1)}" == _entireLineComm)
                {
                    RemoveEntireLineComm(ref line, ref i);
                }
                else if (i + 1 < line.Length && $"{line.ElementAt(i)}{line.ElementAt(i + 1)}" == _beginMultiLineComm)
                {
                    RemoveMultiLineComm(ref line, ref i);
                }
            }

            if (string.IsNullOrEmpty(line) && i > 0)
            {
                lines.RemoveAt(index--);
            }
            else
            {
                lines[index] = line;
            }
        }

        
        return lines;
    }

    private static void GetNextCommStart(string line, ref int i)
    {
        while (i + 1 < line.Length &&
               $"{line.ElementAt(i)}{line.ElementAt(i + 1)}" != _entireLineComm &&
               $"{line.ElementAt(i)}{line.ElementAt(i + 1)}" != _beginMultiLineComm)
        {
            i++;
        }
    }

    private static void RemoveEntireLineComm(ref string line, ref int i)
    {
        line = line.Remove(i);

        i = line.Length + 1;
    }

    private static void RemoveMultiLineComm(ref string line, ref int i)
    {
        int start = i;
        while (i + 1 < line.Length && $"{line.ElementAt(i)}{line.ElementAt(i + 1)}" != _endMultiLineComm)
        {
            i++;
        }

        line = line.Remove(start, i - start + 2);
        i = start;
    }
}

