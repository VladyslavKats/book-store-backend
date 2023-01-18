using BookStore.BLL.Models.Language;
using MediatR;

namespace BookStore.BLL.Queries.Language
{
    public class GetAlllanguagesQuery : IRequest<IEnumerable<LanguageDto>>
    {
    }
}
