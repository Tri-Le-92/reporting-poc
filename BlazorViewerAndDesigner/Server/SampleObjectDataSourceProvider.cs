using System;
using System.Collections.Generic;
using System.Linq;


namespace BlazorViewerAndDesigner.Server
{
	public class SampleObjectDataSourceProvider
	{
		public string Name => "SampleDataProvider";

		public Type[] GetAvailableTypes()
		{
			return new[] {
				typeof(SampleDataService),
				typeof(ProductService)
			};
		}
	}

	public class SampleDataService
	{
		public static List<Customer> GetCustomers()
		{
			return new List<Customer>
			{
				new Customer { Id = 1, Name = "Nguyễn Văn A", Email = "nguyenvana@example.com", Phone = "0901234567" },
				new Customer { Id = 2, Name = "Trần Thị B", Email = "tranthib@example.com", Phone = "0912345678" },
				new Customer { Id = 3, Name = "Lê Văn C", Email = "levanc@example.com", Phone = "0923456789" },
				new Customer { Id = 4, Name = "Phạm Thị D", Email = "phamthid@example.com", Phone = "0934567890" },
				new Customer { Id = 5, Name = "Hoàng Văn E", Email = "hoangvane@example.com", Phone = "0945678901" }
			};
		}

		public static List<Order> GetOrders()
		{
			return new List<Order>
			{
				new Order { Id = 101, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-5), Total = 1500000 },
				new Order { Id = 102, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-3), Total = 2300000 },
				new Order { Id = 103, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-2), Total = 950000 },
				new Order { Id = 104, CustomerId = 3, OrderDate = DateTime.Now.AddDays(-1), Total = 3200000 },
				new Order { Id = 105, CustomerId = 4, OrderDate = DateTime.Now, Total = 1750000 }
			};
		}

		public static List<OrderDetail> GetOrderDetails(int orderId)
		{
			var allDetails = new List<OrderDetail>
			{
				new OrderDetail { Id = 1001, OrderId = 101, ProductName = "Laptop Dell XPS", Quantity = 1, UnitPrice = 1500000 },
				new OrderDetail { Id = 1002, OrderId = 102, ProductName = "Màn hình Dell 27\"", Quantity = 2, UnitPrice = 750000 },
				new OrderDetail { Id = 1003, OrderId = 102, ProductName = "Bàn phím cơ", Quantity = 1, UnitPrice = 800000 },
				new OrderDetail { Id = 1004, OrderId = 103, ProductName = "Chuột không dây", Quantity = 2, UnitPrice = 475000 },
				new OrderDetail { Id = 1005, OrderId = 104, ProductName = "iPhone 15", Quantity = 1, UnitPrice = 3200000 },
				new OrderDetail { Id = 1006, OrderId = 105, ProductName = "Tai nghe Sony", Quantity = 1, UnitPrice = 1750000 }
			};

			return allDetails.Where(d => d.OrderId == orderId).ToList();
		}
	}

	public class ProductService
	{
		public static List<Product> GetProducts()
		{
			return new List<Product>
			{
				new Product { Id = 1, Name = "Laptop Dell XPS", Category = "Máy tính", Price = 1500000, Stock = 10 },
				new Product { Id = 2, Name = "Màn hình Dell 27\"", Category = "Màn hình", Price = 750000, Stock = 15 },
				new Product { Id = 3, Name = "Bàn phím cơ", Category = "Phụ kiện", Price = 800000, Stock = 20 },
				new Product { Id = 4, Name = "Chuột không dây", Category = "Phụ kiện", Price = 475000, Stock = 30 },
				new Product { Id = 5, Name = "iPhone 15", Category = "Điện thoại", Price = 3200000, Stock = 8 },
				new Product { Id = 6, Name = "Tai nghe Sony", Category = "Âm thanh", Price = 1750000, Stock = 12 }
			};
		}

		public static List<Product> GetProductsByCategory(string category)
		{
			return GetProducts().Where(p => p.Category == category).ToList();
		}
	}

	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}

	public class Order
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal Total { get; set; }
	}

	public class OrderDetail
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Total => Quantity * UnitPrice;
	}

	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
	}
}