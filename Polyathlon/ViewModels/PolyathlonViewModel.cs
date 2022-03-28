using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Polyathlon.Helpers.ViewModel;
using Polyathlon.ViewModels.;

namespace Polyathlon.ViewModels
{
    internal partial class PolyathlonViewModel : DocumentsViewModel<PolyathlonModuleDescription, IDevAVDbUnitOfWork>
    {
        const string MyWorldGroup = "My World";
        const string OperationsGroup = "Operations";
        /// <summary>
        /// Creates a new instance of DevAVDbViewModel as a POCO view model.
        /// </summary>
        public static PolyathlonViewModel Create()
        {
            return ViewModelSource.Create(() => new PolyathlonViewModel());
        }

        /// <summary>
        /// Initializes a new instance of the DevAVDbViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DevAVDbViewModel type without the POCO proxy factory.
        /// </summary>
        protected PolyathlonViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory())
        {
        }

        protected override PolyathlonModuleDescription[] CreateModules()
        {
            PolyathlonModuleDescription[] modules = new PolyathlonModuleDescription[] {
                new PolyathlonModuleDescription("Dashboard", DashboardViewDocumentType, MyWorldGroup, (FilterViewModelBase)null),
                new PolyathlonModuleDescription("Tasks", PolyathlonViewModel.EmployeeTaskCollectionViewDocumentType, MyWorldGroup, FiltersSettings.GetTaskFilter(this)),
                new PolyathlonModuleDescription("Employees", PolyathlonViewModel.EmployeeCollectionViewDocumentType, MyWorldGroup, FiltersSettings.GetEmployeeFilter(this)),
                new PolyathlonModuleDescription("Products", PolyathlonViewModel.ProductCollectionViewDocumentType, OperationsGroup, FiltersSettings.GetProductFilter(this)),
                new PolyathlonModuleDescription("Customers", CustomerCollectionViewDocumentType, OperationsGroup, FiltersSettings.GetCustomerFilter(this)),
                new PolyathlonModuleDescription("Sales", PolyathlonViewModel.OrderCollectionViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
                new PolyathlonModuleDescription("Opportunities", PolyathlonViewModel.QuoteCollectionViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
            };
            foreach (var module in modules)
            {
                if (module.FilterViewModel == null)
                    continue;
                PolyathlonModuleDescription moduleRef = module;
                module.FilterViewModel.NavigateAction = (() => {
                    if (this.ActiveModule != moduleRef)
                        Show(moduleRef);
                });
            }
            return modules;
        }
    }
    public partial class PolyathlonModuleDescription : ModuleDescription<PolyathlonModuleDescription>
    {
        public PolyathlonModuleDescription(string title, string documentType, string group, Func<PolyathlonModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory)
        {
        }

        public PolyathlonModuleDescription(string title, string documentType, string group, FilterViewModelBase filterViewModel)
            : base(title, documentType, group)
        {
            FilterViewModel = filterViewModel;
        }

        public FilterViewModelBase FilterViewModel { get; private set; }
    }
}

