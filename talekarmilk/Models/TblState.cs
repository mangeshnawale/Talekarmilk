//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace talekarmilk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblState
    {
        public TblState()
        {
            this.TblCities = new HashSet<TblCity>();
        }
    
        public int state_id { get; set; }
        public Nullable<int> country_id { get; set; }
        public string state_name { get; set; }
    
        public virtual TblCountry TblCountry { get; set; }
        public virtual ICollection<TblCity> TblCities { get; set; }
    }
}
