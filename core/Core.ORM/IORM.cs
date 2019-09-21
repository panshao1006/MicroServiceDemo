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


        T GetDataModel<T>() where T : class;

        List<T> GetDataModelList<T>() where T : class;

        List<T> UpdateModels<T>() where T : class;

        T UpdateModel<T>();

        int Insert<T>(T t) where T : class;
    }
}
