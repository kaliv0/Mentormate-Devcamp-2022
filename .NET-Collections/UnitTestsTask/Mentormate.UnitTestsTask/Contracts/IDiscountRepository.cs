namespace Mentormate.UnitTestsTask.Contracts
{
    public interface IDiscountRepository
    {
        decimal GetDiscountAmount(long productId, long userId);
    }
}
