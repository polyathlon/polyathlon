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
using Polyathlon.Db.Common;

namespace Polyathlon.ViewModels.Common
{
    /// <summary>
    /// The base class for a POCO view models exposing a colection of entities of a given type and CRUD operations against these entities.
    /// This is a partial class that provides extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    /// </summary>
    /// <typeparam name="TViewEntity">An viewentity type.</typeparam>
    /// <typeparam name="TEntity">An entity type.</typeparam>

    public abstract class CollectionViewModelBase<TViewEntity, TEntity>
        where TViewEntity : class
        where TEntity : class        
    {        
        
    }    
}
