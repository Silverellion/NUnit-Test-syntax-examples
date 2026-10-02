namespace NUnitPresentation.UserRepository
{
    public class UserRepository
    {
        private readonly HashSet<string> _emails = [];

        public int Count => _emails.Count;

        public void Add(string email)
        {
            if (!_emails.Add(email))
            {
                throw new InvalidOperationException("Email already exists.");
            }
        }

        public bool Exists(string email) => _emails.Contains(email);
        public void Remove(string email) => _emails.Remove(email);
        public void Clear() => _emails.Clear();
    }
}
