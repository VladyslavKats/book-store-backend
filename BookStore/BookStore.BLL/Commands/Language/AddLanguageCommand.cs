using BookStore.BLL.Models.Language;
using MediatR;

namespace BookStore.BLL.Commands.Language
{
    public class AddLanguageCommand : IRequest<Unit>
    {
        public LanguageCreateDto Language { get; set; }
    }
}
