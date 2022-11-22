using Catcheap.Models.Validation_Classes;

namespace TestProject
{
    public class CatcheapValidateInputTest
    {

        ValidateInput<string> validate = new ValidateInput<string>();

        [Theory]
        [InlineData("10", 10)]
        [InlineData("-1", -1)]
        [InlineData("sada", null)]
        public void ValidateInputNumberTest(string par, double? expectedResult)
        {

            Assert.True(validate.ValidateInputNumber(par) == expectedResult);

        }

        [Theory]
        [InlineData("10", true)]
        [InlineData("-1", false)]
        [InlineData("sada", false)]
        public void ValidateInputPositiveNumberTest(string par, bool expectedResult)
        {

            Assert.True(validate.ValidateInputPositiveNumber(par) == expectedResult);

        }
    }
}
