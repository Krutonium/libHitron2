using System.Collections.Generic;

namespace libHitron2
{
    public class Status_Deserializer
    {
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
        public class DocsisProvisiningInfo
        {
            public string errCode { get; set; }
            public string errMsg { get; set; }
            public string hwInit { get; set; }
            public string findDownstream { get; set; }
            public string ranging { get; set; }
            public string dhcp { get; set; }
            public string timeOfday { get; set; }
            public string downloadCfg { get; set; }
            public string registration { get; set; }
            public string eaeStatus { get; set; }
            public string bpiStatus { get; set; }
            public string networkAccess { get; set; }
            public string trafficStatus { get; set; }
        }
        public class DOCSIS_WAN_GENERAL
        {
            public string errCode { get; set; }
            public string errMsg { get; set; }
            public string ntAccess { get; set; }
            public List<string> ip { get; set; }
            public string subMask { get; set; }
            public string gw { get; set; }
            public string lease { get; set; }
            public string Configname { get; set; }
            public string DsDataRate { get; set; }
            public string UsDataRate { get; set; }
            public string macAddr { get; set; }
        }


    }
}