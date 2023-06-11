using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using AgeCoefficient = Polyathlon.Models.Entities.AgeCoefficient;

namespace Polyathlon.ViewModels
{
    public partial class AgeCoefficientViewModel : SingleObjectViewModel<AgeCoefficient, AgeCoefficientViewEntity, long>
    {
        public static AgeCoefficientViewModel Create()
        {
            return ViewModelSource.Create(() => new AgeCoefficientViewModel());
        }

        protected static AgeCoefficientViewEntity CreateNewViewEntity(AgeCoefficient ageCoefficient, Flurl.Url request)
        {
            AgeCoefficient entity = ageCoefficient with { };
            AgeCoefficientViewEntity ageCoefficientViewEntity = new(entity, request);
            return ageCoefficientViewEntity;
        }

        protected AgeCoefficientViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}