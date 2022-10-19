using FluentAssertions;
using Moq;
using Xunit;
public class DiamondTests
{
    [Fact]
    public void Create_MidpointNotExists_ThrowException()
    {
        var diamond = new Diamond();

        Action action = () => diamond.Create(It.IsNotIn(Diamond.Alphabet));

        action
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Midpoint does not exist");
    }

    [Fact]
    public void Create_MidpointIsA_ReturnOneLineWithA()
    {
        var diamond = new Diamond();

        diamond.Create('A');

        var lines = diamond.Lines;
        lines.Should().HaveCount(1);
        lines.First().Should().Be("A");
    }

    [Fact]
    public void Create_MidpointIsB_ReturnThreeLinesDiamond()
    {
        var diamond = new Diamond();

        diamond.Create('B');

        var lines = diamond.Lines;
        lines.Should().HaveCount(3);
        lines[0].Should().Be(" A ");
        lines[1].Should().Be("B B");
        lines[2].Should().Be(" A ");
    }

    [Fact]
    public void Create_MidpointIsC_ReturnFiveLinesDiamond()
    {
        var diamond = new Diamond();

        diamond.Create('C');

        var lines = diamond.Lines;
        lines.Should().HaveCount(5);
        lines[0].Should().Be("  A  ");
        lines[1].Should().Be(" B B ");
        lines[2].Should().Be("C   C");
        lines[3].Should().Be(" B B ");
        lines[4].Should().Be("  A  ");
    }

}