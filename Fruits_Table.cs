//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lemon_Task.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fruits_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fruits_Table()
        {
            this.Fruits_Table1 = new HashSet<Fruits_Table>();
        }
    
        public int Fruit_id { get; set; }
        public string Fruit_Name { get; set; }
        public Nullable<int> Veg_id { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fruits_Table> Fruits_Table1 { get; set; }
        public virtual Fruits_Table Fruits_Table2 { get; set; }
    }
}
