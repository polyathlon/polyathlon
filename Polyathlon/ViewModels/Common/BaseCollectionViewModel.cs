using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using Polyathlon.DataModel;
using System.Collections.ObjectModel;

namespace Polyathlon.ViewModels.Common
{
    [POCOViewModel]
    public partial class BaseCollectionViewModel<TEntity, TViewEntity> : ISupportParameter, ISupportParentViewModel
       where TEntity : class, new()
       where TViewEntity : class, new() //, ISupportParentViewModel //: CollectionViewModel<Entities.Region, RegionInfoWithSales, long, IDbUnitOfWork>    
    {
        /// <summary>
        /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>

        private LocalViewDbBase localViewDb;

        public PolyathlonModuleDescription ModuleDescription { get; private set; }

        public ObservableCollection<TViewEntity> Entities { get; private set; }

        //public static BaseCollectionViewModel Create(object a)
        //{
        //    //Debug.WriteLine("111");
        //    return ViewModelSource.Create(() => new RegionCollectionViewModel(LocalViewDbBase.LocalViewDb));
        //}

        public bool IsLoading { get; set; } = false;
        public virtual object Parameter { get; set; }
        //public object ParentViewModel { get; set; }


        /// <summary>
        /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        //public static RegionCollectionViewModel Create(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
        //{
        //    return ViewModelSource.Create(() => new RegionCollectionViewModel(unitOfWorkFactory));
        //}

        /// <summary>
        /// Initializes a new instance of the CustomerCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CustomerCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        //protected RegionCollectionViewModel(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
        //    //: base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Customers, query => DevExpress.DevAV.QueriesHelper.GetCustomerInfoWithSales(query))
        //    : base(unitOfWorkFactory, x => null, null)
        //{
        //}

        protected BaseCollectionViewModel(Func<TEntity, TViewEntity> createViewEntity)
        {
            localViewDb = LocalViewDbBase.LocalViewDb;
            this.createViewEntity = createViewEntity;
        }

        TViewEntity _selectedEntity;
        public virtual TViewEntity SelectedEntity {
            get {
                return _selectedEntity; 
            }
            set {
                _selectedEntity = value;
            }
        }

        public Func<TEntity, TViewEntity> createViewEntity;

        protected void OnParameterChanged()
        {

            ModuleDescription = (PolyathlonModuleDescription)Parameter;
            //LoadCore();
            Entities = localViewDb.GetLocalViewCollection<TEntity, TViewEntity>(ModuleDescription, createViewEntity);
            IsLoading = false;
        }

        protected void OnParentViewModelChanged()
        {
            //ModuleDescription = (PolyathlonModuleDescription)Parameter;
            ////LoadCore();
            //Entities = localViewDb.GetLocalViewCollection<TEntity, TViewEntity>(ModuleDescription, createViewEntity);
            //IsLoading = false;
        }
        protected IDocumentManagerService DocumentManagerService { get { return this.GetService<IDocumentManagerService>(); } }

        public object ParentViewModel { get; set; }

        readonly Action<DataModel.Entities.Region> newEntityInitializer;

        public void New()
        {
            DocumentManagerService.MyShowNewEntityDocument<TEntity>(SingleModelAction.New, this);
        }

        public void Edit(TViewEntity viewEntity)
        {
            DocumentManagerService.ShowMyExistingEntityDocument<TEntity, TViewEntity>(viewEntity, this);
        }
        //CancellationTokenSource LoadCore()
        //{
        //    IsLoading = true;
        //    var cancellationTokenSource = new CancellationTokenSource();
        //    System.Threading.Tasks.Task.Factory.StartNew(() =>
        //    {
        //        var entities = localViewDb.GetLocalViewCollection<RegionViewEntity, DataModel.Entities.Region>(ModuleDescription, createViewEntity);
        //        return entities;
        //    }).ContinueWith(x =>
        //    {
        //        Entities = x.Result;
        //        IsLoading = false;
        //    }, cancellationTokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        //    return cancellationTokenSource;
        //}

        //protected RegionCollectionViewModel(object a)    
        //{

        //}

        //protected BaseCollectionViewModel(object a)
        //{
        //    this.localViewDb = LocalViewDbBase.LocalViewDb;
        //}
        protected BaseCollectionViewModel()
        {
            this.localViewDb = LocalViewDbBase.LocalViewDb;
        }
    }
}
