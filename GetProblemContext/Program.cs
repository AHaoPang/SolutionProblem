using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetProblemContext
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            HttpContent httpContent = new StringContent("Commands[0][Key]=PyhTaskCount&Commands[0][Params][0][Name]=tenantId&Commands[0][Params][0][Value]=110006&transactionType=Attendance_GeneralRestore&opsParmarter=&isDeleteOpsKey=false");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            httpContent.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
            httpContent.Headers.Add("Cookie", "Hm_lvt_664c9997d599843d849d3debbbe89584=1536629903; _ga=GA1.2.1190111386.1541656166; LoginId=pangyanhao; BSOps=0102B55B9295024BD608FEB5DBF68D9562D608000A700061006E006700790061006E00680061006F002C700061006E006700790061006E00680061006F002C009E5EC1966A8C2C00310039007C00360037007C00340036007C00340038007C002C006F00700073007C006F00700073007C006F00700073007C006F00700073007C00012F00FF");

            var listPageResponse = client.PostAsync("http://attendance.ops.beisencorp.com/Home/ExecCommands", httpContent);

            Console.WriteLine(listPageResponse.Result.Content.ReadAsStringAsync().Result);
        }
    }
}
