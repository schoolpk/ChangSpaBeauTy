using System.ComponentModel.DataAnnotations;

namespace ChangSpaBeauty.Web.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Vui long nhap ten san pham")]
        [StringLength(200, ErrorMessage = "Ten khong qua 200 ki tu")]
        [Display(Name = "ten san pham")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = " vui long nhap gia san pham")]
        [Range(0, double.MaxValue, ErrorMessage ="gia phai lon hon 0")]
        [Display(Name = "Gia (đ)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Vui long chon danh muc")]
        [Display(Name ="Danh muc")]
        public int CategoryId { get; set; }

        [Display(Name = "So luong")]
        [Range(0, int.MaxValue, ErrorMessage = "So luong phai > 0")]
        public int Stock { get; set; } = 0;

        [Display(Name ="Mo ta")]
        public string? Description { get; set; }

        [Display(Name="Thuong hieu")]
        public string? Trademark { get; set; }

        [Display(Name ="Anh san pham")]
        public IFormFile? ImageFile { get; set; }
    }
}
