//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCIProject.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_SUBMISSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_SUBMISSION()
        {
            this.TBL_SUBMISSIONDETAILS = new HashSet<TBL_SUBMISSIONDETAILS>();
        }
    
        public int Submission_ID { get; set; }
        public Nullable<int> ID_Student { get; set; }
        public Nullable<int> ID_File { get; set; }
        public string Linkedlin_URL { get; set; }
        public string Short_Desc { get; set; }
        public string Long_Desc { get; set; }
        public string tech { get; set; }
        public string Projekt_Title { get; set; }
    
        public virtual TBL_FILE TBL_FILE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SUBMISSIONDETAILS> TBL_SUBMISSIONDETAILS { get; set; }
    }
}
