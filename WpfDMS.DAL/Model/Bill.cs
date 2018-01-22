namespace WpfDMS.DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        public int b_id { get; set; }

        [StringLength(30)]
        public string b_test_charge { get; set; }

        [StringLength(30)]
        public string b_delivery_charges { get; set; }
    }
}
