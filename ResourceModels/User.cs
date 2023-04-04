using System.ComponentModel.DataAnnotations;

namespace ApexTravels.ResourceModels
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
