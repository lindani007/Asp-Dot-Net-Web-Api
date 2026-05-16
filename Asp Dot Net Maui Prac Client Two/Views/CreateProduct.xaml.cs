using Asp_Dot_Net_Web_Api_Prac_Service;
namespace Asp_Dot_Net_Maui_Prac_Client_Two.Views;

public partial class CreateProduct : ContentPage
{

    // The ProductService is injected via the constructor, allowing us to
    // call API methods for product creation and retrieval.
    private readonly ProductService _service;
    public CreateProduct(ProductService service)
	{
		InitializeComponent();
        _service = service;
    }


    // Event handler for the "View Products" button. Navigates to the ViewProducts page.
    private void OnViewProductsClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ViewProducts(_service));
    }

    // Event handler for the "Create Product" button.
    // Creates a new product using the ProductService.
    private async void OnCreateProductClicked(object sender, EventArgs e)
    {

        // We create a new product object using the values entered in the UI.
        // The price is parsed from the text input.
        var productToCreate = new Asp_Dot_Net_Web_Api_Prac_Service.Models.DbModels.Product()
        {
            ProductName = ProductNameEntry.Text,
            ProductDescription = ProductDescriptionEntry.Text,
            ProductPrice = double.TryParse(ProductPriceEntry.Text, out double price) ? price : 0,
            ProductImageUrl = ProductImageUrlEntry.Text
        };

        // We call the CreateProduct method of the ProductService to create the product.
        var createdProduct = await _service.CreateProduct(productToCreate);


        // If the product creation is successful, we display a success message and clear the input fields.
        if (createdProduct.IsValid)
        {
            await DisplayAlertAsync("Success", $"Product '{createdProduct.Value.ProductName}' created successfully!", "OK");
            ProductNameEntry.Text = string.Empty;
            ProductDescriptionEntry.Text = string.Empty;
            ProductPriceEntry.Text = string.Empty;
            ProductImageUrlEntry.Text = string.Empty;
        }
        else
        {
            await DisplayAlertAsync("Error", $"Failed to create product: {createdProduct.ErrorMessage}", "OK");
        }

    }
}