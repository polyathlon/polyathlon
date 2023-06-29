using DevExpress.Mvvm.POCO;
using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;

namespace Polyathlon.ViewModels;

public class ClubViewModel : SingleObjectViewModel<Club, ClubViewEntity, long>
{
    public static ClubViewModel Create()
    {
        return ViewModelSource.Create(() => new ClubViewModel());
    }

    protected static ClubViewEntity CreateNewViewEntity(Club club, Flurl.Url request)
    {
        Club entity = club with { };
        ClubViewEntity viewEntity = new(entity, request);
        return viewEntity;
    }

    protected ClubViewModel() : base(CreateNewViewEntity)
    {
    }
}