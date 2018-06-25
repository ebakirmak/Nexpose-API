using Newtonsoft.Json;
using Nexpose;
using Nexpose_API.Model.Scan;
using Nexpose_API.Model.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.Controller
{
    public class ScanController
    {
        public ScanController()
        {

        }

        /// <summary>
        /// Bu fonksiyon Taramaları döndürür.
        /// This function  returns the scans.
        /// </summary>
        /// <param name="manager">Nexpose Instance</param>
        /// <returns></returns>
        public ScanModel GetScan(NexposeManager manager)
        {
            try
            {
                string json = manager.GetScans();
                var scans = JsonConvert.DeserializeObject<ScanModel>(json);

                return scans;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Bu fonksiyon yeni bir Tarama oluşturur.
        /// This function  creates a new Scan.
        /// </summary>
        /// <param name="manager">NexposeManager Instance</param>
        /// <param name="json">String in valid JSON type</param>
        /// <returns></returns>
        public ScanCreateResponse CreateScan(NexposeManager manager, string id, ScanCreate scanCreate)
        {
            try
            {
                string json = JsonConvert.SerializeObject(scanCreate);
        
                string jsonResponse = manager.CreateScan(id, json);
                ScanCreateResponse scanCreateResponse = new ScanCreateResponse();
                scanCreateResponse = JsonConvert.DeserializeObject<ScanCreateResponse>(jsonResponse);
                return scanCreateResponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public TemplateModel GetScanTemplates(NexposeManager manager)
        {
            try
            {
                string jsonResponse = manager.GetScanTemplates();
                TemplateModel model = JsonConvert.DeserializeObject<TemplateModel>(jsonResponse);
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ScanController::GetScanTEmplates \n\tException: " + ex.Message);
                return null;
                //throw;
            }
        }
        /// <summary>
        /// Bu fonksiyon yeni bir Site (Varlık) oluşturur.
        /// This function creates a new Site.
        /// </summary>
        /// <param name="manager">NexposeManager instance</param>
        /// <param name="site">SiteCreateModel object</param>
        /// <returns></returns>
        public string CreateSite(NexposeManager manager,SiteCreateModel site)
        {
            try
            {
                string json = JsonConvert.SerializeObject(site);
                string responseJson = manager.CreateSite(json);
                SiteCreateResponse siteCreateResponse = JsonConvert.DeserializeObject<SiteCreateResponse>(responseJson);
                return siteCreateResponse.Id;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ScanController::CreateSite \nException: " + ex.Message);
                return null;
            }
        }


        public SitesModel GetSites (NexposeManager manager)
        {
            try
            {
                string jsonResponse =  manager.GetSites();
                SitesModel sitesModel = new SitesModel();
                sitesModel = JsonConvert.DeserializeObject<SitesModel>(jsonResponse);
                return sitesModel;


            }
            catch (Exception ex)
            {
                Console.WriteLine("ScanController::GetSites \nException: " + ex.Message);
                return null;
            }
          
        }





    }
}
