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
    
    public partial class TheLoai : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheLoai()
        {
            this.Phims = new HashSet<Phim>();
            this.Phims1 = new HashSet<Phim>();
        }

        private string _maTheLoai;
        private string _tenTheLoai;
        private ICollection<Phim> _phims;
        private ICollection<Phim> _phims1;

        public string MaTheLoai { get => _maTheLoai; set { _maTheLoai = value; ; OnPropertyChanged(); } }
        public string TenTheLoai { get => _tenTheLoai; set { _tenTheLoai = value; ; OnPropertyChanged(); } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phim> Phims { get => _phims; set { _phims = value; ; OnPropertyChanged(); } }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phim> Phims1 { get => _phims1; set { _phims1 = value; ; OnPropertyChanged(); } }
    }
}
