using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace HWmodule5
{
    class Program
    {
        private static Model1 db = new Model1();
        static void Main(string[] args)
        {

            /*Вывести на экран следующую информацию: Гаражный номер машины, 
            наименование модели машины, серийный номер машины, наименование производителя. */

            //var query = db.newEquipment.Select(s => new
            //{
            //    s.strSerialNo,
            //    s.strManufYear,
            //    s.TablesManufacturer.strName,

            //}).ToList();

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.strName + "\t" + item.strManufYear + "\t " + item.strSerialNo);
            //}

            //DirectDownload();
            //YavnayaDownload();
            OtlozDownload();
        }

        static void DirectDownload()
        {
            var query = db.newEquipment.Include(w => w.TablesModel).Select(s => new
            {
                s.strSerialNo,
                s.strManufYear,
                s.TablesManufacturer.strName,
            });

            foreach (var item in query)
            {
                Console.WriteLine(item.strName + "\t" + item.strManufYear + "\t " + item.strSerialNo);
            }
        }

        static void YavnayaDownload()
        {
            var query = db.TablesManufacturer.FirstOrDefault(w => w.intManufacturerID == 2);

            db.Entry(query).Collection(col => col.newEq).Load();
            foreach (newEquipment item in query.newEq)
            {
                Console.WriteLine(item.strSerialNo + "\t");
            }
        }

        static void OtlozDownload()
        {
            foreach (var item in db.newEquipment)
            {
                Console.WriteLine(item.strSerialNo + "\t" + item.strManufYear + "\t" + item.TablesManufacturer.strName);
            }



        }

    }
}
