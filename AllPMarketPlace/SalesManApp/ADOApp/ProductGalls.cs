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
    
    public partial class ProductGalls
    {
        public int id_productGall { get; set; }
        public byte[] Photo { get; set; }
        public int Product_id { get; set; }
    
        public virtual Products Products { get; set; }
    }
}