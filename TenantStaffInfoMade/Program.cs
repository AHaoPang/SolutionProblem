using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantStaffInfoMade
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesTemp = File.ReadAllLines(@"C:\MSCode\txt.txt");

            var forReturn = new List<TenantStaffIdModel>();
            foreach(var item in linesTemp)
            {
                var arrTemp = item.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                if (arrTemp.Length != 2) continue;

                forReturn.Add(new TenantStaffIdModel()
                {
                    TenantId = arrTemp[0],
                    StaffId = arrTemp[1]
                });
            }

            var forReturnModel = forReturn.ToLookup(i => i.TenantId, j => j);

            var forReturnJson = forReturnModel.Select(i => new { TenantId = i.Key, StaffIds = i.Select(j => j.StaffId).Distinct().ToList() }).ToList();

            var strReturn = Newtonsoft.Json.JsonConvert.SerializeObject(forReturnJson);
        }

        class TenantStaffIdModel
        {
            public string TenantId { get; set; }

            public string StaffId { get; set; }
        }
    }
}
