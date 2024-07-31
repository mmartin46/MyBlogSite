using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class SenderRepository : ISenderRepository
    {
        public readonly SenderDatabaseContext _context = null;
        private readonly IMapper _mapper;
        public SenderRepository(SenderDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SenderModel>> GetAllSenders()
        {
            List<SenderModel> senders = new List<SenderModel>();
            var sendersFromDb = await _context.AllSenders.ToListAsync();

            if (sendersFromDb.Any() == true)
            {
                foreach (var sender in sendersFromDb)
                {
                    var model = _mapper.Map<SenderModel>(sender);
                    senders.Add(model);
                }
            }
            return senders;
        }

        public async Task<int> AddSender(SenderModel senderModel)
        {
            var sender = _mapper.Map<Senders>(senderModel);
            sender.TimeSent = DateTime.UtcNow;

            await _context.AllSenders.AddAsync(sender);
            await _context.SaveChangesAsync();

            return sender.Id;
        }
    }
}
