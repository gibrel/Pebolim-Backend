namespace Pebolim.API.Models
{
    public class UpdateUserModel : GetUserModel
    {
        public UpdateUserModel(int id, string username, string passwordHash) : base(id, username, passwordHash)
        {
        }
    }
}
