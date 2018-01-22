namespace WpfDMS.DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patient")]
    public partial class Patient
    {
        [Key]
        public int p_id { get; set; }

        [Required]
        [StringLength(30)]
        public string p_name { get; set; }

        public int p_age { get; set; }

        [Required]
        [StringLength(10)]
        public string p_gender { get; set; }

        [Required]
        [StringLength(40)]
        public string p_adress { get; set; }

        [Required]
        [StringLength(20)]
        public string p_phone { get; set; }

        [Required]
        [StringLength(10)]
        public string p_login { get; set; }

        [Required]
        [StringLength(10)]
        public string p_password { get; set; }
    }
}
