using System;
using System.Collections.Generic;
using System.Text;

namespace AzurePipelineSample.NETStandard.Core
{
    public interface IModel
    {
        string Name { get; }

        string GetStatus();
    }
}
