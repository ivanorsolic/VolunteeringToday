//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeChange.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActionStats
    {
        public System.Guid ID { get; set; }
        public System.Guid IDAction { get; set; }
        public int ReplyCount { get; set; }
        public int RetweetCount { get; set; }
        public int FavoriteCount { get; set; }
        public string Location { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Actions Actions { get; set; }
    }
}
