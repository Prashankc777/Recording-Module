//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecordingModule.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTask()
        {
            this.tbluser = new HashSet<tbluser>();
        }
    
        public int ID { get; set; }
        public string TaskName { get; set; }
        public Nullable<System.DateTime> DeletedTime { get; set; }
        public Nullable<int> IsEdited { get; set; }
        public Nullable<System.DateTime> EditedTime { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbluser> tbluser { get; set; }
    }
}
