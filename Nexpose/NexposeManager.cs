using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose
{
    public class NexposeManager:IDisposable
    {
        private NexposeSession Session { get; set; }

        public NexposeManager(NexposeSession session)
        {
            if (session != null)
            {
                this.Session = session;
            }
        }

 
        /// <summary>
        /// Bu fonksiyon devam eden Taramayı döndürür.
        /// This function return continued Scan.
        /// </summary>
        /// <returns></returns>
        public string GetScans()
        {
            return Session.ExecuteCommand("scans","GET",null);

        }


        /// <summary>
        /// Bu fonksiyon yeni bir tarama oluşturur.
        ///  This function creates a new Scan.
        /// </summary>
        /// <param name="json">String in valid JSON type</param>
        /// <returns></returns>
        public string CreateScan(string id,string json)
        {
            return Session.ExecuteCommand("/sites/"+id+"/scans", "POST", json);
        }

        /// <summary>
        /// Bu fonksiyon tarama templateni (policy) döndürür.
        /// This function return scan template.
        /// </summary>
        /// <returns></returns>
        public string GetScanTemplates()
        {
            return Session.ExecuteCommand("scan_templates","GET",null);
        }
   
        /// <summary>
        /// Bu fonksiyon taramayı siler.
        /// This function deletes the Scans
        /// </summary>
        /// <param name="id">Scan ID</param>
        /// <returns></returns>
        public string DeleteScan(string id)
        {
            return Session.ExecuteCommand("/scans/" + id, "DELETE", null);
        } 


        /// <summary>
        /// Bu fonksiyon  tarama durumunu getirir. 
        /// This function gets the Scan Status.
        /// </summary>
        /// <param name="id">Scan ID</param>
        /// <returns></returns>
        public string GetScanStatus(string id)
        {
            return Session.ExecuteCommand("/scans/" + id + "/status","GET",null);
        }

   
        /// <summary>
        /// Bu fonksiyon taramayı durdurur.
        /// This function stops the Scan.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string StopScan(string id)
        {
            return Session.ExecuteCommand("/scans/" + id + "/stop", "GET", null);
        }

        /// <summary>
        /// Bu fonksiyon taramayı duraklatır.
        /// This function pauses the Scan.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string PauseScan(string id)
        {
            return Session.ExecuteCommand("/scans/" + id + "/pause", "GET", null);
        }

        /// <summary>
        /// Bu fonksiyon taramada bulunan zafiyetleri döndürür.
        /// This function returns fouund Vulnerabilities in Scan
        /// </summary>
        /// <param name="id">Scan ID</param>
        /// <returns></returns>
        public string GetScanVulnerabilities(string id)
        {
            return Session.ExecuteCommand("/scans/" + id + "/kb/","GET",null);
        }

        /// <summary>
        /// Bu fonksiyon  bulunan zafiyetin detaylarını döndürür.
        /// This function returns found vulnerability details.
        /// </summary>
        /// <param name="scanId">Scan ID</param>
        /// <param name="vulnId">Vulnerability ID</param>
        /// <returns></returns>
        public string GetScanVulnerabilityDetails(string scanId,string vulnId)
        {
            return Session.ExecuteCommand("/scans/" + scanId + "/kb/"+vulnId, "GET", null);
        }

        /// <summary>
        /// Bu fonksiyon yeni bir Site (Varlık) oluşturur.
        /// This function creates a new Site.
        /// </summary>
        /// <param name="json">string json</param>
        /// <returns></returns>
        public string CreateSite(string json)
        {
            return Session.ExecuteCommand("/sites/", "POST", json);
        }
        
        /// <summary>
        /// Bu fonksiyon mevcut Siteleri (Varlıkları) döndürür.
        /// This function returns existing Sites.
        /// </summary>
        /// <returns></returns>
        public string GetSites()
        {
            return Session.ExecuteCommand("/sites/", "GET", null);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
