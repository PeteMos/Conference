//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conference.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class General
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public General()
        {
            this.Activity = new HashSet<Activity>();
            this.Activity1 = new HashSet<Activity>();
            this.Activity2 = new HashSet<Activity>();
            this.Activity3 = new HashSet<Activity>();
            this.Activity4 = new HashSet<Activity>();
            this.Activity5 = new HashSet<Activity>();
            this.Activity6 = new HashSet<Activity>();
        }
    
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> IdDirection { get; set; }
        public Nullable<int> IdEvent { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity6 { get; set; }
        public virtual Country Country { get; set; }
        public virtual Direction Direction { get; set; }
        public virtual Event Event { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
