using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class SenderRepository : ISenderRepository
    {
        public readonly SenderDatabaseContext _context = null;
        public SenderRepository(SenderDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<SenderModel>> GetAllSenders()
        {
            List<SenderModel> senders = new List<SenderModel>();
            var sendersFromDb = await _context.AllSenders.ToListAsync();

            if (sendersFromDb.Any() == true)
            {
                foreach (var sender in sendersFromDb)
                {
                    senders.Add(new SenderModel()
                    {
                        Id = sender.Id,
                        Email = sender.Email,
                        Message = sender.Message,
                        Subject = sender.Subject
                    });
                }
            }
            return senders;
        }

        public async Task<int> AddSender(SenderModel senderModel)
        {
            var sender = new Senders()
            {
                Id = senderModel.Id,
                Email = senderModel.Email,
                Message = senderModel.Message,
                Subject = senderModel.Subject,
                TimeSent = DateTime.UtcNow
            };
            await _context.AllSenders.AddAsync(sender);
            await _context.SaveChangesAsync();

            return sender.Id;
        }
    }
}
