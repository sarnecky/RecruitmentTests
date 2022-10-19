public class Diamond
{
    public readonly List<string> Lines;
    public static readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private readonly char _indentCharacter;
    public Diamond(char indentCharacter = ' ')
    {
        Lines = new List<string>();
        _indentCharacter = indentCharacter;
    }

    public void Create(char midpoint)
    {
        if (!Alphabet.Contains(midpoint))
            throw new ArgumentException("Midpoint does not exist");

        var midpointIndex = midpoint - 'A';

        AssignTopPart(midpointIndex);
        AssignBottomPart(midpointIndex);
    }

    private void AssignTopPart(int midpointIndex)
    {
        var currentIndex = 0;
        var indentationBetweenSize = 1;
        while (currentIndex <= midpointIndex)
        {
            if (currentIndex == 0)
            {
                Lines.Add(FirstLine(midpointIndex, currentIndex));
            }
            else
            {
                Lines.Add(NextLine(midpointIndex, currentIndex, indentationBetweenSize));
                indentationBetweenSize += 2;
            }

            currentIndex++;
        }
    }

    private void AssignBottomPart(int midpointIndex)
    {
        var currentIndex = midpointIndex - 1;
        while (currentIndex >= 0)
        {
            Lines.Add(Lines[currentIndex]);
            currentIndex--;
        }
    }

    private string FirstLine(int midpointIndex, int currentIndex)
    {
        var indentation = new string(_indentCharacter, midpointIndex);
        return $"{indentation}{Alphabet[currentIndex]}{indentation}";
    }

    private string NextLine(int midpointIndex, int currentIndex, int indentationBetweenSize)
    {
        var indentationOutside = new string(_indentCharacter, midpointIndex - currentIndex);
        var indentationBetween = new string(_indentCharacter, indentationBetweenSize);
        return $"{indentationOutside}{Alphabet[currentIndex]}{indentationBetween}{Alphabet[currentIndex]}{indentationOutside}";
    }
}