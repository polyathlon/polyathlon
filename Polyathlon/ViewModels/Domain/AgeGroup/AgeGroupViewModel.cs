using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using AgeGroup = Polyathlon.Models.Entities.AgeGroup;

namespace Polyathlon.ViewModels
{
    public partial class AgeGroupViewModel : SingleObjectViewModel<AgeGroup, AgeGroupViewEntity, long>
    {
        public static AgeGroupViewModel Create()
        {
            return ViewModelSource.Create(() => new AgeGroupViewModel());
        }

        protected static AgeGroupViewEntity CreateNewViewEntity(AgeGroup ageGroup, Flurl.Url request)
        {
            AgeGroup entity = ageGroup with { };
            AgeGroupViewEntity ageGroupViewEntity = new(entity, request);
            return ageGroupViewEntity;
        }

        protected AgeGroupViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}