//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesManApp.ADOApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appeal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appeal()
        {
            this.Answer = new HashSet<Answer>();
        }
    
        public int id_Appeal { get; set; }
        public string Text { get; set; }
        public int TypeAppeal_id { get; set; }
        public System.DateTime DataCreate { get; set; }
        public Nullable<System.DateTime> DateClose { get; set; }
        public int User_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual TypeAppeal TypeAppeal { get; set; }
        public virtual Users Users { get; set; }
    }
}
