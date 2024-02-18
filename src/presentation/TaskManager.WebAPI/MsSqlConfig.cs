using System.ComponentModel.DataAnnotations;

namespace TaskManager.WebAPI
{
    public class MsSqlConfig
    {
        [Required]
        public string ServerName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
