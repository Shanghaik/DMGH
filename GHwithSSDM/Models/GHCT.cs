using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHwithSSDM.Models
{
    public class GHCT
    {
        [Key]
        public Guid Id  { get; set; }
        [ForeignKey("SanPham")]
        public Guid IdSP { get; set; }
        [ForeignKey("GioHang")]
        public Guid IdGH { get; set; }
        public int Amount { get; set; }  
        public virtual SanPham SanPham { get; set; }
        public virtual GioHang GioHang { get; set; }
    }
}
