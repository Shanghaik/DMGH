using System.ComponentModel.DataAnnotations;
namespace GHwithSSDM.Models
{
    public class GioHang
    {
        [Key]
        public Guid Id { get; set; }
        public int Status { get; set; }
        public virtual List<GHCT>? GHCTs { get; set; }
    }
}
