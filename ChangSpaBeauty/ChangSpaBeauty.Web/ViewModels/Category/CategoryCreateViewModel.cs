using System.ComponentModel.DataAnnotations;

namespace ChangSpaBeauty.Web.ViewModels;

public class CategoryCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
    [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự")]
    [Display(Name = "Tên danh mục")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập tên thương hiệu")]
    [StringLength(100, ErrorMessage = "Thương hiệu không được vượt quá 100 ký tự")]
    [Display(Name = "Tên thương hiệu")]
    public string TradeMark { get; set; } = string.Empty;

}