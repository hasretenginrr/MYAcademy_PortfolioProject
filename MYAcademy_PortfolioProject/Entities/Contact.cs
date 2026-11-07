using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }

        [Url(ErrorMessage = "Geçerli bir bağlantı giriniz.")] public string? GithubUrl { get; set; }
        [Url(ErrorMessage = "Geçerli bir bağlantı giriniz.")] public string? LinkedinUrl { get; set; }
        [Url(ErrorMessage = "Geçerli bir bağlantı giriniz.")] public string? InstagramUrl { get; set; }
        [Url(ErrorMessage = "Geçerli bir bağlantı giriniz.")] public string? YoutubeUrl { get; set; }
    }
}
