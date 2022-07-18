using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polyathlon.Helpers.ViewModel;
using Polyathlon.DbDataModel;

namespace Polyathlon.ViewModels
{
    //internal partial class PolyathlonViewModel : DocumentsViewModel<DevAVDbModuleDescription, IDbUnitOfWork>
    internal partial class PolyathlonViewModel : DocumentsViewModel<PolyathlonModuleDescription, IDbUnitOfWork>
    {
        //    public const string EmployeeCollectionViewDocumentType = "EmployeeCollectionView";
        //    public const string EmployeeViewDocumentType = "EmployeeView";
        //    public const string EmployeeMailMergeViewDocumentType = "EmployeeMailMergeView";
        //    public const string EmployeeTaskCollectionViewDocumentType = "EmployeeTaskCollectionView";
        //    public const string EmployeeTaskViewDocumentType = "EmployeeTaskView";
        //    public const string EmployeeNoteViewDocumentType = "EmployeeNoteView";
        //    public const string ProductCollectionViewDocumentType = "ProductCollectionView";
        //    public const string ProductViewDocumentType = "ProductView";
        //    public const string EmployeeReportViewDocumentType = "EmployeeReportView";
        //    public const string NoteViewDocumentType = "EvaluationView";
        //    public const string CustomerCollectionViewDocumentType = "CustomerCollectionView";
        //    public const string PrintableControlPrintPreviewDocumentType = "PrintableControlPrintPreview";
        //    public const string CustomerViewDocumentType = "CustomerView";
        //    public const string OrderViewDocumentType = "OrderView";
        //    public const string CustomFilterViewDocumentType = "CustomFilterView";
        //    public const string OrderCollectionViewDocumentType = "OrderCollectionView";
        //    public const string QuoteCollectionViewDocumentType = "QuoteCollectionView";
        //    public const string DashboardViewDocumentType = "DashboardView";

        public override PolyathlonModuleDescription DefaultModule
        {
            get { return Modules.Where(m => m.DocumentType == "EmployeeCollectionView").First(); }
        }
        public IList<IGrouping<string, PolyathlonModuleDescription>> ModuleGroups
        {
            get { return Modules.GroupBy(m => m.ModuleGroup).ToList(); }
        }
        protected override void DocumentShown(PolyathlonModuleDescription module, IDocument document)
        {
            base.DocumentShown(module, document);
            if (module != null && module.FilterViewModel != null)
            {
                module.FilterViewModel.SetViewModel(document.Content);
                Messenger.Default.Send<DocumentShownMessage>(new DocumentShownMessage(module.DocumentType));
            }
        }
        //    public void Info()
        //    {
        //        try
        //        {
        //            Data.Utils.SafeProcess.Start("https://documentation.devexpress.com/#WindowsForms/CustomDocument114443");
        //        }
        //        catch (System.ComponentModel.Win32Exception) { }
        //    }
        //    public void About()
        //    {
        //        DevExpress.Utils.About.AboutHelper.Show(DevExpress.Utils.About.ProductKind.DXperienceWin, new DevExpress.Utils.About.ProductStringInfo("Hybrid App", "WinForm Controls"));
        //    }
        public void Exit()
        {
            Program.MainForm?.Close();
        }
    }
}
