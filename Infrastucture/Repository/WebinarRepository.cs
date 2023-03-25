using Domain.Abstractions;
using Domain.Entities;

namespace Infrastucture.Repository
{
    public sealed class WebinarRepository : IWebinarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WebinarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(Webinar webinar)
        {
            throw new NotImplementedException();
        }
    }
}