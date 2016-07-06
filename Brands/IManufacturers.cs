using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Brands
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IManufacturers" в коде и файле конфигурации.
    [ServiceContract]
    public interface IManufacturers
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        DataSet ReturnBrands();
    }
}
