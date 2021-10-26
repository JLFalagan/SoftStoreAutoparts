using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftStoreAutoparts.Dto;

namespace SoftStoreAutoparts.Window
{
    public class DatabaseSeed
    {
        public List<ProductDto> GeneratorProducts()
        {
            List<ProductDto> listProducts = new List<ProductDto>();
            for (int i = 0; i < 1000; i++)
            {
                ProductDto product = new ProductDto();
                product.Name = $"Producto {i} A-{i*2} - Rstd {(i*2.5)+100 * 8.1} DFS";
                product.Description = $"DES {i + 5 * 3.5}";
                product.Code = $"A{i * 4.98}";
                product.Stock = i * 8;
                product.PricePurchase = i * 7.23;
                product.Gain = product.PricePurchase * 0.3;
                product.TotalWithIVA = product.PricePurchase * 1.21;
                product.TotalOutWithIVA = product.PricePurchase * 58 + 50;

                listProducts.Add(product);
            }

            return listProducts;
        }
    }
}
