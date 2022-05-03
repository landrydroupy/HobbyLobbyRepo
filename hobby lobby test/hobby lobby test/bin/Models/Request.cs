//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hobby_lobby_test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        public int RequestNumber { get; set; }
        public int StoreNumber { get; set; }
        public Nullable<int> PickupNumber { get; set; }
        public int ToteQuantity { get; set; }
        public int CartonQuantity { get; set; }
        public int LoadLockQuantity { get; set; }
        public string Comments { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual Pickup Pickup { get; set; }
        public virtual Store Store { get; set; }
    }
}
