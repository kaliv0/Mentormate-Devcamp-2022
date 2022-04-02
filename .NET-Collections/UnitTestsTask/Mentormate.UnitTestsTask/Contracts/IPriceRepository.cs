using Mentormate.UnitTestsTask.Entities;

namespace Mentormate.UnitTestsTask.Contracts
{
    public interface IPriceRepository
    {
        BasePrice GetBasePrice(long productId);
    }
}
