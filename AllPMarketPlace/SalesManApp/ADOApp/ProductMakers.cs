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
    
    public partial class ProductMakers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductMakers()
        {
            this.Products = new HashSet<Products>();
            this.UsersPM = new HashSet<UsersPM>();
        }
    
        public int id_ProductMakers { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TMe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products> Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersPM> UsersPM { get; set; }
    }
}
