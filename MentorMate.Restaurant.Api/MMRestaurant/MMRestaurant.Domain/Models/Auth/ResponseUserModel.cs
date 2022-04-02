namespace MMRestaurant.Domain.Models.Auth
{
    public class ResponseUserModel
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<UserModel> UserModels { get; set; }
    }
}
