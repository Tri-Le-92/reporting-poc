using System.ComponentModel;

namespace BlazorViewerAndDesigner.Server.DataObject;

using System.Collections.Generic;
using System.ComponentModel; // Cần thêm namespace này cho [DataObject] và [DataObjectMethod]

// Class chứa dữ liệu cho một sản phẩm (Bạn đã có)
public class Product
{
    public string Name { get; set; }
    public string ProductNumber { get; set; }
    public decimal ListPrice { get; set; }
    public int ProductModelID { get; set; } // Giữ lại hoặc đổi tên nếu cần
    public string Color { get; set; }
}

// Class đóng vai trò là nguồn dữ liệu ObjectDataSource
// Đánh dấu [DataObject] để các công cụ thiết kế (như Telerik Report Designer)
// có thể nhận diện đây là một nguồn dữ liệu tiềm năng.
[DataObject]
public class Products // Có thể đổi tên class này thành ví dụ: ProductRepository hoặc ProductDataAccess cho rõ nghĩa hơn
{
    // Đánh dấu phương thức này là phương thức chính để lấy dữ liệu (Select)
    // Tham số thứ hai 'true' đánh dấu đây là phương thức Select mặc định.
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public IEnumerable<Product> GetProducts() // Hoặc List<Product> cũng được
    {
        // *** Đây là nơi bạn viết code để lấy dữ liệu thực tế ***
        // Ví dụ: Gọi database, gọi API, đọc từ file, lấy từ cache SignalR...
        // Dưới đây chỉ là dữ liệu giả lập để minh họa:
        List<Product> productList = new List<Product>();

        productList.Add(new Product {
            Name = "HL Road Frame - Black, 58",
            ProductNumber = "FR-R92B-58",
            Color = "Black",
            ListPrice = 1431.50M,
            ProductModelID = 6
        });
        productList.Add(new Product {
            Name = "LL Mountain Frame - Silver, 42",
            ProductNumber = "FR-M63S-42",
            Color = "Silver",
            ListPrice = 339.99M,
            ProductModelID = 19
        });
         productList.Add(new Product {
            Name = "Touring-1000 Blue, 54",
            ProductNumber = "BK-T79U-54",
            Color = "Blue",
            ListPrice = 2384.07M,
            ProductModelID = 25
        });
        // ... Thêm các sản phẩm khác

        return productList;
    }

    // Bạn cũng có thể thêm các phương thức khác nếu cần
    // Ví dụ: Lấy sản phẩm theo màu sắc
    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public IEnumerable<Product> GetProductsByColor(string color)
    {
         List<Product> productList = new List<Product>();
         // Logic lọc sản phẩm theo màu 'color'
         // ... (Ví dụ lấy từ DB: WHERE Color = @color)
         return productList;
    }

    // Có thể có cả phương thức Insert, Update, Delete nếu cần
    // [DataObjectMethod(DataObjectMethodType.Insert)]
    // public void InsertProduct(Product product) { ... }

    // [DataObjectMethod(DataObjectMethodType.Update)]
    // public void UpdateProduct(Product product) { ... }

    // [DataObjectMethod(DataObjectMethodType.Delete)]
    // public void DeleteProduct(int productId) { ... }
}

