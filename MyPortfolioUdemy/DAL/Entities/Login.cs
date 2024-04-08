using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolioUdemy.DAL.Entities
{

    public class Login
    {
        [Key]
        public int AdminId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
