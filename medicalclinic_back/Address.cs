using MySql.Data.MySqlClient;

namespace medicalclinic_back
{
    public class Address
    {
        private int id;
        private string country;
        private string state;
        private string city;
        private string postal_code;
        private string street;
        private string number;

        public Address(int id, string country, string state, string city, string postal_code, string street, string number) 
        { 
            this.id = id;
            this.country = country; 
            this.state = state; 
            this.city = city;
            this.postal_code = postal_code;
            this.street = street;
            this.number = number;
        }

        public int Id { get => id; set => id = value; }
        public string Country { get => country; set => country = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Postal_code { get => postal_code; set => postal_code = value; }
        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }
    }
}
