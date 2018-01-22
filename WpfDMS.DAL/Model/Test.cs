namespace WpfDMS.DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("test")]
    public partial class Test
    {
        [Key]
        public int t_id { get; set; }

        [StringLength(20)]
        public string t_name { get; set; }

        public int t_price { get; set; }

        public int t_lab_id { get; set; }
    }
}
