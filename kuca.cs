//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication111.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class kuca
    {
        public int ID_kuca { get; set; }
        public Nullable<bool> zemljiste { get; set; }
        public Nullable<int> kvadratura { get; set; }
        public Nullable<bool> bazen { get; set; }
        public string adresa { get; set; }
        public int ID_agencija { get; set; }
    
        public virtual agencija agencija { get; set; }
    }
}
