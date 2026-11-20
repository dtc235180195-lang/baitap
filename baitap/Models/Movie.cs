using System.ComponentModel.DataAnnotations;

namespace baitap.Models;

public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên phim.")]
    [StringLength(200, ErrorMessage = "Tên phim không được vượt quá 200 ký tự.")]
    [Display(Name = "Tên phim")]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Ngày phát hành")]
    public DateTime ReleaseDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Thời lượng phải lớn hơn 0 phút.")]
    [Display(Name = "Thời lượng (phút)")]
    public int Duration { get; set; }

    [Display(Name = "Thể loại")]
    public int GenreId { get; set; }

    public Genre? Genre { get; set; }
}
