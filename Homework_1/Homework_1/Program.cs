using Homework_1;

var pathToOne = Directory.GetFiles("../../../").First(x => x.Contains("f1.js"));
var pathToTwo = Directory.GetFiles("../../../").First(x => x.Contains("f2.js"));

//var uncommentedLines = RemoveComments.Decomment(pathToOne);
//Helper.WriteToFile("f1_solved.js", uncommentedLines);

var formattedLines = FormatCode.Format(pathToTwo);
Helper.WriteToFile("f2_solved.js", formattedLines);