//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcFirmaCagrı.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblFirmalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblFirmalar()
        {
            this.Cagrilartbl = new HashSet<Cagrilartbl>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Sektor { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string Adres { get; set; }
        public string Sifre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cagrilartbl> Cagrilartbl { get; set; }
    }
}
