namespace WpfDMS.DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Doctor")]
    public partial class Doctor
    {
        [Key]
        public int d_id { get; set; }

        [Required]
        [StringLength(30)]
        public string d_name { get; set; }

        public int d_age { get; set; }

        [Required]
        [StringLength(10)]
        public string d_gender { get; set; }

        [Required]
        [StringLength(40)]
        public string d_adress { get; set; }

        [Required]
        [StringLength(10)]
        public string d_phone { get; set; }

        [Required]
        [StringLength(10)]
        public string d_login { get; set; }

        [Required]
        [StringLength(10)]
        public string d_password { get; set; }
    }
}
