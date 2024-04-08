using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolioUdemy.DAL.Entities
{
    public class Feature
    {
		[Key]
		public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
