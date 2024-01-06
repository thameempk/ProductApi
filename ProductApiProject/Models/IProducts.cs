namespace ProductApiProject.Models
{
    public interface IProducts
    {
        public List<Products> GetProducts();
        public Products GetProductById(int id);
        public void AddProduct(Products products);

        public void DeleteProduct(int id);

        public void UpdateProduct(int id ,Products product);
    }
}
