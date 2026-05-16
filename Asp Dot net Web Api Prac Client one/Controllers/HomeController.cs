using Asp_Dot_net_Web_Api_Prac_Client_one.Models;
using Asp_Dot_Net_Web_Api_Prac_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Asp_Dot_net_Web_Api_Prac_Client_one.Controllers
{
    public class HomeController : Controller
    {
        // Inject the ProductService to interact with the API
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        //Action methods for creating a product


        // 1. Get method to display the create product form
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        // 2. Post method to handle the form submission and create a new product
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {

            // Carry messages to the view to inform the user about the result of the create operation
            string message = "";

            // Map the Product model from the view to the Product model expected by the service
            var productToCreate = new Asp_Dot_Net_Web_Api_Prac_Service.Models.DbModels.Product()
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductImageUrl = product.ProductImageUrl
            };


            // Call the service to create the product
            var createdProduct = await _productService.CreateProduct(productToCreate);

            // Checks if the product creation was successful and sets the appropriate message to be displayed in the view
            if (createdProduct.IsValid)
            {
                message = "Product created successfully!";
                ViewBag.Message = message;
                return View();
            }
            message = $"Failed to create product. {createdProduct.ErrorMessage}";
            ViewBag.Message = message;
            return View(product);
        }



        //Action method for viewing products
        public async Task<IActionResult> ViewProducts()
        {
            /* Fetch the list of products from the service
               and pass it to the view [ It has been refactored to use the
               GetProductsFromService method to avoid code duplication ]*/
            List<Product> products = await GetProductsFromService();
            return View(products);
        }


        // Action method for updating a product
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            // Fetch the product details from the service using the provided id
            var product = await _productService.GetProduct(id);

            /* Check if the product retrieval was successful. If it is valid, 
             * map the product details to a new Product model
             * and pass it to the view for editing. If the retrieval fails, 
            fetch the list of products and return to the view products page. */
            if (product.IsValid)
            {
                // Map the product details to a new Product model to be used in the view
                var productToUpdate = new Product
                {
                    ProductId = product.Value.ProductId,
                    ProductName = product.Value.ProductName,
                    ProductDescription = product.Value.ProductDescription,
                    ProductPrice = product.Value.ProductPrice,
                    ProductImageUrl = product.Value.ProductImageUrl
                };


                return View(productToUpdate);
            }

            // If the product retrieval fails, fetch the list of products
            // and return to the view products page
            List<Product> products = await GetProductsFromService();
            return View("ViewProducts", products);
        }

        //Action method for sending updated product data to the API
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            // Map the updated product details from the view to the Product model
            // expected by the service
            var productToUpdate = new Asp_Dot_Net_Web_Api_Prac_Service.Models.DbModels.Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductImageUrl = product.ProductImageUrl
            };

            // Call the service to update the product and check if the update was successful
            var updatedProduct = await _productService.UpdateProduct(productToUpdate);

            // If the update is successful, fetch the updated list of products
            // and return to the view products page. 
            // If the update fails, return to the update product view with the current product details. */
            if (updatedProduct.IsValid)
            {
                List<Product> products = await GetProductsFromService();
                return View("ViewProducts", products);
            }
            return View(product);
        }


        //Action method for deleting a product
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Call the service to delete the product using the provided id
            var deleteResult = await _productService.DeleteProduct(id);

            // Check if the delete operation was successful. If it is valid, fetch the updated list of products
            // and return to the view products page.
            if (deleteResult.IsValid)
            {
                var products = await GetProductsFromService();
                return View("ViewProducts", products);
            }

            // If the delete operation fails, fetch the list of products and
            // return to the view products page
            List<Product> productsAfterDeleteAttempt = await GetProductsFromService();
            return View("ViewProducts", productsAfterDeleteAttempt);
        }

        //Create this method to avoid code duplication when fetching products from the service
        private async Task<List<Product>> GetProductsFromService()
        {

            // Fetch the list of products from the service and map it to a list of
            // Product models to be used in the view
            var products = await _productService.GetAllProducts();
            var productsList = products.Select(p => new Product
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductImageUrl = p.ProductImageUrl
            }).ToList();
            return productsList;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
