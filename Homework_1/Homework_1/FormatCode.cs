namespace Homework_1;

internal class FormatCode
{
    private static readonly char semicolon = ';';
    private static readonly char openedBrace = '{';
    private static readonly char closedBrace = '}';
    private static readonly char openedPharantesis = '(';
    private static readonly char closedPharantesis = ')';
    private static readonly char quotes = '"';
    private static readonly char quotes2 = '`';
    private static int indent = 0;

    internal static List<string> Format(string filePath)
    {
        var line = RemoveComments.Decomment(filePath).First();
        var formattedLines = new List<string>();
        var isPharantesisOpen = false;
        var isQuotesOpen = false;
        var start = 0;

        for (var i = 0; i < line.Length; i++)
        {
            if (line[i] == openedPharantesis )
            {
                isPharantesisOpen = true;
            }
            else if (line[i] == closedPharantesis)
            {
                isPharantesisOpen = false;
            }
            if ((line[i] == quotes || line[i] == quotes2) && !isQuotesOpen)
            {
                isQuotesOpen = true;
            }
            else if ((line[i] == quotes || line[i] == quotes2) && isQuotesOpen)
            {
                isQuotesOpen = false;
            }
            else if (line[i] == semicolon && !isPharantesisOpen && !isQuotesOpen)
            {
                var indentSpace = new string(' ', indent);
                var codeLine = line.Substring(start, i - start + 1);
                formattedLines.Add($"{indentSpace}{codeLine}");
                start = i + 1;
            }
            else if (line[i] == openedBrace && !isQuotesOpen)
            {
                formattedLines.Add($"{new string(' ', indent)}{line.Substring(start, i - start)}");
                start = i;
                formattedLines.Add($"{new string(' ', indent)}{line.Substring(start, 1)}");
                start = i + 1;
                indent += 4;
            }
            else if (line[i] == closedBrace && !isQuotesOpen)
            {
                indent -= 4;
                var indentSpace = new string(' ', indent);
                var code = line.Substring(start, 1);
                formattedLines.Add($"{indentSpace}{code}");
                start = i + 1;
            }
        }

        return formattedLines;
    }
}

