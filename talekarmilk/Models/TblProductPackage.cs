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
    
    public partial class TblProductPackage
    {
        public int propk_id { get; set; }
        public Nullable<int> pro_id { get; set; }
        public string pack_type { get; set; }
        public string pack_prize { get; set; }
    
        public virtual TblProduct TblProduct { get; set; }
    }
}