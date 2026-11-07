namespace MYAcademy_PortfolioProject.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Proje adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Proje adı en fazla 100 karakter olabilir.")]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }         
        [StringLength(200)]
        public string? Technologies { get; set; }      
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ProjectUrl { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
