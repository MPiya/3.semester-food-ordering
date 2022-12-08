using RestAPI.Dtos;
using WebShopModel.Model;

namespace RestAPI.ModelConversion
{


    public class ProductDtoConvert { 
    public static List<ProductDto>? FromProductCollection(List<Product> inProducts)
    {
        List<ProductDto>? aProductReadDTOList = null;
        if (inProducts != null)
        {
            aProductReadDTOList = new List<ProductDto>();
            ProductDto tempDto;
            foreach (Product aProduct in inProducts)
            {
                if (aProduct != null)
                {
                    tempDto = FromProduct(aProduct);
                    aProductReadDTOList.Add(tempDto);
                }
            }
        }
        return aProductReadDTOList;


    }

    public static ProductDto? FromProduct(Product inProduct)
    {
        ProductDto? aProdcutReadDTO = null;
        if (inProduct != null)
        {

            aProdcutReadDTO = new ProductDto(inProduct.ID, inProduct.Name, inProduct.Price, inProduct.Image,
               inProduct.StockQuantity, inProduct.IsStock);


        }
        return aProdcutReadDTO;

    }

}

}
