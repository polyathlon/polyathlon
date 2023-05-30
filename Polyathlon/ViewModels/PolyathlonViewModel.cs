using System.Collections.ObjectModel;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Polyathlon.Db.ModuleDb;

using DevExpress.Mvvm.POCO;

namespace Polyathlon.ViewModels;

public partial class PolyathlonViewModel : DocumentsViewModel<ModuleViewEntity>
{
    public static PolyathlonViewModel Create()
    {
        return ViewModelSource.Create(() => new PolyathlonViewModel());
    }

    protected PolyathlonViewModel() : base()
    {
    }

    private ModuleViewEntity CreateModule(Module entity, Flurl.Url origin)
    {
        return new ModuleViewEntity(entity, origin);
    }

    protected override ObservableCollection<ModuleViewEntity> CreateModules()
    {
        ObservableCollection<ModuleViewEntity> ViewEntities = new(
            ModuleDatabase.ModuleDb.GetModuleViewCollection<Module, ModuleViewEntity>(
                "http://localhost:5984/polyathlon/_partition/module/_all_docs?include_docs=true",
                CreateModule)
            .Values);

        return ViewEntities;
    }
}