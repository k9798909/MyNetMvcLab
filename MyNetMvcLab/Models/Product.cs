using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNetMvcLab.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Nullable<int> Proid { get; set; }
        [Required(ErrorMessage ="商品名稱為必填")]
        [StringLength(20,ErrorMessage = "商品名稱長度請勿大於20字。")]
        public string Proname { get; set; }
        [Range(0,1000000,ErrorMessage ="商品價錢請在0~1000000之間。")]
        public int Proprice { get; set; }
        [Range(0, 1000, ErrorMessage = "商品數量請在0~1000之間。")]
        public int Proqty { get; set; }
    }
}
