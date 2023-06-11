using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using CompetitionKind = Polyathlon.Models.Entities.CompetitionKind;

namespace Polyathlon.ViewModels
{
    public partial class CompetitionKindViewModel : SingleObjectViewModel<CompetitionKind, CompetitionKindViewEntity, long>
    {
        public static CompetitionKindViewModel Create()
        {
            return ViewModelSource.Create(() => new CompetitionKindViewModel());
        }

        protected static CompetitionKindViewEntity CreateNewViewEntity(CompetitionKind region, Flurl.Url request)
        {
            CompetitionKind entity = region with { };
            CompetitionKindViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected CompetitionKindViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}