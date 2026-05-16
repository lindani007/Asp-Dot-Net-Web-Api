using Asp_Dot_Net_Web_Api_Prac_Service.Models;
using Asp_Dot_Net_Web_Api_Prac_Service.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Asp_Dot_Net_Web_Api_Prac_Service
{
    public class ProductService
    {
        private readonly HttpClient _client;

        public ProductService(ApiBaseUrl apiBaseUrl)
        {
            _client = new HttpClient();
            if(!string.IsNullOrEmpty(apiBaseUrl.ApiUrl))
            {
                _client.BaseAddress = new Uri(apiBaseUrl.ApiUrl);
            }
        }

        //Method to get all products
        public async Task<List<Product>> GetAllProducts()
        {
            var response = await _client.GetAsync("/api/product");
            return await response.Content.ReadFromJsonAsync<List<Product>>() ?? new List<Product>();
        }

        //Method to get one product
        public async Task<ModelValidation<Product>> GetProduct(int id)
        {
            var response = await _client.GetAsync($"/api/product/{id}");
            var product = new ModelValidation<Product>();

            if(response.IsSuccessStatusCode)
            {
                product.Value = await response.Content.ReadFromJsonAsync<Product>();
                product.IsValid = true;
            }
            else
            {
                product.IsValid = false;
                product.ErrorMessage = await response.Content.ReadAsStringAsync();
            }

            return product;
        }

        //method to create new product
        public async Task<ModelValidation<Product>> CreateProduct(Product product)
        {
            var response = await _client.PostAsJsonAsync("/api/product", product);
            var createdProduct = new ModelValidation<Product>();

            if(response.IsSuccessStatusCode)
            {
                createdProduct.Value = await response.Content.ReadFromJsonAsync<Product>();
                createdProduct.IsValid = true;
            }
            else
            {
                createdProduct.IsValid = false;
                createdProduct.ErrorMessage = await response.Content.ReadAsStringAsync();
            }

            return createdProduct;
        }

        //method to update a product
        public async Task<ModelValidation<Product>> UpdateProduct(Product product)
        {
            var response = await _client.PutAsJsonAsync("/api/product",product);
            var updatedProduct = new ModelValidation<Product>();

            if(response.IsSuccessStatusCode)
            {
                updatedProduct.IsValid = true;
                updatedProduct.Value = await response.Content.ReadFromJsonAsync<Product>();
            }
            else
            {
                updatedProduct.IsValid = false;
                updatedProduct.ErrorMessage = await response.Content.ReadAsStringAsync();
            }

            return updatedProduct;
        }

        //method to delete a product
        public async Task<ModelValidation<Product>> DeleteProduct(int id)
        {
            var response = await _client.DeleteAsync($"/api/product/{id}");
            var deletedProdct = new ModelValidation<Product>();

            if(response.IsSuccessStatusCode)
            {
                deletedProdct.IsValid = true;
                deletedProdct.Value = await response.Content.ReadFromJsonAsync<Product>();
            }
            else
            {
                deletedProdct.IsValid = false;
                deletedProdct.ErrorMessage = await response.Content.ReadAsStringAsync();
            }

            return deletedProdct;
        }
    }
}
