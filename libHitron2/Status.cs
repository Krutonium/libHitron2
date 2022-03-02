using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;

namespace libHitron2
{
    public class Status
    {
        public Status_Deserializer.SystemInformationInfo System_Information()
        {
            var client = Session.client;
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), 
                       "/1/Device/Router/SysInfo?_=" + DateTimeOffset.Now.ToUnixTimeSeconds()))
            {
                var response = client.Send(request);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Status_Deserializer.SystemInformationInfo>(responseString);
                return Data;
            }
        }

        public Status_Deserializer.DocsisProvisiningInfo Docsis_Provisioning()
        {
            var client = Session.client;
            using (var request = new HttpRequestMessage(new HttpMethod("GET"),
                       "/1/Device/CM/DocsisProvision?_=" + DateTimeOffset.Now.ToUnixTimeSeconds()))
            {
                var response = client.Send(request);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Status_Deserializer.DocsisProvisiningInfo>(responseString);
                return Data;
            }
        }

        public Status_Deserializer.DOCSIS_WAN_GENERAL Docsis_WAN_General()
        {
            var client = Session.client;
            using(var request = new HttpRequestMessage(new HttpMethod("GET"),
                       "/1/Device/CM/SysInfo?_=" + DateTimeOffset.Now.ToUnixTimeSeconds()))
            {
                var response = client.Send(request);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Status_Deserializer.DOCSIS_WAN_GENERAL>(responseString);
                return Data;
            }
        }
        //http://192.168.0.1/1/Device/CM/DsInfo?_=1646173858074 <= Downstream Channel Info
        //http://192.168.0.1/1/Device/CM/UsInfo?_=1646173858080 <= Upstream Channel Info
        //http://192.168.0.1/1/Device/CM/DsOfdm?_=1646173858082 <= OFDM Downstream
        //http://192.168.0.1/1/Device/CM/UsOfdm?_=1646173858086 <= OFDM General

    }
}