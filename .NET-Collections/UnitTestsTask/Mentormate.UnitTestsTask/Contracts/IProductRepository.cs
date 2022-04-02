using Mentormate.UnitTestsTask.Entities;

namespace Mentormate.UnitTestsTask.Contracts
{
    public interface IProductRepository
    {
        Product GetById(long productId);
    }
}
