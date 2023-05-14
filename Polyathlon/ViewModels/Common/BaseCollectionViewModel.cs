using System.Collections.ObjectModel;

using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

using Polyathlon.Db.Common;
using Polyathlon.Db.ModuleDb;
using Polyathlon.Db.LocalDb;
using Polyathlon.Models.Common;
using Polyathlon.Models.Entities;
using Polyathlon.Properties;

namespace Polyathlon.ViewModels.Common;

[POCOViewModel]
public partial class CollectionViewModel<TViewEntity, TEntity> : ISupportParameter
   where TEntity : EntityBase
   where TViewEntity : ViewEntityBase<TEntity>
{
    private ModuleDatabase moduleDb;

    public ModuleViewEntity ModuleDescription { get; private set; }

    public ObservableCollection<TViewEntity> Entities { get; set; }

    protected IMessageBoxService MessageBoxService
    { get { return this.GetRequiredService<IMessageBoxService>(); } }

    private CancellationTokenSource loadCancellationTokenSource;

    public virtual void Delete(TViewEntity ViewEntity)
    {
        if (MessageBoxService.ShowMessage(string.Format(CommonResources.Confirmation_Delete, typeof(TEntity).Name), CommonResources.Confirmation_Caption, MessageButton.YesNo) != MessageResult.Yes)
            return;
        try
        {
            LocalDatabase.LocalDb.DeleteEntityAsync<TViewEntity, TEntity>(ViewEntity);
            Entities.Remove(ViewEntity);
            this.RaisePropertyChanged(x => x.Entities);
        }
        catch (ConnectException e)
        {
            MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
        }
        catch (DbException e)
        {
            MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
        }
        catch (Exception e)
        {
            MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
        }
    }

    public virtual bool IsLoading { get; protected set; } = false;

    public virtual object Parameter { get; set; }

    protected CollectionViewModel(Func<TEntity, Flurl.Url, TViewEntity> createViewEntity)
    {
        moduleDb = ModuleDatabase.ModuleDb;
        this.createViewEntity = createViewEntity;
    }

    private TViewEntity _selectedEntity;

    public virtual TViewEntity SelectedEntity
    {
        get
        {
            return _selectedEntity;
        }
        set
        {
            _selectedEntity = value;
        }
    }

    public Func<TEntity, Flurl.Url, TViewEntity> createViewEntity;

    protected void OnParameterChanged()
    {
        ModuleDescription = (ModuleViewEntity)Parameter;
        LoadEntities();
    }

    protected IDocumentManagerService DocumentManagerService
    { get { return this.GetService<IDocumentManagerService>(); } }

    public void New()
    {
        DocumentManagerService.MyShowNewEntityDocument<TEntity>(SingleModelAction.New, this);
    }

    public void Edit(TViewEntity viewEntity)
    {
        DocumentManagerService.ShowMyExistingEntityDocument<TEntity, TViewEntity>((viewEntity, SingleModelAction.Edit), this);
    }

    public void Copy(TViewEntity viewEntity)
    {
        DocumentManagerService.ShowMyExistingEntityDocument<TEntity, TViewEntity>((viewEntity, SingleModelAction.Copy), this);
    }

    protected void LoadEntities(bool forceLoad = false)
    {
        if (forceLoad)
        {
            if (loadCancellationTokenSource != null)
                loadCancellationTokenSource.Cancel();
        }
        else if (IsLoading)
        {
            return;
        }
        loadCancellationTokenSource = LoadEntitiesTask();
    }

    private CancellationTokenSource LoadEntitiesTask()
    {
        IsLoading = true;
        var cancellationTokenSource = new CancellationTokenSource();
        Task.Factory.StartNew(() =>
        {
            var entities = new ObservableCollection<TViewEntity>(moduleDb.GetModuleViewCollection<TEntity, TViewEntity>(ModuleDescription, createViewEntity).Values);
            return entities;
        }).ContinueWith(x =>
        {
            Entities = x.Result;
            this.RaisePropertyChanged(m => m.Entities);
            IsLoading = false;
        }, cancellationTokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        return cancellationTokenSource;
    }

    protected CollectionViewModel()
    {
        moduleDb = ModuleDatabase.ModuleDb;
    }
}