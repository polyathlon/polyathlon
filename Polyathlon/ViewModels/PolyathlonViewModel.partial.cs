﻿using DevExpress.Mvvm;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;

namespace Polyathlon.ViewModels;

public partial class PolyathlonViewModel : DocumentsViewModel<ModuleViewEntity>
{
    public override ModuleViewEntity DefaultModule
    {
        get { return Modules.Where(m => m.ViewType == "CompetitionCollectionView").First(); }
    }

    public IList<IGrouping<string, ModuleViewEntity>> ModuleGroups
    {
        get
        {
            return Modules.GroupBy(m => m.Group).OrderBy(m => m.Key).ToList();
        }
    }

    protected override void DocumentShown(ModuleViewEntity module, IDocument document)
    {
        base.DocumentShown(module, document);
    }
}