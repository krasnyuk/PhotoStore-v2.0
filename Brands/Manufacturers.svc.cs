using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Brands
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Manufacturers" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Manufacturers.svc или Manufacturers.svc.cs в обозревателе решений и начните отладку.
    public class Manufacturers : IManufacturers
    {
        public void DoWork()
        {
        }
        public DataSet ReturnBrands()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Brands");
            DataColumn dc1 = new DataColumn("BrandId", typeof(int));
            DataColumn dc2 = new DataColumn("Name", typeof(string));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            DataRow dr1 = dt.NewRow();
            dr1[0] = 10;
            dr1[1] = "Nikon";
            dt.Rows.Add(dr1);
            ds.Tables.Add(dt);

            return ds;
        }
    }
}
