using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;
using Polyathlon.Helpers.ViewModel;
using Polyathlon.DbDataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polyathlon.DataModel;
namespace Polyathlon.ViewModels
{
 
    public partial class PolyathlonViewModel : DocumentsViewModel<PolyathlonModuleDescription, IDbUnitOfWork>
    {
        const string MyWorldGroup = "Polyathlon";
        const string OperationsGroup = "Operations";
        /// <summary>
        /// Creates a new instance of PolyathlonViewModel as a POCO view model.
        /// </summary>
        public static PolyathlonViewModel Create()
        {
            return ViewModelSource.Create(() => new PolyathlonViewModel());
        }

        /// <summary>
        /// Initializes a new instance of the PolyathlonViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the PolyathlonViewModel type without the POCO proxy factory.
        /// </summary>
        protected PolyathlonViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory())
        {
        }
        protected override List<PolyathlonModuleDescription> CreateModules()
        {
            string moduleContent = @"{'total_rows':4,'offset':0,'rows':[
                { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','title':'Модуль 1','group':'Operation','ViewDocumentType':'MyView', 'tileColor':'128,255,255,0'} },
                { 'id':'module:8997d7edcad3eae911a0c9abb1002c9a','key':'module:8997d7edcad3eae911a0c9abb1002c9a','value':{ 'rev':'2-f95dbc40cbfc2d4f619df957835df54e'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb1002c9a','_rev':'2-f95dbc40cbfc2d4f619df957835df54e','title':'Модуль 2','group':'Operation','ViewDocumentType':'MyView2', 'tileColor':'0,255,0'} }          
            ]}";
            
            JObject jModules = JObject.Parse(moduleContent);

            IList<JToken> rows = jModules["rows"].Children().ToList();

            List<PolyathlonModuleDescription> Modules = new List<PolyathlonModuleDescription>(rows.Count);

            foreach (JToken row in rows)
            {
                ModuleModel moduleModel = row["doc"].ToObject<ModuleModel>();
                PolyathlonModuleDescription moduleDescription = new PolyathlonModuleDescription(tileColor: moduleModel.TileColor, documentType: moduleModel.ViewDocumentType, group: moduleModel.Group, title: moduleModel.Title);
                Modules.Add(moduleDescription);
            }

            //PolyathlonModuleDescription[] modules = new PolyathlonModuleDescription[] {
                //new PolyathlonModuleDescription("Dashboard", "11", MyWorldGroup, (FilterViewModelBase)null),
                //new PolyathlonModuleDescription("Dashboard", DashboardViewDocumentType, MyWorldGroup, (FilterViewModelBase)null),
                //new PolyathlonModuleDescription("Tasks", PolyathlonViewModel.EmployeeTaskCollectionViewDocumentType, MyWorldGroup, FiltersSettings.GetTaskFilter(this)),
                //new PolyathlonModuleDescription("Employees", PolyathlonViewModel.EmployeeCollectionViewDocumentType, MyWorldGroup, FiltersSettings.GetEmployeeFilter(this)),
                //new PolyathlonModuleDescription("Products", PolyathlonViewModel.ProductCollectionViewDocumentType, OperationsGroup, FiltersSettings.GetProductFilter(this)),
                //new PolyathlonModuleDescription("Customers", CustomerCollectionViewDocumentType, OperationsGroup, FiltersSettings.GetCustomerFilter(this)),
                //new PolyathlonModuleDescription("Sales", PolyathlonViewModel.OrderCollectionViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
                //new PolyathlonModuleDescription("Opportunities", PolyathlonViewModel.QuoteCollectionViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
            //};
            //foreach (var module in modules)
            //{
            //    if (module.FilterViewModel == null)
            //        continue;
            //    PolyathlonModuleDescription moduleRef = module;
            //    module.FilterViewModel.NavigateAction = (() =>
            //    {
            //        if (this.ActiveModule != moduleRef)
            //            Show(moduleRef);
            //    });
            //}
            return Modules;
        }
    }

    public partial class PolyathlonModuleDescription : ModuleDescription<PolyathlonModuleDescription>
    {
        public PolyathlonModuleDescription(string title, Color tileColor, string documentType, string group, Func<PolyathlonModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, tileColor, peekCollectionViewModelFactory)
        {
        }

        public PolyathlonModuleDescription(string title, Color tileColor, string documentType, string group, FilterViewModelBase filterViewModel)
            : base(title, documentType, group, tileColor)
        {
            FilterViewModel = filterViewModel;
        }

        public FilterViewModelBase FilterViewModel { get; private set; }
    }
}

