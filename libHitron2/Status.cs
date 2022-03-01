using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;

namespace libHitron2
{
    public class Status
    {
        #region SystemInfo
        public SystemInformationInfo System_Information()
        {
            var client = Session.client;
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "/1/Device/Router/SysInfo?_=" + DateTimeOffset.Now.ToUnixTimeSeconds()))
            {
                var response = client.Send(request);
                var responseString = response.Content.ReadAsStringAsync().Result; 
                //Console.WriteLine(responseString);
                var Data = JsonConvert.DeserializeObject<SystemInformationInfo>(responseString);
                return Data;
            }
        }

        public class SystemInformationInfo
        {
            public string errCode { get; set; }
            public string errMsg { get; set; }
            public string deviceId { get; set; }
            public string modelName { get; set; }
            public string vendorName { get; set; }
            public string SerialNum { get; set; }
            public string HwVersion { get; set; }
            public string ApiVersion { get; set; }
            public string SoftwareVersion { get; set; }
            public string sysTime { get; set; }
            public string tz { get; set; }
            public string lanName { get; set; }
            public string privLanIP { get; set; }
            public string lanRx { get; set; }
            public string lanTx { get; set; }
            public string wanName { get; set; }
            public List<string> wanIP { get; set; }
            public string wanRx { get; set; }
            public string wanRxPkts { get; set; }
            public string wanTx { get; set; }
            public string wanTxPkts { get; set; }
            public List<string> dns { get; set; }
            public string rfMac { get; set; }
            public string secDNS { get; set; }
            public string systemLanUptime { get; set; }
            public string systemWanUptime { get; set; }
            public string routerMode { get; set; }
        }
        #endregion
        
    }
}