using System;
using System.Linq;
using System.Data;

using System.Linq.Expressions;
using System.Collections.Generic;
//using DevExpress.DevAV.Common.Utils;
//using DevExpress.DevAV.Common.DataModel;
//using DevExpress.DevAV.Common.DataModel.EntityFramework;
using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;
using Polyathlon.DataModel;

namespace Polyathlon.DbDataModel
{
    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource
    {

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation.
        /// </summary>
        public static IUnitOfWorkFactory<IDbUnitOfWork> GetUnitOfWorkFactory()
        {
            return new DbUnitOfWorkFactory<IDbUnitOfWork>(null);
            //return new DbUnitOfWorkFactory<IDbUnitOfWork>(() => new DbUnitOfWork(() => new Db()));
        }
    }
}
