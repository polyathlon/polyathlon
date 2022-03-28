using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Data.Filtering;


namespace Polyathlon.ViewModels {
    public interface IFilterModelPageSpecificSettings {
        FilterInfoList StaticFilters { get; set; }
        FilterInfoList CustomFilters { get; set; }
        ApplicationSettingsBase Settings { get; }
        void SaveSettings();
    }
    
    public class FilterInfo {
        public string Name { get; set; }
        public string FilterCriteria { get; set; }
        public string ImageUri { get; set; }        
    }
    public class FilterInfoList : List<FilterInfo> {
        public FilterInfoList() { }
        public FilterInfoList(IEnumerable<FilterInfo> filters)
            : base(filters) {
        }
    }
    
    public class FilterModelPageSpecificSettings<TSettings> : IFilterModelPageSpecificSettings where TSettings : ApplicationSettingsBase {
        static FilterModelPageSpecificSettings() {
            //var enums = typeof(EmployeeStatus).Assembly.GetTypes().Where(t => t.IsEnum);
            //foreach(Type e in enums) EnumProcessingHelper.RegisterEnum(e);
        }
        readonly TSettings settings;
        readonly PropertyDescriptor staticFiltersProperty;
        readonly PropertyDescriptor customFiltersProperty;
        public FilterModelPageSpecificSettings(TSettings settings, Expression<Func<TSettings, FilterInfoList>> getStaticFiltersExpression, Expression<Func<TSettings, FilterInfoList>> getCustomFiltersExpression)
        {
            this.settings = settings;
            this.staticFiltersProperty = GetProperty(getStaticFiltersExpression);
            this.customFiltersProperty = GetProperty(getCustomFiltersExpression);
        }
        FilterInfoList IFilterModelPageSpecificSettings.StaticFilters {
            get { return GetFilters(staticFiltersProperty); }
            set { SetFilters(staticFiltersProperty, value); }
        }


        FilterInfoList IFilterModelPageSpecificSettings.CustomFilters
        {
            get { return GetFilters(customFiltersProperty); }
            set { SetFilters(customFiltersProperty, value); }
        }
        ApplicationSettingsBase IFilterModelPageSpecificSettings.Settings {
            get { return settings; }
        }
        PropertyDescriptor GetProperty(Expression<Func<TSettings, FilterInfoList>> expression) {
            return (expression != null) ? TypeDescriptor.GetProperties(settings)[GetPropertyName(expression)] : null;
        }
        FilterInfoList GetFilters(PropertyDescriptor property) {
            return (property != null) ? (FilterInfoList)property.GetValue(settings) : null;
        }
        void SetFilters(PropertyDescriptor property, FilterInfoList value) {
            if(property != null) property.SetValue(settings, value);
        }
        static string GetPropertyName(Expression<Func<TSettings, FilterInfoList>> expression) {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if(memberExpression == null)
                throw new ArgumentException("expression");
            return memberExpression.Member.Name;
        }

        public void SaveSettings() {
            settings.Save();
        }
    }
}
