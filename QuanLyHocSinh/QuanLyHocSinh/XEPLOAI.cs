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
    
    public partial class XEPLOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XEPLOAI()
        {
            this.DIEMs = new HashSet<DIEM>();
        }
    
        public string MaXepLoai { get; set; }
        public string TenXepLoai { get; set; }
        public Nullable<double> DiemToiThieu { get; set; }
        public Nullable<double> DiemToiDa { get; set; }
        public Nullable<double> DiemKhongChe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEM> DIEMs { get; set; }
    }
}