using Asp_Dot_Net_Maui_Prac_Client_Two.Models;
using Asp_Dot_Net_Web_Api_Prac_Service;

namespace Asp_Dot_Net_Maui_Prac_Client_Two.Views;

public partial class UpdateProduct : ContentPage
{

    // The ProductService is injected via the constructor, allowing us to
    private readonly ProductService _service;

    // The Product object represents the product being updated.
    // It is also injected via the constructor.
    private readonly Product _product;
    public UpdateProduct(ProductService service, Product product)
	{
		InitializeComponent();
        _service = service;
        _product = product;
	}

    // Event handler for the "Update Product" button.
    public async void OnUpdateProductClicked(object sender, EventArgs e)
    {
        // Create a new Product object with the updated values from the input fields.
        var productToUpdate = new Asp_Dot_Net_Web_Api_Prac_Service.Models.DbModels.Product
        {
            ProductId = _product.ProductId,
            ProductName = ProductNameEntry.Text,
            ProductDescription = ProductDescriptionEntry.Text,
            ProductPrice = double.Parse(ProductPriceEntry.Text),
            ProductImageUrl = ProductImageUrlEntry.Text
        };

        // Call the UpdateProduct method of the ProductService to update the product.
        var updatedProduct = await _service.UpdateProduct(productToUpdate);

        // Check if the update was successful and display an appropriate message to the user.
        if (updatedProduct.IsValid)
        {
            await DisplayAlertAsync("Success", $"Product '{_product.ProductName}' updated successfully.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlertAsync("Error", $"Unable to update product '{_product.ProductName}'.", "Retry");
        }
    }


    // Event handler for the ContentPage's Loaded event.
    // This method populates the input fields with the current values of the product being updated.
    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        ProductNameEntry.Text = _product.ProductName;
        ProductDescriptionEntry.Text = _product.ProductDescription;
        ProductPriceEntry.Text = _product.ProductPrice.ToString();
        ProductImageUrlEntry.Text = _product.ProductImageUrl;
    }
}