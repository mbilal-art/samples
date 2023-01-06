namespace Mockings
{
    public class MockDb
    {
        public MockDb()
        {
            var user = new User();
            Users = user.GetMockUsers();
        }
        public List<User> Users { get; set; }
    }


    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AccessToken { get; set; }
        public bool MFAEnabled { get; set; }
        public string VerificationMessageStatus { get; set; }
        public string VerificationSid { get; set; }
        public bool MFAVerified { get; set; }

        public List<User> GetMockUsers()
        {
            var list = new List<User>();
            list.Add(new User()
            {
                Email = "muhammad.bilal1204@outlook.com",
                Id = Guid.NewGuid(),
                MFAEnabled = true,
                PhoneNumber = "+923480207004"
            });

            return list;
        }
    }

}