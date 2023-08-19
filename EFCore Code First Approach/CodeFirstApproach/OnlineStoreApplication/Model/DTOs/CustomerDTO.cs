using System;

namespace OnlineStoreApplication.Model
{
    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public AddressDTO Address { get; set; }
    }
}
