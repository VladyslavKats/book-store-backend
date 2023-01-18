using MediatR;

namespace BookStore.BLL.Commands.Language
{
    public class DeleteLanguageByIdCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public DeleteLanguageByIdCommand(string id)
        {
            Id = id;
        }
    }
}
