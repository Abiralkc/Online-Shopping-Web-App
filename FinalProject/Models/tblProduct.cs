//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        public int ProductId { get; set; }
        public Nullable<int> CatagoryId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Units { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public string Photo { get; set; }
        public Nullable<bool> IsSpecial { get; set; }
    
        public virtual tblCatagory tblCatagory { get; set; }
    }
}
