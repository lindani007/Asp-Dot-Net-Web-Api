# ASP.NET Core Web API Project Guide
Welcome to the start of this journey! We aren't just writing code here; we are building a professional-grade **RESTful Web API** from the ground up. This API will act as the "Heart" of our system—handling the data, enforcing the rules, and allowing our future Mobile and Web apps to talk to our database.
### The Mission
Our goal is to build a robust backend that can handle **CRUD operations** (Create, Read, Update, Delete) for a Product management system. By the time we are done, you’ll have a secure, scalable service ready for any frontend.
### The Developer's Toolbox (What We’ll Use)

To build like a pro, we need the right tools. Make sure you have the following installed and ready to go:

1. **Visual Studio 2022:** Our primary IDE. This is where we will write our C# code, manage our project structure, and debug our logic.
2. **SQL Server:** This is where our data lives. It’s the "Vault" that will store our products safely.
3. **SQL Server Management Studio (SSMS):** Think of this as the "Remote Control" for our database. We use it to view our tables, run queries, and make sure our data is formatted correctly.

# Module 1: The Api Development

## Step 1: Launch Visual Studio and create a new project

- Click create new project.

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/058adb51-6e52-418a-b101-8b69318baf5f" />


## Step 2: Filter the list

- This new screen pops up. To find the correct template efficiently, apply filters for the language, the platform, and finally search for Web API. This narrows down the list to the essential framework for building robust back-end services.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/e9d4ed00-8923-4fc7-9e69-918e639ec473" />

## Step 3: Select ASP.NET Core Web API template

- Choose the ASP.NET Core Web API template. This is preferred over Native AOT for intermediate developers because it offers a full middleware suite and the flexibility required for enterprise-grade applications. Then click **Next** at the bottom right of the screen.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/37a45f0a-b4a7-4f73-a5e2-96ff73403a56" />

## Step 4: Naming 

- name the project **"Asp Dot Net Web Api Prac"** or the name you prefer. Click **Next** at the bottom right of the screen.
<img width="729" height="410" alt="image" src="https://github.com/user-attachments/assets/64d32773-2c59-4989-ab38-ed3e31f3f7ad" />


## Step 5: Configuration

-  **Framework:** Choose .NET 10.0 (Long Term Support) or the latest version based on your  time of read.
- **Authentication** leave it as none and check **Configure for HTTPS**.
- **OpenAPI Support:** Checked (Essential for Swagger!) 
- **Use Controllers:** Checked.
- Click **Create** at the bottom right of your screen.
<img width="711" height="588" alt="image" src="https://github.com/user-attachments/assets/f23f89fe-d8cf-4134-a8b1-0cd42fe2f908" />


## Step 6: Solution Explorer: The Project Anatomy

- **Solution vs. Project:** The **Solution** is the overall container; the **Project** is where your specific Web API code lives.
- **Dependencies:** The "Toolbox." This stores all external libraries.
- **Properties (`launchSettings.json`):** The "Ignition." Defines how the app starts, which ports it uses, and where the browser should open to `/swagger`.
- **Controllers:** The "Brain of you Api" These files (like `WeatherForecastController.cs`) receive requests from the web and decide what data to send back.
- **`appsettings.json`:** The "Vault." Stores sensitive or flexible data like database connection strings so they aren't hard-coded.
- **`Program.cs`:** The "Key." The entry point that registers services and configures the middleware pipeline.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/eb7438e8-0b79-4608-b559-3a805acccda0" />


## Step 7:  Launching the Application

- **File:** Open `Properties/launchSettings.json`.
- **The Fix:** * Find the `"https"` profile.
-  Change `"launchBrowser": false` to **`true`**.
- Add this line right below it: `"launchUrl": "swagger"`.
- Launch the application by pressing **F5** or **Green button** at the top.
**Note**: The Web page will launch but you will see a broken page with **404 Error**. Some show the **Swagger Ui** window by default, if yours do not show you need to follow step 8.

## Step 8: Installing the SwashbuckleAsp.NetCore Package

- To fix the **404 Error** you need to install **Swashbuckle.Asp.NetCore** package.
-  **Action:** On the **Solution Explorer** Right-click your Project, On the small window that pops up look for **Manage NuGet Packages**.
-  **Search:** Type **"Swashbuckle.AspNetCore"** and On the right window look for install and install the latest version.
-  **Why?** This is the tool that generates that cool interactive "Swagger" webpage for your API.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/301a07cf-50b0-42a6-ab6e-ac25024f1367" />


## Step 9: Final Config in Program.cs

- **File:** Open `Program.cs`.
- **The Code:** Add these four lines to tell the app to use Swagger:
```
   builder.Services.AddEndpointsApiExplorer(); // Step A
builder.Services.AddSwaggerGen();           // Step B

// Inside 'if (app.Environment.IsDevelopment())'
app.UseSwagger();                           // Step C
app.UseSwaggerUI();                         // Step D
```
- Your **Program.cs** file should look like the following image:
<img width="1366" height="602" alt="image" src="https://github.com/user-attachments/assets/73e87336-0370-4a15-99ec-53a57f6fa4fd" />


## Step 10: Step 9 Explained

1. **`builder.Services.AddEndpointsApiExplorer();`**
   -  **Why:** ASP.NET Core needs a way to "find" your API routes. This line tells the app to scan your controllers and look for every `[HttpGet /Post/Put/Delete]`.
   - **Without it:** Swagger will be "blind." It won't know which endpoints exist to show them on the screen.
2. `builder.Services.AddSwaggerGen();`
   -   **Why:** This is the "Architect." It takes the list of routes found by the Explorer and generates a big JSON file (called the OpenAPI spec). This JSON file is the technical blueprint of your entire API.
  -   **Without it:** You won't have the technical data needed to build the UI.
  3. **`app.UseSwagger();`**
	-  **Why:** This tells the app to actually "serve" the JSON blueprint we generated in Step 7. If you go to `localhost:xxxx/swagger/v1/swagger.json`, this is the line making that work.
	-  **Without it:** The data exists in memory, but it's not being sent to the browser.
4. `app.UseSwaggerUI();
    - **Why:** This is the "Interior Designer." It takes that ugly JSON blueprint and turns it into the beautiful, interactive green and blue webpage we see in the browser. It gives you the "Try it out" buttons.
    - **Without it:** You would just see a screen full of raw code/JSON instead of a nice interface.

#### After launching the application you will see the following page.
<img width="1356" height="606" alt="image" src="https://github.com/user-attachments/assets/3345b7cb-cfcd-4c4e-bb64-b4d70a4c159d" />



## Step 11: Model Creation

- Now go back to the application, To keep our project clean and maintainable, we need to separate our data structures from our logic. In professional development, we call this **Separation of Concerns**.
- First delete the default controller and class by right-clicking to them and hit delete.
- **Then next Action:** In your **Solution Explorer**, right-click on your Project name `Asp Dot Net Web Api Prac`.
- **The Step:** Select **Add > New Folder** and name it **Models**.

#### **Why do we need a Models folder?**
The **Models** folder is the "Blueprint Warehouse." It contains classes that represent the objects your API will work with like a **Product**. Without models, the API wouldn't know what the data looks like when it tries to send it to a database or a client (App).

### Step 11.1: Creating your first Model Class
- Once the folder is created, we need to add a blueprint (a C# Class) inside it.
1. **Right-click** the new **Models** folder.
2. Select **Add > Class**.
3. Name it something relevant to your project (for example, `Item.cs` or `Product.cs`).

**The Anatomy of a Model Class**
Inside this file, you define **Properties**. These properties are the specific details of your object. When your API runs, these will be converted into **JSON keys**.
```
namespace YourProjectName.Models 
{
  public class Product 
  { 
	  // The ID is the unique "Key" for every item
      [Key]
      [Column("Product_Id)] // Name to display on the Database
	  public int ProductId { get; set; } 
	  
	  // The Name of the product 
	  [Column("Product_Name)] // Name to display on the Database
	  public string? ProductName { get; set; }  
	  
	  // The Price (using double for precision) 
	  [Column("Product_Price)] // Name to display on the Database
	  public double ProductPrice { get; set; } 
	  
	  // A description of the item 
	  [Column("Product_Description)] // Name to display on the Database
	  public string ProductDescription { get; set; }
	  
	  // An image url of the item 
	  [Column("Product_Image_Url)] // Name to display on the Database
	  public string ProductImageUrl { get; set; }
	  
   }   
}
```
**Pro Tip:** Using `{ get; set; }` (Auto-Implemented Properties) allows the ASP.NET Core engine to "Read" from and "Write" to these variables automatically when it receives data from a user.

## Step 12:  Creating the Data Folder & DbContext

- Before the API can talk to a database, it needs a "Translator." In **ASP.NET Core**, this is the **DbContext**. We need to add it.
1. **The Action:** Right-click your folder called **Models** in the **Solution Explorer**.
2. **The Step:** Select **Add > New Folder** and name it **Data**.
3. **The File:** Right-click the **Data** folder, select **Add > Class**, and name it `ProductDbContext.cs` or name of your choice.
#### **What is the ProductDbContext?**
Think of the `DbContext` as the **Manager** of your database. It handles the connection and tells the system which Models should be turned into database tables.

## Step 13: Installing the EF Core "Engine" (NuGet Packages)

- Inside you class **ProductDbContext** next to it name inherite from **DbContext** class.  This should give you an error because there are some missing packages which we will install soon.
<img width="1366" height="452" alt="image" src="https://github.com/user-attachments/assets/0c8ec643-fb81-4ccd-b1b3-5c3b4b6cbd81" />


- To make this work, we need to install four specific tools (**NuGet Packages**). These are the libraries that give your project "database powers.
#### **How to install:**
- **Action**: **Right-Click At you project name > Manage NuGet Packages"**.
- Click the **Browse** tab and search for/install these four:
1. **Microsoft.EntityFrameworkCore**: The base engine for Entity Framework.
2. **Microsoft.EntityFrameworkCore.Design**: Essential for the engine to create the database from your code.
3. **Microsoft.EntityFrameworkCore.SqlServer**: Tells the engine we are using SQL Server.
4. **Microsoft.EntityFrameworkCore.Tools**: Allows you to run commands like `add-migration`.
<img width="667" height="504" alt="image" src="https://github.com/user-attachments/assets/00b3a074-e814-4861-aa69-79b27a11deb5" />


**Note:** Make sure the version of these packages is the latest version.

## Step 14: Coding the DbContext

- Now, open your `ProductDbContext.cs` file and add this line of code at the first line `using Microsoft.EntityFrameworkCore;`. This will remove the error.
-  Now, Paste this code  and read the explanation of it below it.
```
using Microsoft.EntityFrameworkCore; // The base engine for Entity Framework.
using YourProjectName.Models; 

namespace YourProjectName.Data
{
    public class ProductDbContext : DbContext
    {
        // This constructor allows the connection string to be passed in
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

	    // This creates a "Products" table in your database based on the Product model
        public DbSet<Product> Products { get; set; }
    }
}
```
 
#### **Explained: The Technical Vocabulary**
 
To understand how the **Engine** works, you need to know what these specific parts do:
- **`DbContext`**: Think of this as the **Bridge** or the **Session**. It is a base class provided by EF Core that represents a session with the database. It allows you to query and save data. Without inheriting from this, your class is just a normal file and can't talk to SQL.
- **`DbContextOptions<T>`**: This is the **Configuration Packet**. It carries vital information—like which database to use (SQL Server) and the **Connection String** (the address of the database)—from your `Program.cs` into this class.
- **`base(options)`**: This is the **Hand-off**. It takes the configuration packet mentioned above and passes it "up" to the original `DbContext` class so the internal EF Core logic can use it.
- **`DbSet<Product>`**: This represents a **Table** in your database.
    - The `DbSet` is the collection of all `Product` objects.
    - When you write code to search for a product, you are searching this `DbSet`.
    - When you run a "Migration," EF Core looks at this line and says, _"Okay, I need to create a table named 'Products' in SQL Server."


## Step 15:  Setting the Connection String

- Open your `appsettings.json` file in the **Solution Explorer**. This is where we store "Secret" or "Variable" information like database paths so they aren't hard-coded into the C# logic.
- **Action**: Add a new container called `"ConnectionStrings"` below  `Logging`.
```
"ConnectionStrings": { "DefaultConnection": "Server=(localdb)\\mssqllocaldb[Add you actual server name];Database=AspDotNetWebApiPracDb;Trusted_Connection=True;MultipleActiveResultSets=true,TrustServerCertificate=true;" },
```
#### **Connection String Format Explained**

1. **`Server=(localdb)\\mssqllocaldb`**: This is the **Location**. It tells the app to use the lightweight "Local" version of SQL Server that comes installed with Visual Studio. **I recommend putting your actual server name here.**
2. **`Database=AspDotNetWebApiPracDb`**: This is the **Name**. You can call this whatever you want! When you run your migration, EF Core will look for a database with this name. If it doesn't find one, **it will create it for you.**
3. **`Trusted_Connection=True`**: This is the **Security**. It tells SQL Server to use your Windows Login (your current computer user) to log in, so you don't need a username or password.
4. **`MultipleActiveResultSets=true`**: This is a **Performance** setting. It allows the API to talk to the database multiple times at once without waiting for the first "chat" to finish completely.
5. `TrustServerCertificate=true`: This is the **"Skip the ID Check"** setting.


## Step 16: Registering the DbContext in Program.cs

- Now we head to the **Heart** of the application to "Plug in" the database manager and give it that connection string we just wrote.
1. Open **Program.cs**. 
2. Inside **Program.cs** find the line that says `var app = builder.Build();`
3. **Right above it**, add this code:
```
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
```

#### **What is happening here?**
 
- **`builder.Configuration.GetConnectionString`**: This goes into your `appsettings.json`, looks for the `"ConnectionStrings"` section, and grabs the text inside `"DefaultConnection"`.
- **`builder.Services.AddDbContext`**: This is called **Dependency Injection**. You are telling the app, _"Whenever a Controller needs to talk to the database, use the `ProductDbContext` engine."_
- **`options.UseSqlServer`**: This tells the engine to use the SQL Server driver (one of the NuGet packages we installed earlier) to handle the actual talking.


## Step 17: Running Migrations (Code to Database)

Think of a **Migration** as a "Version Control" for your database. Instead of manually creating tables in SQL, you write code, and EF Core generates the SQL scripts for you.

1. **Open the Terminal**: In Visual Studio top left corner, go to: **View**> **Dropdown List Appear look for the terminal**> **Terminal** (It usually opens at the bottom of your screen).
2. The **"Add-Migration"** Command This command looks at your `ProductDbContext` and your `Models`, and creates a "Plan" for the database. Type this into the console and hit Enter: `dotnet ef migrations add initialcreate`
-  **What it does:** It creates a new folder in your project called **Migrations**. Inside, you’ll find a C# file that describes how to create the `Products` table.
- **"InitialCreate"**: This is just a name. You can call it "FirstStep" or "AddedProductsTable," but "InitialCreate" is the standard for the first .
3. The **"Update-Database"** Command: The previous step only created the _plan_. This command actually **executes** the plan and builds the database. Type this and hit Enter: `dotnet ef database update`.
- **What it does:** It reads the connection string in your `appsettings.json`, finds your local SQL server, and runs the script to create the **AspDotNetWebApiPracDb** and the **Products** table.

## **Step 18: Creating the Controller (The Brain of the API)**

Now that our database and models are ready, we need a way to handle incoming requests.

- **Right-click the 'Controllers' folder** in Solution Explorer.
- **Select Add > Controller...**

<img width="633" height="715" alt="image" src="https://github.com/user-attachments/assets/19c1040f-f434-41ca-82d4-a9a961113ad0" />


- **Choose "API Controller - Empty"** – We are building this manually to maintain full control over our logic.
<img width="956" height="660" alt="image" src="https://github.com/user-attachments/assets/9ea6235b-f255-4fd7-a111-a7a291b3aa4c" />


- **Controller Name:** `ProductController`.
<img width="946" height="655" alt="image" src="https://github.com/user-attachments/assets/1a43c585-e3a0-45d2-a559-de9a12f6995e" />



## **Step 19: Understanding the Code (Line-by-Line)**

####  **1. The Database Connection (Dependency Injection)**

C#
```
private readonly ProductDbContext _context;
```

- **private:** This means only this specific class (`ProductController`) can see or use this variable.
- **readonly:** This is a safety lock. It ensures the `_context` can only be assigned a value during the constructor and cannot be changed later.
- **ProductDbContext:** This is the type of the variable—it refers to the data folder and `DbContext` class we created earlier.
- **__context:** The name of our internal variable (the underscore is a common C# convention for private fields).

#### **2. The Constructor**

C#
```
public ProductController(ProductDbContext context)
{
    _context = context;
}
```

- **public ProductController:** This is the "Entry Gate" of the class. Every time a request comes in, ASP.NET Core runs this first.
- **ProductDbContext context:** This tells the system: "To run this controller, I need you to provide me with the database connection (the context)."
- **_context = context:** This takes the connection provided by the system and saves it into our private variable so all our methods can use it to talk to the database.


## **Step 20: Explaining the Methods (CRUD)**

#### **A. Get All Products (GET)**
C#
```
[HttpGet]
public IEnumerable<Product> GetAllProducts()
{ 
	return _context.Products.ToList(); 
}
```

- **[HttpGet]:** This attribute tells the API to trigger this method when a standard "GET" request hits `api/Product`.
- **IEnumerable:** This is a list of your products.
- **_context.Products.ToList():** This tells Entity Framework: "Go to the database, grab the Products table, and turn it into a list I can return."

#### **B. Get Product by ID (GET with Parameter)**
C#
```
[HttpGet("{id}")]
public ActionResult<Product> GetProductById(int id) 
{ 
    if (id == 0)
        return BadRequest("Id is required");

    var product = _context.Products.Find(id);
    if (product == null)
        return NotFound("Product not found");

    return Ok(product);
}
```

-  **[HttpGet("{id}")]:** The `"{id}"` part is a **Route Template**. It tells the API to look for a number in the URL (like `api/Product/5`) and pass that number into the `id` parameter.
-  `ActionResult<Product>`:** This is a **Return Type Wrapper**. It allows the method to return either the `Product` data or an HTTP status code (like 404 or 400).
-   **if (id == 0):** A **Validation Check**. We check if the user sent an invalid ID.
- **return BadRequest("..."):** Sends a **400 Bad Request** status back to the user, telling them they made a mistake in their request.
- **_context.Products.Find(id):** This is an **EF Core Search Method**. It specifically looks for the **Primary Key** in your SQL table that matches the `id`.
- **return NotFound("..."):** Sends a **404 Not Found** status if the database doesn't have a product with that ID.
- **return Ok(product):** Sends a **200 OK** status along with the product data in JSON format.

#### **C. Create New Product (POST)**
C#
```
[HttpPost]
public ActionResult<Product> CreateNewProduct(Product product)
{
    if (product == null)
        return BadRequest("Product is required");

    _context.Products.Add(product);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
}
```

- **[HttpPost]:** This attribute marks the method as a **Create Action**. It expects the user to send data in the "Body" of the request.
- **Product product:** This is **Model Binding**. The API automatically takes the JSON data sent by the user and turns it into a C# `Product` object.
- `_context.Products.Add(product):` This **Stages** the data. It tells Entity Framework to prepare this new object to be inserted into the database.
- `_context.SaveChanges():` This **Commits** the transaction. This is the moment the data is actually written to your SQL Server.
- **CreatedAtAction:** This returns a **201 Created** status. It’s better than a simple "OK" because it also provides a link to where the new product can be viewed (using your `GetProductById` method).

#### **D. Update Product (PUT)**

C#
```
[HttpPut]
public ActionResult<Product> UpdateProduct(Product product)
{
    bool productExists = _context.Products.Any(p => p.ProductId == product.ProductId);
    if (!productExists)
        return NotFound($"Product with {product.ProductId} not found");

    _context.Products.Update(product);
    _context.SaveChanges();

    return Ok(product);
}
```

- **[HttpPut]:** The standard HTTP method for **Updating** existing data.
- `_context.Products.Any(p => p.ProductId == product.ProductId):` This is a **Boolean Check**. It runs a quick SQL query to see if the product ID exists before we try to update it.
- `_context.Products.Update(product):` This tells EF Core to **Track** this object as "Modified." It will compare the data and prepare a SQL `UPDATE` statement.
- `return Ok(product):` Returns the updated product to show the user the changes were successful.


#### **E. Delete Product (DELETE)**

C#
```
[HttpDelete("{id}")]
public ActionResult<Product> DeleteProductById(int id)
{
    if (id == 0)
        return BadRequest("Id is required");

    var product = _context.Products.Find(id);
    if (product == null)
        return NotFound("Product not found");

    _context.Products.Remove(product);
    _context.SaveChanges();

    return Ok(product);
}
```

- **[HttpDelete("{id}")]:** Marks the method for **Removal** requests. Like the GET method, it needs an `id` to know which one to kill.
- `_context.Products.Remove(product):` This marks the found product for **Deletion**. It isn't gone yet!
- `_context.SaveChanges():` This is the final **Execution**. It sends the SQL `DELETE` command to the database. Once this line runs, the data is gone forever.


## **Step 21: Testing the API in Swagger (The Test Drive)**

Now that we understand the code, it’s time to see it in action. Visual Studio automatically includes a powerful testing tool called **Swagger UI** (thanks to the ****`Swashbuckle`** package we installed in Step 8). This tool lets us test our API endpoints directly in the browser without writing any frontend code.
### **Launching the Test Environment:**

1. **Run the application** (Press F5 or click the Green 'Play' button in Visual Studio).
2. Your default web browser will open and automatically navigate to a page that looks like this:

<img width="1358" height="571" alt="image" src="https://github.com/user-attachments/assets/f7dc9015-05ab-44b5-9d23-59bf8c5422bf" />



### **How to Test Each Method (One by One):**

Testing an API is a specific cycle. You generally start with an empty database (GET), add data (POST), retrieve specific data (GET with ID), update that data (PUT), and finally, clean it up (DELETE).
#### **Cycle 1: Initial System Check (GET All)**

> **The Goal:** Make sure the API is running and the database connection is working, even if it's empty.

- **Expand the Method:** Click on the **Blue 'GET'** bar labeled `/api/Product`.
- **Ready the Request:** Click the **Try it out** button in the top right corner.
- **Execute:** Click the **Execute** button.
- **Read the Response:** Scroll down to the **Responses** section.
- **Expected Result:** You should see a **`200 OK`** response. The **Response body** will show an empty JSON list: **`[]`**. This confirm the API is talking to the database and found no products.

#### **Cycle 2: Adding Our First Record (POST)**

> **The Goal:** Create a new product to test the "Create" logic and actually push data into the SQL database.

- **Expand the Method:** Click on the **Green 'POST'** bar labeled `/api/Product`.
- **Ready the Request:** Click **Try it out**.
- **Provide Data:** In the **Request body** box, edit the default JSON. You only need to edit the Product Name, Description, Price, and Image URL. **Keep ProductID at 0**, the database will generate this for us!
-  Example:
JSON
        ```
        {
          "productId": 0,
          "productName": "Banana",
          "productDescription": "Fresh banana.",
          "productPrice": 2,
          "productImageUri": "https://image.com/banana.jpg"
        }
        ```
        
- **Execute:** Click **Execute**.
- **Read the Response:**
- **Expected Result:** You should see a **`201 Created`** status. The **Response body** will show your JSON product, but now with a unique `productId` assigned (e.g., `1`). This is the "Created Action" logic in effect!

#### **Cycle 3: Verifying Data Persistence (GET and GET by ID)**

> **The Goal:** Prove that the POST command was successful and the data is "stuck" in the database.

- **Test GET All:** Repeat the GET steps from Cycle 1. Click **Execute**.
- **Expected Result:** **`200 OK`** response, and the Response body now shows your JSON list with your Awesome Apple included: `[{...}]`.
- **Test GET by ID:**
    - Expand the **Blue 'GET'** bar labeled `/api/Product/{id}`.
    - Click **Try it out**.
    - **id Field:** Enter the `productId` you just created (e.g., `1`).
    - Click **Execute**.
- **Expected Result:** **`200 OK`** response. The Response body will show _only_ the specific JSON object for Product 1, confirming our `_context.Products.Find(id)` logic works.

#### **Cycle 4: Updating a Record (PUT)**

> **The Goal:** Test the update logic by changing some details on an existing product.

- **Expand the Method:** Click on the **Orange 'PUT'** bar labeled `/api/Product`.
- **Ready the Request:** Click **Try it out**.
- **Provide Data:** In the **Request body** box, copy the exact JSON from the previous GET, but make your changes. **Crucial:** You must provide the correct `productId`.
- Example:
  JSON
        
        ```
        {
          "productId": 1,
          "productName": "Awesome Apple (Updated!)",
          "productDescription": "Same crispy apples, but updated.",
          "productPrice": 3.00,
          "productImageUri": "https://example.com/apple_updated.jpg"
        }
        ```
        
- **Execute:** Click **Execute**.
- **Read the Response:**
- **Expected Result:** You should see a **`200 OK`** status. This means our `Any()` check passed, the database entry was `Updated`, and `SaveChanges()` was successful.

#### **Cycle 5: Deleting the Record (DELETE)**

> **The Goal:** Test the delete logic by removing the product we just updated from the database.

- **Expand the Method:** Click on the **Red 'DELETE'** bar labeled `/api/Product/{id}`.
- **Ready the Request:** Click **Try it out**.
- **id Field:** Enter the `productId` you want to remove (e.g., `1`).
- **Execute:** Click **Execute**.
- **Read the Response:**
- **Expected Result:** You should see a **`200 OK`** status, confirming the product was removed successfully.

---

### **Final Validation Check:**

To prove it is _really_ gone, go back to the top and run the original **GET /api/Product** method one last time.

- Click **Execute**.
- **Expected Result:** The JSON body should be empty **`[]`** again. **Mission Complete!** Our API is robust, handles data correctly, and communicates perfectly with the database. We are officially finished with the basic API development.


# Module 2: The Shared Communication Bridge

## Step 22: Why Use a Class Library? (The "DRY" Principle)

Now that our Web API is finished, we have a way to talk to our database. Our API can go into the database, grab a list of products, and bring them back. However, the communication isn't quite finished yet. Our client the actual app that the user sees still doesn't know how to ask the API for that data. We need to build a **"bridge"** between the API and the App.

To do this, we are following a professional coding rule called **DRY (Don't Repeat Yourself)**. If we wrote the communication code directly inside our app, we would have to rewrite it all over again if we ever decided to make a second app or a website. By using a **Class Library**, we create a separate, reusable package. This package handles the "talk" with the API, and we can simply drop it into any project we want in the future without writing new code.

Imagine you build a mobile app today and a desktop app tomorrow. If the code is stuck inside the mobile app, the desktop app can't see it. By putting it in a Class Library, you are making your code **"portable."** It becomes a single source of truth that works everywhere, keeping your project organized, clean, and very easy to maintain as it grows.

## Step 23: Organizing the Solution (The Server Folder)

Before we create the library, we need to keep our workspace clean. As a developer, your **Solution Explorer** is your desk; if it’s messy, your code becomes messy.

1. **Create the Folder:** Right-click on your **Solution** name (at the very top of the Solution Explorer).
2. **Add Solution Folder:** Hover over **Add** and select **New Solution Folder**. Name this folder **"DbApi"**.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/50a376fb-d951-4494-8f81-2b9ac25c55f7" />


3. **Drag and Drop:** Move your mouse over your API project, click and hold, and drag it into the **DbApi** folder.
4. Your **Solution Explorer** should look like this.
<img width="314" height="638" alt="image" src="https://github.com/user-attachments/assets/002bd8c3-9a9f-4667-bcc3-8d067de7b7dd" />


This tells anyone looking at your code: "Everything inside this folder belongs to the backend/database side of the world."

---

## Step 24: Creating the Class Library Project

Now, let's look at the screen and walk through how to actually start this project in Visual Studio.

1. **Right-Click DbApi Folder:** Right-click DbApi Folder.
2. **Add New Project:** Select **Add > New Project**.
3. **Find the Template:** Search for **"Class Library"** in the search bar at the top, Select it and click **"Next** at the bottom right of the screen.

<img width="1370" height="768" alt="image" src="https://github.com/user-attachments/assets/ef71ceee-208a-42a0-abdd-14e66e921bb4" />



4. **Name It:** Name the project. A professional naming convention is `[YourAppName] Library` or `[YourAppName] Services` mine is `Asp Dot Net Web Api Prac Service.
5. **Target Framework:** Ensure it matches your API (e.g., .NET 9.0 or .NET 10.0) and click **Create**.

## Step 25: Installing the "Brains" (NuGet Packages)

Because a Class Library is "empty" by default, it doesn't know how to talk to the web or how to handle professional setup menus. We need to give it some tools.

Right-click your new **Library Project** and select **Manage NuGet Packages**. Install these three:

- `Microsoft.Extensions.Http:` This allows our library to use `HttpClient` to send messages over the internet.
- `Microsoft.Extensions.Options:` This gives us the "system locker" logic we need to store the API URL safely.
- `Microsoft.Extensions.DependencyInjection.Abstractions:` This is what allows our library to "attach" itself to the main app's setup menu.


## Step 26: Building the Model Architecture

Before our library can send or receive data, it needs a shared language. We create a structure that mirrors our API so that data flows perfectly between the server and our future apps.

### 1. Organizing the Folders

In your Class Library project, start by creating a folder named **Models**. Inside that folder, create another sub-folder named **DbModels**. This keeps your data objects separate from your logic objects—very professional.
### 2. The Product Class (The Data Blueprint)

Inside the `DbModels` folder, create a class named `Product.cs`. This class must have attributes identical to your API attributes so that the system can "auto-map" the JSON data.
- To create `Product.cs`: Right-click `DbModels` folder, select `Add`, `Class`,  name it `Product.cs`.

C#
```
public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public double ProductPrice { get; set; }
    public string? ProductImageUrl { get; set; }
}
```

### 3. The ApiBaseUrl Class (The Destination)

Inside the main **Models** folder, create `ApiBaseUrl.cs`. **Purpose:** This class acts as a dedicated container for your API's web address. Instead of hard-coding a string like `https://localhost:7001` everywhere, we use this class so we can easily swap the URL if we move from a local test server to a real live website.
- To create `ApiBaseUrl.cs`: Right-click `Models` folder, select `Add`, `Class`, name it `ApiBaseUrl.cs`.

C#
```
public class ApiBaseUrl
{
    public string? ApiUrl { get; set; }
}
```

#### Deep dive explanation 

This is a simple but powerful class used for **Configuration**.
- `public string? ApiUrl { get; set; }`: This is the only attribute here. It stores the web address of your API (like `https://localhost:7001`). By putting it in a class, we can "bind" it to our settings file later.
### 4. The ModelValidation Class (The Error Wrapper)

Finally, in the **Models** folder, create `ModelValidation.cs`. 

**Purpose:** When we ask the server for data, things can go wrong (no internet, 404 not found, etc.). Instead of our app just crashing, we use this **Generic Wrapper `<T>`**. It "wraps" our data and carries a message back to the UI, telling us exactly if the request was successful or why it failed.

- To create `ModelValidation.cs`: Right-click `DbModels` folder, select `Add`, `Class`,  name it `ModelValidation.cs`.

C#
```
public class ModelValidation<T>
{
    public T? Value { get; set; } // The actual data (like a Product)
    public bool IsValid { get; set; } // True if everything worked
    public string? ErrorMessage { get; set; } // The explanation if it failed
}
```

#### Deep dive explanation 

This is our **Wrapper**. It’s used to handle communication between the library and the UI.

- `public T? Value`: The "T" stands for **Type**. This allows the class to hold _anything_—a single Product, a List of Products, or even a User.
- `public bool IsValid`: A simple switch. If the API call works, we set this to `true`. If the server crashes or the ID isn't found, we set it to `false`.
- `public string? ErrorMessage`: If `IsValid` is false, we put the reason here (e.g., "Server Timeout" or "Product not found").

## Step 27: Building the ProductService (The API Engine)

This class is the heart of your library. It lives directly in the **root** of your Class Library project. Its job is to handle the actual "conversation" with the Web API using asynchronous code so your app never freezes while waiting for data.

### 1. The Constructor and Client Setup

C#
```
private readonly HttpClient _client;

public ProductService(ApiBaseUrl apiBaseUrl)
{
    _client = new HttpClient();
    if(!string.IsNullOrEmpty(apiBaseUrl.ApiUrl))
    {
        _client.BaseAddress = new Uri(apiBaseUrl.ApiUrl);
    }
}
```

#### Deep Dive Explanation:

- **`private readonly HttpClient _client`**: We declare a private "web browser" for this class. Making it `readonly` ensures it can't be accidentally overwritten after the service starts.
- **`public ProductService(ApiBaseUrl apiBaseUrl)`**: This is **Dependency Injection**. The service doesn't guess the URL; it waits for the system to hand it the `ApiBaseUrl` object we created earlier.
- **`_client.BaseAddress = new Uri(...)`**: This is a critical efficiency step. We set the "Home Page" for all our requests. This means if our API is at `https://localhost:7001`, we only have to type `/api/product` later instead of the full address every single time.

### 2. Method to Get All Products

C#
```
public async Task<List<Product>> GetAllProducts()
{
    var response = await _client.GetAsync("/api/product");
    return await response.Content.ReadFromJsonAsync<List<Product>>() ?? new List<Product>();
}
```

#### Deep Dive Explanation:

- **`async Task<List<Product>>`**: We use `async` and `Task` because web requests take time. This allows the app to keep running while the data travels across the internet.
- **`_client.GetAsync("/api/product")`**: This sends a **GET** signal to the API's product endpoint.
- **`ReadFromJsonAsync<List<Product>>()`**: This is the "Magic Translator." The API sends back a giant string of text (JSON). This method automatically parses that text and converts it into a C# List of our `Product` model.
- **`?? new List<Product>()`**: This is a "Null Coalescing" operator. If the API returns a null value, we return an empty list instead. This prevents the "Object Reference Not Set" error that crashes most apps.

### 3. Method to Get a Specific Product (With Error Handling)

C#
```
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
```

#### Deep Dive Explanation:

- **`$"/api/product/{id}"`**: We use **String Interpolation** to stick the ID number directly into the web address.
- **`response.IsSuccessStatusCode`**: This checks the "HTTP Status Code." If the server says **200 OK**, we move forward.
- **`product.IsValid = true`**: We manually set our switch to "True" so the UI knows it’s safe to display the data.
- **`ReadAsStringAsync()`**: If the server fails (e.g., Error 404), we don't want the data; we want the **Reason**. We grab the error message sent by the server and store it so we can show the user what went wrong.

### 4. Method to Create a New Product (POST)

C#
```
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
```

#### Deep Dive Explanation:

- **`PostAsJsonAsync`**: Unlike GET, this method sends data **to** the server. It takes our C# `product` object, turns it into JSON, and puts it in the request body.
- **`createdProduct.Value`**: If successful, the API usually sends back the saved product including the new ID generated by SQL. We capture that here to update our UI.
- **Error Logic**: If the product is invalid (e.g., price is negative), the API sends an error. We set `IsValid = false` and capture that error message so the user knows why it wasn't saved.

### 5. Method to Update a Product (PUT)

C#
```
public async Task<ModelValidation<Product>> UpdateProduct(Product product)
{
    var response = await _client.PutAsJsonAsync("/api/product", product);
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
```

#### Deep Dive Explanation:

- **`PutAsJsonAsync`**: This is the standard HTTP verb for **Updates**. It tells the API: "Find the record with this ID and replace its values with this new data."
- **Handling Success**: Even on an update, we want to return the updated object to ensure our app's screen shows exactly what is now stored in the database.
- **Handling Failure**: If someone else deleted the product while we were editing it, the server will send an error. Our `ModelValidation` wrapper captures that failure so we can show a "Product no longer exists" message.

### 6. Method to Delete a Product (DELETE)

C#
```
public async Task<ModelValidation<Product>> DeleteProduct(int id)
{
    var response = await _client.DeleteAsync($"/api/product/{id}");
    var deletedProduct = new ModelValidation<Product>();

    if(response.IsSuccessStatusCode)
    {
        deletedProduct.IsValid = true;
        deletedProduct.Value = await response.Content.ReadFromJsonAsync<Product>();
    }
    else
    {
        deletedProduct.IsValid = false;
        deletedProduct.ErrorMessage = await response.Content.ReadAsStringAsync();
    }

    return deletedProduct;
}
```

#### Deep Dive Explanation:

- **`DeleteAsync`**: This sends a specific request to the server to remove a record. It is dangerous, so it requires a specific ID in the URL.
- **`deletedProduct.Value`**: Often, an API returns the item it just deleted as a final confirmation. We store it here just in case the UI needs to show a "Successfully deleted [Product Name]" message.
- **Safety First**: If the delete fails (for example, if the product is linked to a sales order and cannot be removed), we catch the server's explanation in `ErrorMessage` and set `IsValid` to false.


## Step 28: The Extensions Folder (The Installation Script)

### What are we doing here?

Think of all the code we wrote in the `ProductService` as a complex engine. If we want to use that engine in our app (client), we don't want to manually wire it up every single time. That would be messy and lead to mistakes.

Instead, we are building a **"Plug-and-Play" Extension**.

#### What to expect in this section:

1. **The "Hook":** We are going to "attach" our Class Library directly to the standard .NET setup menu. This means when you go to your main app, our library will look like a built-in feature of .NET.
2. **The Configuration (Action):** We are setting up a way for the main app to "pass" its settings (like the API URL) into the library without the library having to search for them.
3. **The Dependency Injection (Singleton):** We are telling the system exactly how to create our `ProductService`. We are registering it as a **Singleton**, which is a professional way of saying: _"Create one messenger and let everyone in the app share it."_ This saves memory and makes the app faster.

### The ProductExtension Code & Deep Dive

To keep this organized, right-click your Library project and create a new folder named **Extensions**. Inside it, create a class file named `ProductExtension.cs`.

C#
```
    public static class ProductExtension
    {
        public static void AddProductServiceExtension(this IServiceCollection services, Action<ApiBaseUrl> configure)
        {
            // 1. Save the configuration into the system locker
            services.Configure(configure);

            // 2. Register the service as a Singleton
            services.AddSingleton(provider =>
            {
                // Grab the saved URL from the locker
                var apiBaseUrl = provider.GetRequiredService<Microsoft.Extensions.Options.IOptions<ApiBaseUrl>>().Value;
                
                // Return the service ready for action
                return new ProductService(apiBaseUrl);
            });
        }
    }
```

#### Deep Dive Explanation:

- **`public static class & method`**: Extension methods _must_ be static. This allows them to "float" in the system so they can be called from anywhere without needing to create an object first.
- **`this IServiceCollection services`**: This is the most important part of the code. The `this` keyword tells .NET: _"Add this new method to the standard list of options in `Program.cs.`"_ It’s how we make our library "plug-and-play."
- **`Action<ApiBaseUrl> configure`**: This is a **Delegate**. It’s like a blank form that we hand to the main app. The app fills in the `ApiUrl`, and then hands the form back to us so we know where the API is.
- **`services.Configure(configure)`**: This takes that "form" and stores it in the **Options Pattern**. Think of this as a secure locker in the app's memory.
- **`services.AddSingleton(provider => { ... })`**: We tell the app: _"Whenever someone asks for a ProductService, follow this recipe to build it."_
- **`GetRequiredService<IOptions<ApiBaseUrl>>().Value`**: This is the final step of the bridge. The code reaches into the "locker," grabs the API URL that was configured at the start, and plugs it into the `ProductService` constructor.

## Step 29: From Coder to Architect (The Final Handshake)

By finishing this extension, you’ve officially moved from being a "coder" who just writes lines of text to being an **Architect** who builds systems. Your library is now fully decoupled, professional, and ready to be used by any frontend you choose—whether it's a website, a mobile app, or even a desktop program.

**What we have achieved:**

1. **Independence:** Our apps don't need to know how the API works; they just trust the library.
2. **Scalability:** If we want to add a third app tomorrow, we just "plug in" this library and it's ready in seconds.
3. **Professionalism:** You are using the same **Dependency Injection** and **Options Patterns** used by senior developers at top tech companies.

**The Path Forward:** Everything is wired up and the engine is idling. The logic is solid, the models are ready, and the "messenger" is waiting for orders.

**Now, we are going to consume our Web API in an ASP.NET Core and MAUI app so we can see it running.** This is the exciting part where your code finally comes to life on a screen, and you get to see all those models and services working together to fetch and display your data!

