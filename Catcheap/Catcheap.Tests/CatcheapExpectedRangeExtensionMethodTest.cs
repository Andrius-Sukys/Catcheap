using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace TestProject
{
    public class CatcheapExpectedRangeExtensionMethodTest
    {

        [Theory]
        [InlineData(100, 10, 10, 100, 10, 10, 100)]
        [InlineData(100, 10, 10, 0, 10, 10, 0)]
        [InlineData(100, 10, 10, 10, 5, 10, 50)]
        [InlineData(100, 10, 20, 10, 10, 10, 0)]
        [InlineData(100, 10, 10, 20, 10, 15, 50)]
        public void AdjustExpectedRangeTest(double Range, double TopSpeed, double Weight, double WeightCapacity, double WeightRider, double AverageSpeed,
            double expectedResult)
        {

            double actualResult = Range.AdjustExpectedRange(TopSpeed, Weight, WeightCapacity, WeightRider, AverageSpeed);

            Assert.Equal(expectedResult, actualResult);

        }
    }
}
