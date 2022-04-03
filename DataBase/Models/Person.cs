using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole imię nie może być puste")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pole rok urodzenia nie może być puste")]
        [Display(Name = "Rok urodzenia")]
        public int? BirthYear { get; set; }


        [Required]
        public DateTime DataUpdateTime { get; set; }

        public bool LeapYear { get; set; }

        public void CheckLeapYear()
        {
            LeapYear = ((BirthYear % 4 == 0) && (BirthYear % 100 != 0)) || (BirthYear % 400 == 0);
        }
    }
}
