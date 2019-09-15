using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM
{
    public interface IORM
    {
        T GetDataModel<T>(CommandInfo commandInfo);

        List<T> GetDataModelList<T>(CommandInfo commandInfo);

        int Execute(CommandInfo commandInfo);
    }
}
