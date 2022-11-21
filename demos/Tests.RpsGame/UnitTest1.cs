using rpsV1;

namespace Tests.RpsGame;


public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        string rock = "ROCK";
        //Act
        int result = RpsService.ValidateUserChoice(rock);
        //Assert
        Assert.Equal(1, result);
    }


    [Theory]
    [InlineData("qwerty", -1)]
    [InlineData("ROCK", 1)]
    [InlineData("PAPER", 2)]
    [InlineData("SCISSORS", 3)]
    public void ValidateUserChoiceReturns1ForROCK2ForPAPER3ForSCISSORS(string str, int returned)
    {
        //Arrange
        //string rock = "ROCK";

        //Act
        int result = RpsService.ValidateUserChoice(str);

        //Assert
        Assert.Equal(returned, result);

    }
}