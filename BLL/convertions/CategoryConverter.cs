using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.convertions
{
    public class CategoryConverter
    {
        public static CategoryDTO DALToDTO(Category category)
        {
            return new CategoryDTO
            {
                code = category.code,
                name = category.name,
                parentCode = category.parentCode
            };
        }
        public static List<CategoryDTO> DALListToDTO(List<Category> categories)
        {
            List<CategoryDTO> categoryDTOList = new List<CategoryDTO>();
            categories.ForEach(category => categoryDTOList.Add(CategoryConverter.DALToDTO(category)));
            return categoryDTOList;
        }

        public static Category DTOToDAL(CategoryDTO category)
        {
            return new Category
            {
                code = category.code,
                name = category.name,
                parentCode = category.parentCode
            };
        }



    }
}
