using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        public string Judul { get; set; } = "";
        public string Deskripsi { get; set; } = "";
        public DateTime CreateAt { get; set; }
    }
}
