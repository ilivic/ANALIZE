//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnalystApp.ADOApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ordsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordsers()
        {
            this.OrdersProduct = new HashSet<OrdersProduct>();
        }
    
        public int Id_Order { get; set; }
        public int User_id { get; set; }
        public System.DateTime DateStart { get; set; }
        public Nullable<System.DateTime> DateClose { get; set; }
        public int StatusOrder_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersProduct> OrdersProduct { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
        public virtual Users Users { get; set; }
    }
}
