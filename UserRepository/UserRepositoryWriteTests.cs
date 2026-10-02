namespace NUnitPresentation.UserRepository
{

    [TestFixture]
    public class UserRepositoryWriteTests
    {
        private readonly UserRepository _repository = new();

        // Chạy trước mỗi test: thêm 1 user mẫu
        [SetUp]
        public void SetUp() => _repository.Add("an@example.com");

        [Test]
        public void Add_NewEmail_IncreasesCount()
        {
            _repository.Add("binh@example.com");
            Assert.That(_repository.Count, Is.EqualTo(2));
        }

        [Test]
        public void Add_DuplicateEmail_ThrowsInvalidOperationException() =>
            Assert.Throws<InvalidOperationException>(() => _repository.Add("an@example.com"));

        [Test]
        public void Remove_ExistingEmail_DecreasesCount()
        {
            _repository.Remove("an@example.com");
            Assert.That(_repository.Count, Is.Zero);
        }

        // Chạy sau mỗi test: xóa dữ liệu để test sau bắt đầu từ trạng thái sạch
        [TearDown]
        public void TearDown() => _repository.Clear();
    }
}
