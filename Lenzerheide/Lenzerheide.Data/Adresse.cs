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
    
    public partial class Adresse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adresse()
        {
            this.Hotel = new HashSet<Hotel>();
            this.Kunde = new HashSet<Kunde>();
        }
    
        public int Id { get; set; }
        public int OrtId { get; set; }
        public int LandId { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
    
        public virtual Land Land { get; set; }
        public virtual Ort Ort { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hotel> Hotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kunde> Kunde { get; set; }
    }
}
