using Asp_Dot_Net_Maui_Prac_Client_Two.Views;
using Asp_Dot_Net_Web_Api_Prac_Service.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Asp_Dot_Net_Maui_Prac_Client_Two
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Create an instance of ApiBaseUrl and set the API URL
            ApiBaseUrl apiBaseUrl = new ApiBaseUrl { ApiUrl = "https://localhost:7230" };

            // Pass the ApiBaseUrl instance to the CreateProduct page
            // Create an instance of ProductService and pass it to the CreateProduct page
            return new Window(new NavigationPage(new CreateProduct(new Asp_Dot_Net_Web_Api_Prac_Service.ProductService(apiBaseUrl))));
        }
    }
}