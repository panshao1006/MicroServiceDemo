using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Common.Pipeline
{
    public interface IPipelineBuilder
    {
        IServiceProvider ApplicationServices { get; }
        PipelineBuilder Use(Func<CustomRequestDelegate, CustomRequestDelegate> middleware);
        CustomRequestDelegate Build();
        IPipelineBuilder New();
    }
}
