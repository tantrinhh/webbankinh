//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webbankinh.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string slug { get; set; }
        public Nullable<bool> showonhomepage { get; set; }
        public Nullable<int> displayoder { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.DateTime> createonutc { get; set; }
        public Nullable<System.DateTime> updateonrutc { get; set; }
    }
}