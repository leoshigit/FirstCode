using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TestEditViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
