//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BewareTask.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class archived_task
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public string TaskName { get; set; }
        public System.DateTime deadline { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    
        public virtual user user { get; set; }
    }
}
