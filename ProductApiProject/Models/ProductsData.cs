namespace ProductApiProject.Models
{
    public class ProductsData : IProducts
    {
        
            public List<Products> AllProducts= new List<Products>
            {
                new Products { Id = 1, Name = "payam", Price = 60, Stock = 80 },
                new Products { Id = 2, Name = "ari", Price = 30, Stock = 100 },
                new Products { Id = 3, Name = "sugar", Price = 30, Stock = 100 },
            };
        
  

        public List<Products> GetProducts()
        {
            return AllProducts;
        }

        public Products GetProductById(int id)
        {
            return AllProducts.FirstOrDefault(s => s.Id == id) ?? new Products();

        }

        public void AddProduct(Products products)
        {
            AllProducts.Add(products);
        }

        public void DeleteProduct(int id)
        {
            var product = AllProducts.FirstOrDefault(s => s.Id == id);
           
            AllProducts.Remove(product);
         
        }

        public void UpdateProduct(int id, Products product)
        {
            var prd = AllProducts.FirstOrDefault(s => s.Id == id);
            if (prd != null)
            {
                prd.Name = product.Name;
                prd.Price = product.Price;
                prd.Stock = product.Stock;


            }
        }
    }

}