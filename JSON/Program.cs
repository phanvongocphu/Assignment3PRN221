using FStore.BusinessObject;
using FStore.DataAccess.DAO;

public class Program
{
    static void Main(string[] args)
    {
        ReadProducts();
        ReadJobPostings();
        ReadHRAccount();
        GetCurrentDirectory();
    }
    private static void ReadProducts()
    {
        List<Product> products = ProductDAO.Instance.GetProducts();
        if (products != null)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Unit price: {product.UnitPrice}");
                Console.WriteLine($"Unit in stock: {product.UnitInStock}");
                Console.WriteLine($"Weight: {product.Weight}");
                Console.WriteLine();
            }
        }
        else Console.WriteLine("No Data");
    }

    private static void ReadJobPostings()
    {
        List<JobPosting> jobPostings = JobPostDAO.Instance.GetJobPostings();

        if (jobPostings != null && jobPostings.Count > 0)
        {
            foreach (var jobPosting in jobPostings)
            {
                Console.WriteLine($"Posting ID: {jobPosting.PostingId}");
                Console.WriteLine($"Job Title: {jobPosting.JobPostingTitle}");
                Console.WriteLine($"Description: {jobPosting.Description ?? "No description provided"}");
                Console.WriteLine($"Posted Date: {(jobPosting.PostedDate.HasValue ? jobPosting.PostedDate.Value.ToString("yyyy-MM-dd") : "No date provided")}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No Job Posting Data");
        }
    }