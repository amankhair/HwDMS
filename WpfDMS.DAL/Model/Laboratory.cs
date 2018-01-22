namespace WpfDMS.DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Laboratory")]
    public partial class Laboratory
    {
        [Key]
        public int lab_id { get; set; }

        [Required]
        [StringLength(35)]
        public string lab_name { get; set; }

        [Required]
        [StringLength(50)]
        public string lab_adress { get; set; }

        [Required]
        [StringLength(50)]
        public string lab_phone { get; set; }

        [Required]
        [StringLength(50)]
        public string lab_timings { get; set; }

        [Required]
        [StringLength(50)]
        public string lab_tests { get; set; }
    }
}
