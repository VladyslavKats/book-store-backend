using BookStore.BLL.Models.Language;
using MediatR;

namespace BookStore.BLL.Commands.Language
{
    public class UpdateLanguageCommand : IRequest<Unit>
    {
        public LanguageUpdateDto Language { get; set; }
    }
}
