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
    
    public partial class HOCSINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCSINH()
        {
            this.CTLOPs = new HashSet<CTLOP>();
            this.KETQUA_MONHOC_HOCSINH = new HashSet<KETQUA_MONHOC_HOCSINH>();
        }
    
        public string MaHocSinh { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string HoTenCha { get; set; }
        public Nullable<short> NamSinh_Cha { get; set; }
        public string CCCD_Cha { get; set; }
        public string SDT_Cha { get; set; }
        public string NgheNghiep_Cha { get; set; }
        public string HoTenMe { get; set; }
        public Nullable<short> NamSinh_Me { get; set; }
        public string CCCD_Me { get; set; }
        public string SDT_Me { get; set; }
        public string NgheNghiep_Me { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTLOP> CTLOPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA_MONHOC_HOCSINH> KETQUA_MONHOC_HOCSINH { get; set; }
    }
}
