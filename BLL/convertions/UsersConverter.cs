using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL.convertions
{
    class UsersConverter
    {
        public static UsersDTO DALToDTO(User user)
        {
            return new UsersDTO
            {
                id = user.id,
                name = user.name,
                password = user.password
            };
        }
        public static List<UsersDTO> DALListToDTO(List<User> users)
        {
            List<UsersDTO> usersDTOList = new List<UsersDTO>();
            users.ForEach(user => usersDTOList.Add(UsersConverter.DALToDTO(user)));
            return usersDTOList;
        }

        public static User DTOToDAL(UsersDTO user)
        {
            return new User
            {
                id = user.id,
                name = user.name,
                password = user.password
            };
        }
    }
}
