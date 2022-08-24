namespace Polyathlon.Models.Entities;

public class RegionInfoWithSales
{
    //private Lazy<IEnumerable<CustomerStore>> customerStores;

    //private Lazy<IEnumerable<CustomerEmployee>> customerEmployees;

    public long Id { get; set; }

    public string Name { get; set; }

    public string HomeOfficeLine { get; set; }

    public string HomeOfficeCity { get; set; }

 

    public string HomeOfficeZipCode { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public decimal? TotalSales { get; set; }

    //public IEnumerable<CustomerStore> CustomerStores => customerStores.Value;

    //public IEnumerable<CustomerEmployee> Employees => customerEmployees.Value;

    public IEnumerable<decimal> MonthlySales { get; private set; }

    //public void Init(Func<IEnumerable<CustomerStore>> getStores, Func<IEnumerable<CustomerEmployee>> getEmployees, IEnumerable<decimal> monthlySales)
    //{
    //    customerStores = new Lazy<IEnumerable<CustomerStore>>(getStores);
    //    customerEmployees = new Lazy<IEnumerable<CustomerEmployee>>(getEmployees);
    //    MonthlySales = monthlySales;
    //}

}
