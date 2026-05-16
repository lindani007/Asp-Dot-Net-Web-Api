using Asp_Dot_Net_Web_Api_Prac_Service;
using System.Collections.ObjectModel;
using Asp_Dot_Net_Maui_Prac_Client_Two.Models;

namespace Asp_Dot_Net_Maui_Prac_Client_Two.Views;

public partial class ViewProducts : ContentPage
{
    // The ProductService is injected via the constructor, allowing us to
    private readonly ProductService _service;

    // The Products collection is an ObservableCollection that holds the list of products to be displayed in the UI.
    ObservableCollection<Product> Products = new ObservableCollection<Product>();
    public ViewProducts(ProductService service)
	{
		InitializeComponent();
        _service = service;
    }


    // Event handler for the ContentPage's Loaded event.
    // This method retrieves the list of products from the API and populates the Products collection.
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {

        // Retrieve products from the API using the ProductService
        // and convert them to the local Product model.
        var productsFromApi = await _service.GetAllProducts();
        var products = productsFromApi.Select(p => new Product
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            ProductDescription = p.ProductDescription,
            ProductPrice = p.ProductPrice,
            ProductImageUrl = p.ProductImageUrl
        }).ToList();

        // Update the Products collection with the retrieved products
        // and set it as the ItemsSource for the productCollection ListView.
        Products = new ObservableCollection<Product>(products);
        productCollection.ItemsSource = Products;
    }

    // Event handler for the Edit button click event.
    private async void OnEditProductClicked(object sender, EventArgs e)
    {
        // Retrieve the product associated with the clicked Edit button using data binding.
        var button = sender as Button;

        // The BindingContext of the button is expected to be a Product object. We attempt to cast it.
        Product? product = button?.BindingContext as Product;
        if(product == null)
            return;

        // Fetch the latest product details from the API to ensure
        // we have the most up-to-date information before navigating to the edit page.
        var productToEdit = await _service.GetProduct(product.ProductId);

        // If the product details are successfully retrieved, we create a new Product object
        if (productToEdit.IsValid)
        {
            Product productToUpdate = new Product
            {
                ProductId = productToEdit.Value!.ProductId,
                ProductName = productToEdit.Value.ProductName,
                ProductDescription = productToEdit.Value.ProductDescription,
                ProductPrice = productToEdit.Value.ProductPrice,
                ProductImageUrl = productToEdit.Value.ProductImageUrl
            };

            // Navigate to the UpdateProduct page, passing the ProductService and the product details for editing.
            await Navigation.PushAsync(new UpdateProduct(_service, productToUpdate));

        }
        else
        {
            await DisplayAlertAsync("Error", "Unable to retrieve product details for editing.", "OK");
        }
    }


    // Event handler for the Delete button click event.
    private async void OnDeleteProductClicked(object sender, EventArgs e)
    {

        // Retrieve the product associated with the clicked Delete button using data binding.
        var button = sender as Button;

        // The BindingContext of the button is expected to be a Product object. We attempt to cast it.
        Product? product = button?.BindingContext as Product;
        if (product == null)
            return;

        // Call the ProductService to delete the product from the API.
        var deletedProduct = await _service.DeleteProduct(product.ProductId);


        // If the product is successfully deleted, we remove it from the Products collection and update the UI.
        if (deletedProduct.IsValid)
        {
            Products.Remove(product);
            Products = new ObservableCollection<Product>(Products);
            await DisplayAlertAsync("Success", $"Product '{product.ProductName}' deleted successfully.", "OK");
        }
        else
        {
            await DisplayAlertAsync("Error", $"Unable to delete product '{product.ProductName}'.", "Retry");
        }
    }

}