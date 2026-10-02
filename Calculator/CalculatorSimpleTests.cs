namespace NUnitPresentation.Calculator
{
    // Lớp chứa test
    [TestFixture]
    public class CalculatorSimpleTests
    {
        private readonly Calculator _calculator = new();

        // Một test case
        [Test]
        public void Add_TwoNumbers_ReturnsSum() =>
            Assert.That(_calculator.Add(2, 3), Is.EqualTo(5));

        [Test]
         public void Divide_ByZero_ThrowsDivideByZeroException() =>
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(1, 0));
    }
}
