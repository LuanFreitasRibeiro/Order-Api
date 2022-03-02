using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Orders.Domain.Models.Request.User
{
    public class UserRequest
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
