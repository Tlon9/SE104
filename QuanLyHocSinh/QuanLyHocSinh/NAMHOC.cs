//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyHocSinh
{
    using System;
    using System.Collections.Generic;
    
    public partial class NAMHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NAMHOC()
        {
            this.KETQUA_MONHOC_HOCSINH = new HashSet<KETQUA_MONHOC_HOCSINH>();
            this.LOPs = new HashSet<LOP>();
        }
    
        public string MaNamHoc { get; set; }
        public string NamHoc1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA_MONHOC_HOCSINH> KETQUA_MONHOC_HOCSINH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOPs { get; set; }
    }
}
