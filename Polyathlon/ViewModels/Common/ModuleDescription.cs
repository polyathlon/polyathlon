
using System.ComponentModel;
using Polyathlon.DataModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Newtonsoft.Json;

namespace Polyathlon.ViewModels.Common;

/// <summary>
/// A base class representing a navigation list entry.
/// </summary>
/// <typeparam name="TModule">A navigation list entry type.</typeparam>
/// 
public abstract class ModuleDescription<TModule> where TModule : ModuleDescription<TModule>
{

    readonly Func<TModule, object> peekCollectionViewModelFactory;
    object? peekCollectionViewModel;

    /// <summary>
    /// Initializes a new instance of the ModuleDescription class.
    /// </summary>
    /// <param name = "title" > A navigation list entry display text.</param>
    /// <param name = "documentType" > A string value that specifies the view type of corresponding document.</param>
    /// <param name = "group" > A navigation list entry group name.</param>
    /// <param name = "peekCollectionViewModelFactory" > An optional parameter that provides a function used to create a PeekCollectionViewModel that provides quick navigation between collection views.</param>
    public ModuleDescription(string moduleTitle, string moduleGroup, string documentType, Func<TModule, object> peekCollectionViewModelFactory = null)
    {
        ModuleTitle = moduleTitle;
        ModuleGroup = moduleGroup;
        DocumentType = documentType;            
        this.peekCollectionViewModelFactory = peekCollectionViewModelFactory;
    }

    public ModuleDescription(Func<TModule, object> peekCollectionViewModelFactory = null)
    {            
        this.peekCollectionViewModelFactory = peekCollectionViewModelFactory;
    }

    [JsonProperty("_id")]
    public string? ModuleId { get; set; }
    [JsonProperty("_rev")]
    public string? ModuleRev { get; set; }
    
    /// <summary>
    /// The navigation list entry display text.
    /// </summary>
    [JsonProperty("moduleTitle")]
    public string ModuleTitle { get; private set; }

    /// <summary>
    /// The navigation list entry display text.
    /// </summary>
    [JsonProperty("TileTitle")]
    public string TileTitle { get; private set; }

    /// <summary>
    /// The navigation list entry group name.
    /// </summary>
    [JsonProperty("moduleGroup")]
    public string ModuleGroup { get; private set; }

    /// <summary>
    /// Contains the corresponding document view type.
    /// </summary>
    [JsonProperty("documentType")]
    public string DocumentType { get; private set; }


    /// <summary>
    /// Color of tileBarItem.
    /// </summary>
    [JsonProperty("tileColor")]
    public Color TileColor { get; private set; }

    /// <summary>
    /// Font Size of tileBarItem.
    /// </summary>
    [JsonProperty("tileFontSize")]        
    public int TileFontSize { get; private set; }

    /// <summary>
    /// A class for storing request's url to the Database.
    /// </summary>
    public class Request
    {
        public string? Url { get; set; }
    }

    /// <summary>
    /// A list of requests to Database.
    /// </summary>
    public List<Request> Requests = new List<Request>();

    /// <summary>
    /// A primary instance of corresponding PeekCollectionViewModel used to quick navigation between collection views.
    /// </summary>
    public object? PeekCollectionViewModel
    {
        get
        {
            if (peekCollectionViewModelFactory == null)
                return null;
            if (peekCollectionViewModel == null)
                peekCollectionViewModel = CreatePeekCollectionViewModel();
            return peekCollectionViewModel;
        }
    }

    /// <summary>
    /// Creates and returns a new instance of the corresponding PeekCollectionViewModel that provides quick navigation between collection views.
    /// </summary>
    public object CreatePeekCollectionViewModel()
    {
        return peekCollectionViewModelFactory((TModule)this);
    }
}    

public partial class PolyathlonModuleDescription : ModuleDescription<PolyathlonModuleDescription>
{
//[JsonConstructor]
public PolyathlonModuleDescription() :
    base()
{

}

public PolyathlonModuleDescription(string moduleTitle, string moduleGroup, string documentType, Func<PolyathlonModuleDescription, object> peekCollectionViewModelFactory = null) :
    base(moduleTitle: moduleTitle, moduleGroup: moduleGroup, documentType: documentType, peekCollectionViewModelFactory: peekCollectionViewModelFactory)
{

}

//public PolyathlonModuleDescription(string title, Color tileColor, string documentType, string group, Func<PolyathlonModuleDescription, object> peekCollectionViewModelFactory = null)
//    : base(title, documentType, group, tileColor, peekCollectionViewModelFactory)
//{
//}

public PolyathlonModuleDescription(string moduleTitle, string moduleGroup, string documentType, FilterViewModelBase filterViewModel)
    : base(moduleTitle: moduleTitle, moduleGroup: moduleGroup, documentType: documentType)
{
    FilterViewModel = filterViewModel;
}

public FilterViewModelBase FilterViewModel { get; private set; }
}