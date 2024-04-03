//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UchetZayav.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zayavka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zayavka()
        {
            this.Otchet = new HashSet<Otchet>();
        }
    
        public int ID { get; set; }
        public System.DateTime Data { get; set; }
        public int OborudID { get; set; }
        public int TypeNeispID { get; set; }
        public string OpisanieProblem { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> IspolnitelID { get; set; }
        public string Comment { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Ispolnitel Ispolnitel { get; set; }
        public virtual Neisp Neisp { get; set; }
        public virtual Oborud Oborud { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otchet> Otchet { get; set; }
        public virtual Status Status { get; set; }
    }
}
