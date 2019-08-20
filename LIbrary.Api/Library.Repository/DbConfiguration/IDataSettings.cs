using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infra.Repository.DbConfiguration
{
    public interface IDataSettings
    {
        string DefaultConnection { get; set; }
    }
}
