namespace NUnitPresentation.Calculator
{
    public class CalculatorDataDrivenTests
    {
        private readonly Calculator _calculator = new();

        // Mỗi TestCase là một test riêng
        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        public void Add_Cases_ReturnsSum(int a, int b, int expected) =>
            Assert.That(_calculator.Add(a, b), Is.EqualTo(expected));

        // ExpectedResult: NUnit tự so sánh với giá trị trả về
        [TestCase(4, 5, ExpectedResult = 20)]
        [TestCase(7, 0, ExpectedResult = 0)]
        public int Multiply_Cases_ReturnsProduct(int a, int b) =>
            _calculator.Multiply(a, b);

        // Range(1, 3) x Values(10, 20) = 6 lần chạy
        [Test]
        public void Multiply_Combinations_ReturnsProduct(
            [Range(1, 3)] int a, [Values(10, 20)] int b) =>
            Assert.That(_calculator.Multiply(a, b), Is.EqualTo(a * b));

        private static IEnumerable<TestCaseData> AddCasesFromCsv() =>
            File.ReadLines(Path.Combine(AppContext.BaseDirectory, "Calculator/testdata.csv"))
            .Skip(1)
            .Select(line => line.Split(','))
            .Select(cells => new TestCaseData(
                int.Parse(cells[0]), int.Parse(cells[1]), int.Parse(cells[2])));

        // Lấy bộ dữ liệu từ file CSV, mỗi dòng là một test
        [TestCaseSource(nameof(AddCasesFromCsv))]
        public void Add_FromCsv_ReturnsSum(int a, int b, int expected) =>
            Assert.That(_calculator.Add(a, b), Is.EqualTo(expected));
    }
}
