using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoDto
    {
        [Required(ErrorMessage = "Judul Diperlukan!")]
        public string Judul { get; set; } = "";
        [Required(ErrorMessage = "Deskripsi Diperlukan!")]
        public string Deskripsi { get; set; } = "";
    }
}
