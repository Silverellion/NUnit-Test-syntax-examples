namespace NUnitPresentation.UserRepository
{
    [TestFixture]
    public class UserRepositoryReadTests
    {
        private UserRepository _repository = null!;

        // Chạy 1 lần, trước test đầu tiên
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _repository = new();
            _repository.Add("an@example.com");
            _repository.Add("binh@example.com");
        }

        [TestCase("an@example.com", true)]
        [TestCase("chi@example.com", false)]
        public void Exists_ReturnsExpected(string email, bool expected) =>
            Assert.That(_repository.Exists(email), Is.EqualTo(expected));

        [Test]
        public void Count_ReturnsSeededUsers() =>
            Assert.That(_repository.Count, Is.EqualTo(2));

        // Chạy 1 lần, sau test cuối cùng
        [OneTimeTearDown]
        public void OneTimeTearDown() => _repository.Clear();
    }
}
