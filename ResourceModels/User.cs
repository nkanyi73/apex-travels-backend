using System.ComponentModel.DataAnnotations;

namespace ApexTravels.ResourceModels
{
    /*
     * Model to specify attributes of Users
     */
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
