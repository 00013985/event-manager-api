using System.ComponentModel.DataAnnotations;

namespace WebAppWorkshop.Models
{
    public class Location
    {
        public int Id { get; set; }

        private string _name;
        private string _address;

        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value;
            }
        }

        [Required(ErrorMessage = "Address is required")]
        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be null or empty.");
                }
                _address = value;
            }
        }
    }
}
