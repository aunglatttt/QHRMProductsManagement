using Dapper;
using QHRMProductsManagement.Models;
using QHRMProductsManagement.Services;
using System.Data;
using System.Data.SqlClient;

namespace QHRMProductsManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<PagedList> GetProductsPaged(int pageNumber, int pageSize)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"
            SELECT ProductId, ProductName, Price, Description, CreatedDate
            FROM Products
            ORDER BY ProductId
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY;";

                string countSql = "SELECT COUNT(*) FROM Products;";

                var parameters = new
                {
                    Offset = (pageNumber - 1) * pageSize,
                    PageSize = pageSize
                };

                var products = (await dbConnection.QueryAsync<Product>(sql, parameters)).ToList();
                var totalCount = await dbConnection.ExecuteScalarAsync<int>(countSql);

                return new PagedList
                {
                    Products = products,
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
                };
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = "SELECT * FROM Products WHERE ProductId = @Id";
                return await dbConnection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
            }
        }

        public async Task AddProduct(Product product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"INSERT INTO Products (ProductName, Price, Description, CreatedDate)
                               VALUES (@ProductName, @Price, @Description, @CreatedDate)";
                await dbConnection.ExecuteAsync(sql, product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"UPDATE Products
                               SET ProductName = @ProductName, Price = @Price, Description = @Description
                               WHERE ProductId = @ProductId";
                await dbConnection.ExecuteAsync(sql, product);
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = "DELETE FROM Products WHERE ProductId = @Id";
                await dbConnection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<int> GetTotalProductsCount()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string countSql = "SELECT COUNT(*) FROM Products;";
                return await dbConnection.ExecuteScalarAsync<int>(countSql);
            }
        }
    }
}
