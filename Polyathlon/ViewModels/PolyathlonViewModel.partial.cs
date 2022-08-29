using DevExpress.Mvvm;
using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;

namespace Polyathlon.ViewModels
{
    //internal partial class PolyathlonViewModel : DocumentsViewModel<DevAVDbModuleDescription, IDbUnitOfWork>
    public partial class PolyathlonViewModel : DocumentsViewModel<ModuleViewEntity>
    {
        public override ModuleViewEntity DefaultModule
        {
            get { return Modules.Where(m => m.ViewType == "MyView").First(); }
        }
        public IList<IGrouping<string, ModuleViewEntity>> ModuleGroups
        {
            get { 
                return Modules.GroupBy(m => m.Group).OrderBy(m => m.Key).ToList(); 
            }
        }
        protected override void DocumentShown(ModuleViewEntity module, IDocument document)
        {
            base.DocumentShown(module, document);
            //if (module != null && module.FilterViewModel != null)
            //{
            //    module.FilterViewModel.SetViewModel(document.Content);
            //    Messenger.Default.Send<DocumentShownMessage>(new DocumentShownMessage(module.DocumentType));
            //}
        }
        
        public void Exit()
        {
            Program.MainForm?.Close();
        }
    }
}
