using Domain.DTO;

namespace PersonalFinance.Data
{
    public static class UserData
    {
        public static List<UserDTO> userList = new List<UserDTO> 
        {
            new UserDTO{UserId=1, Email="user@gmail.com", Name="John Doe"}
        };

    }
}
