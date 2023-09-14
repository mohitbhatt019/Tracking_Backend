namespace TrackingManagementSystem.Repository.IRepository
{
    public interface ITokenRepository
    {
        public string? GetUserIdFromToken(string userToken);

    }
}
