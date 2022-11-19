using Catcheap.Models.Validation_Classes;

namespace TestProject
{
    public class CatcheapValidateInputTest
    {

        ValidateInput validate = new ValidateInput();

        [Theory]
        [InlineData("10", true)]
        [InlineData("-1", false)]
        [InlineData("sada", false)]
        public void ValidateInputAsAPositiveNumberTest(string par, bool expectedResult)
        {

            Assert.True(validate.ValidateInputAsAPositiveNumber(par) == expectedResult);

        }

        [Theory]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData("sada", false)]
        public void ValidateInputAsNull(string par, bool expectedResult)
        {

            Assert.True(validate.ValidateInputAsNull(par) == expectedResult);

        }
    }
}
