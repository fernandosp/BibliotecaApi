using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infra.Repository.DbConfiguration
{
    public class DataSettings : IDataSettings
    {
        public string DefaultConnection { get; set; }
    }
}
