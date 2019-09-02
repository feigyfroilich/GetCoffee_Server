using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.convertions
{
    class ProductConverter
    {

        public static ProductDTO DALToDTO(Product product)
        {
            return new ProductDTO
            {
                name = product.name,
                code = product.code,
                categoryCode = product.categoryCode
            };
        }
        public static List<ProductDTO> DALListToDTO(List<Product> products)
        {
            List<ProductDTO> productDTOList = new List<ProductDTO>();
            products.ForEach(product => productDTOList.Add(ProductConverter.DALToDTO(product)));
            return productDTOList;
        }

    }
}
