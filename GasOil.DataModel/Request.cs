//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GasOil.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        public long Id { get; set; }
        public string PersonName { get; set; }
        public string PersonPhone { get; set; }
        public string PersonEmail { get; set; }
        public string Message { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CategoryId { get; set; }
    }
}
