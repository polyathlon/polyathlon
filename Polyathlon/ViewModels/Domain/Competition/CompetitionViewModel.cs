using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Competition = Polyathlon.Models.Entities.Competition;

namespace Polyathlon.ViewModels
{
    public partial class CompetitionViewModel : SingleObjectViewModel<Competition, CompetitionViewEntity, long>
    {
        public static CompetitionViewModel Create()
        {
            return ViewModelSource.Create(() => new CompetitionViewModel());
        }

        protected static CompetitionViewEntity CreateNewViewEntity(Competition region, Flurl.Url request)
        {
            Competition entity = region with { };
            CompetitionViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected CompetitionViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}