using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CatereringExpert.Models
{
    public class Caterers
    {
        public DbSet<FilePath> FilePaths { get; set; }
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
    //    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Name")]
        public string CompanyName { get; set; }

      //  [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Address { get; set; }

     //   [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string City { get; set; }

    //    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Postcode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$")]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Food Genre")]
        public string Foodtype { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Average Price Per Head")]
        public decimal AvePrice { get; set; }

      //  [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Description { get; set; }

       // [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Website { get; set; }

      //  [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Email { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
    public class CatererDBContext : DbContext
    {
        public DbSet<Caterers> Caterers { get; set; }
    }

}