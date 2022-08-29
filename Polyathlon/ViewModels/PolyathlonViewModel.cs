using DevExpress.Mvvm.POCO;
using Polyathlon.DbDataModel;
using Newtonsoft.Json.Linq;
using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Polyathlon.Db.ModuleDb;

using System.Collections.ObjectModel;

namespace Polyathlon.ViewModels;

public partial class PolyathlonViewModel : DocumentsViewModel<ModuleViewEntity>
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
    protected PolyathlonViewModel() : base()
    {
    }
    
    ModuleViewEntity CreateModule(Module entity, Flurl.Url origin) {
        return new ModuleViewEntity(entity, origin);
    }
    //protected override List<PolyathlonModuleDescription> CreateModules()
    //{
    //    //LocalViewDbBase.LocalViewDb.GetModuleViewCollection<Module, ModuleViewEntity>("http://base.rsu.edu.ru:5984/polyathlon-modules/_partition/module/_all_docs?include_docs=true", CreateModule);
    //    ObservableCollection<ModuleViewEntity> ViewEntities = LocalViewDbBase.LocalViewDb.GetModuleViewCollection<Module, ModuleViewEntity>("http://base.rsu.edu.ru:5984/polyathlon-modules/_partition/module/_all_docs?include_docs=true", CreateModule);
    //    return ViewEntities;
    //    string moduleContent = @"{'total_rows':4,'offset':0,'rows':[
    //            { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','moduleTitle':'Модуль 1','moduleGroup':'Operation','documentType':'MyView', 'tileColor':'255,255,0', 'tileFontSize':'12', 'tileTitle':'Регионы', 'requests': [{'url':'https://localhost:5984/polyathlon/region?include_docs=true'}, {'url':'https://localhost:5984/polyathlon/clubs?include_docs=true'}]}},
    //            { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','moduleTitle':'Модуль 2','moduleGroup':'Operation','documentType':'MyView2', 'tileColor':'0,255,0', 'tileFontSize':'10', 'tileTitle':'Модуль 2'} },
    //            { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','moduleTitle':'Регионы','moduleGroup':'Operation','documentType':'RegionCollectionView', 'tileColor':'255,0,255', 'tileFontSize':'12', 'tileTitle':'Регионы', 'requests': [{'url':'http://base.rsu.edu.ru:5984/polyathlon/_partition/region/_all_docs?include_docs=true'}]}},
    //            { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','moduleTitle':'Пользователь','moduleGroup':'Operation','documentType':'ChangeUserView', 'tileColor':'255,0,255', 'tileFontSize':'12', 'tileTitle':'Пользователь', 'requests': []}}
    //        ]}";
        
    //    JObject jModules = JObject.Parse(moduleContent);

    //    IList<JToken> rows = jModules["rows"].Children().ToList();

    //    List<PolyathlonModuleDescription> Modules = new List<PolyathlonModuleDescription>(rows.Count);

    //    foreach (JToken row in rows)
    //    {
    //        //ModuleModel moduleModel = row["doc"].ToObject<ModuleModel>();
    //        //ModuleModel moduleModel = row["doc"].ToObject<ModuleModel>();
    //        //PolyathlonModuleDescription moduleDescription = new PolyathlonModuleDescription(tileColor: moduleModel.TileColor, documentType: moduleModel.ViewDocumentType, group: moduleModel.Group, title: moduleModel.Title);
    //        PolyathlonModuleDescription moduleDescription = row["doc"].ToObject<PolyathlonModuleDescription>();
    //        Modules.Add(moduleDescription);
    //    }

    //    //PolyathlonModuleDescription[] modules = new PolyathlonModuleDescription[] {
    //        //new PolyathlonModuleDescription("Dashboard", "11", MyWorldGroup, (FilterViewModelBase)null),
    //        //new PolyathlonModuleDescription("Dashboard", DashboardViewDocumentType, MyWorldGroup, (FilterViewModelBase)null),
    //        //new PolyathlonModuleDescription("Tasks", PolyathlonViewModel.EmployeeTaskCollectionViewDocumentType, MyWorldGroup, FiltersSettings.GetTaskFilter(this)),
    //        //new PolyathlonModuleDescription("Employees", PolyathlonViewModel.EmployeeCollectionViewDocumentType, MyWorldGroup, FiltersSettings.GetEmployeeFilter(this)),
    //        //new PolyathlonModuleDescription("Products", PolyathlonViewModel.ProductCollectionViewDocumentType, OperationsGroup, FiltersSettings.GetProductFilter(this)),
    //        //new PolyathlonModuleDescription("Customers", CustomerCollectionViewDocumentType, OperationsGroup, FiltersSettings.GetCustomerFilter(this)),
    //        //new PolyathlonModuleDescription("Sales", PolyathlonViewModel.OrderCollectionViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
    //        //new PolyathlonModuleDescription("Opportunities", PolyathlonViewModel.QuoteCollectionViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
    //    //};
    //    //foreach (var module in modules)
    //    //{
    //    //    if (module.FilterViewModel == null)
    //    //        continue;
    //    //    PolyathlonModuleDescription moduleRef = module;
    //    //    module.FilterViewModel.NavigateAction = (() =>
    //    //    {
    //    //        if (this.ActiveModule != moduleRef)
    //    //            Show(moduleRef);
    //    //    });
    //    //}
    //    return Modules;
    //}

    protected override ObservableCollection<ModuleViewEntity> CreateModules() {
        //LocalViewDbBase.LocalViewDb.GetModuleViewCollection<Module, ModuleViewEntity>("http://base.rsu.edu.ru:5984/polyathlon-modules/_partition/module/_all_docs?include_docs=true", CreateModule);
        ObservableCollection<ModuleViewEntity> ViewEntities = new(ModuleDatabase.ModuleDb.GetModuleViewCollection<Module, ModuleViewEntity>("http://base.rsu.edu.ru:5984/polyathlon-modules/_partition/module/_all_docs?include_docs=true", CreateModule).Values);
        //        ViewEntities.
        //return new ObservableCollection<ModuleViewEntity>(ViewEntities.OrderBy(m => m.SortOrder));//  ViewEntities;
        return ViewEntities;//  ViewEntities;
    }
}