//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace House23.Logic.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginHistory
    {
        public int IdLodinHistory { get; set; }
        public System.DateTime Date { get; set; }
        public int IdEmloyee { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
