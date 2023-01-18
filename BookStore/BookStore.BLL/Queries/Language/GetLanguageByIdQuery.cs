
using BookStore.BLL.Models.Language;
using MediatR;

namespace BookStore.BLL.Queries.Language
{
    public class GetLanguageByIdQuery : IRequest<LanguageDto>
    {
        public string Id { get; set; }

        public GetLanguageByIdQuery(string id)
        {
            Id = id;
        }
    }
}
