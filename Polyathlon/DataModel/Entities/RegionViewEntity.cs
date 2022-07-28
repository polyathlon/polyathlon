using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Polyathlon.DataModel.Entities
{
    public class RegionViewEntity
    {
        [Display(AutoGenerateField = false)]
        readonly Region entity;

        [Display(AutoGenerateField = false)]
        public string Origin { get; set; }

        [Display(Name = "Наименование")]
        public string? Name 
        {
            get => entity.Name;
            set => entity.Name = value;
        }
        [Display(Name = "Сокращение")]
        public string? ShortName
        {
            get => entity.ShortName;
            set => entity.ShortName = value;
        }
        public RegionViewEntity()
        {

        }
        public RegionViewEntity(Region region)
        {
            entity = region;
        }
    }
}
