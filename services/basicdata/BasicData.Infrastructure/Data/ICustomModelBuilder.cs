using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Builder(ModelBuilder modelBuilder);
    }
}
