//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int cartId { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<double> totalCost { get; set; }
        public Nullable<int> Oid { get; set; }
        public Nullable<int> Pid { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}