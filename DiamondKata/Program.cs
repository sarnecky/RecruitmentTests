string midpoint = Environment.GetCommandLineArgs()[1];
var diamond = new Diamond();
diamond.Create(midpoint.ToCharArray()[0]);
DrawDiamond(diamond.Lines);

void DrawDiamond(IReadOnlyCollection<string> lines)
{
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
}