//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HseDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class new_nodes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public new_nodes()
        {
            this.new_connection = new HashSet<new_connection>();
            this.new_connection1 = new HashSet<new_connection>();
        }
    
        public int nodeId { get; set; }
        public Nullable<int> coordX { get; set; }
        public Nullable<int> coordY { get; set; }
        public Nullable<int> mapIdFk { get; set; }
        public Nullable<int> IbeaconIdFk { get; set; }
        public Nullable<int> nodeNum { get; set; }
        public string type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<new_connection> new_connection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<new_connection> new_connection1 { get; set; }
        public virtual new_floors new_floors { get; set; }
        public virtual new_ibeacons new_ibeacons { get; set; }
    }
}
