using System;
using System.Collections.Generic;

namespace studentwebAPI.DataDB
{
    public partial class TblstudentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Program { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
