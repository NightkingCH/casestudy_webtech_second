//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lenzerheide.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bewertung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bewertung()
        {
            this.BewertungHotel = new HashSet<BewertungHotel>();
            this.BewertungZimmer = new HashSet<BewertungZimmer>();
        }
    
        public int Id { get; set; }
        public int KundeId { get; set; }
        public int BewertungsTyp { get; set; }
    
        public virtual Kunde Kunde { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BewertungHotel> BewertungHotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BewertungZimmer> BewertungZimmer { get; set; }
    }
}
