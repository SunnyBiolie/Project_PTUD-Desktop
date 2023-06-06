//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_PTUD_Desktop.ModelEntity
{
    using Project_PTUD_Desktop.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class Phim : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            this.KeHoaches = new HashSet<KeHoach>();
            this.LichChieux = new HashSet<LichChieu>();
            this.TheLoais = new HashSet<TheLoai>();
        }

        private string _maPhim;
        private string _tenPhim;
        private string _maTheLoaiChinh;
        private int _thoiLuong;

        public string MaPhim { get => _maPhim; set { _maPhim = value; OnPropertyChanged(); } }
        public string TenPhim { get => _tenPhim; set { _tenPhim = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh { get => _maTheLoaiChinh; set { _maTheLoaiChinh = value; OnPropertyChanged(); } }
        public int ThoiLuong { get => _thoiLuong; set { _thoiLuong = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeHoach> KeHoaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieu> LichChieux { get; set; }
        public virtual TheLoai TheLoai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheLoai> TheLoais { get; set; }
    }
}
