using System.ComponentModel.DataAnnotations;

namespace TicketCode.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}