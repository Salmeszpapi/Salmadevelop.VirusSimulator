using System.ComponentModel.DataAnnotations;

namespace Sim_Web.Models
{
    public class LoginData
    {
        [Key]
        public string usr { get; set; }
        public string pw { get; set; }
    }
}
