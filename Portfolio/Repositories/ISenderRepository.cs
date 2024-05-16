using Portfolio.Models;

namespace Portfolio.Repositories
{
    public interface ISenderRepository
    {
        Task<int> AddSender(SenderModel senderModel);
        Task<List<SenderModel>> GetAllSenders();
    }
}