using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonStr = File.ReadAllText(@"C:\MSCode\JSON.json");

            var listTemp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TenantIdStaffIdResultModel>>(jsonStr);

            StringBuilder forReturn = new StringBuilder();
            foreach(var item in listTemp)
            {
                int tenantIdTemp = item.TenantMsg.TenantId;

                foreach(var itemChild in item.StaffsMsg)
                {
                    forReturn.AppendLine($"{tenantIdTemp},{itemChild.StaffId},{itemChild.StaffName},{itemChild.StaffEmail}");
                }
            }

            var returnStr = forReturn.ToString();
        }
    }

    public class TenantIdStaffIdResultModel
    {
        public TenantInfo TenantMsg { get; set; }

        public List<StaffInfo> StaffsMsg { get; set; }
    }

    public class TenantInfo
    {
        public int TenantId { get; set; }
    }

    public class StaffInfo
    {
        public static readonly string StaffIdFieldName = "UserID";

        public static readonly string StaffNameFieldName = "Name";

        public static readonly string StaffEmailFieldName = "Email";

        public string StaffId { get; set; }

        public string StaffName { get; set; }

        public string StaffEmail { get; set; }
    }
}
