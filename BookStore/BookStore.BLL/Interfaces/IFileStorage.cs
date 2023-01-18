namespace BookStore.BLL.Interfaces
{
    public interface IFileStorage
    {
        Task UploadAsync();

        Task GetUrlAsync(string fileName);

        Task DeleteAsync();
    }
}
