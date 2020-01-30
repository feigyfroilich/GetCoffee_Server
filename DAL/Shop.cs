//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop()
        {
            this.Orders = new HashSet<Order>();
            this.Users = new HashSet<User>();
            this.Shop_sProduct = new HashSet<Shop_sProduct>();
        }
    
        public long code { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string loginCode { get; set; }
        public bool shipment { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> rank { get; set; }
        public Nullable<long> numOfCustomer { get; set; }
        public Nullable<long> accountNumber { get; set; }
        public Nullable<double> lat { get; set; }
        public Nullable<double> @long { get; set; }
        public Nullable<long> categoryCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop_sProduct> Shop_sProduct { get; set; }
    }
}
