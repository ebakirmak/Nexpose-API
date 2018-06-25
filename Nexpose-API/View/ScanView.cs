using Newtonsoft.Json;
using Nexpose;
using Nexpose_API.Controller;
using Nexpose_API.Model.Scan;
using Nexpose_API.Model.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexpose_API.View
{
    public class ScanView
    {
        private static ScanController ScanController = new ScanController();


        //Server IP
        public static string IP { get; set; }
        //Server Port
        public static int Port { get; set; }
        //Username
        public static string Username { get; set; }
        //Password
        public static string Password { get; set; }
        

        /// <summary>
        /// Bu fonksiyon ip ve port numaralarını ayarlar.
        /// This function sets up ip and port number.
        /// </summary>
        public static void SetIPAndPort()
        {
            do
            {
                try
                {

                    Console.Write("IP Adresi ve Port Adresini değiştirmek istiyor musunuz?(E/H)");
                    string selected = Console.ReadLine().ToUpper();
                    if (selected == "E")
                    {
                        Console.Write("IP Adresini Giriniz: ");
                        IP = Console.ReadLine();

                        Console.Write("Port Numarasını Giriniz: ");
                        Port = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Username Giriniz: ");
                        Username = Console.ReadLine();

                        Console.Write("Parola Giriniz: ");
                        Password = Console.ReadLine();
                        break;
                    }
                    else if (selected == "H")
                    {
                        IP = "ip address";
                        Port = 3780;
                        Username = "uname";
                        Password = "pass";
                        break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input format biçimi hatalı. Kontrol ediniz." + e.Message);
                    //throw;
                }
            } while (true);


        }

        /// <summary>
        ///  Bu fonksiyon Taramaları ekrana yazar.
        ///  This function writes the Scans to screen.
        /// </summary>
        /// <param name="manager">W3afManager Object</param>
        public static void GetScans(NexposeManager manager)
        {
            try
            {
                ScanController = new ScanController();
                ScanModel scans = ScanController.GetScan(manager);
                if (scans.Resources.Length > 0)
                {
                    int counter = 1;
                    foreach (var item in scans.Resources)
                    {
                        Console.WriteLine(counter + ") ID: " +item.ID + "  " + "Tarama Adı: " + item.ScanName);
                        counter += 1;
                    }

                    int selected = ScanView.SelectScan();
                    ScanInformations(selected-1,scans);

                }
                else
                {
                    Console.WriteLine("Herhangi bir tarama mevcut değildir.");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("ScanView::GetScans Error Message:" + ex.Message);
            }

        }

        /// <summary>
        /// Bu Fonksiyon  işlem yapmak istediğimiz taramayı seçmemize yarar.
        /// This function is used to select the scan we want to process.
        /// </summary>
        /// <returns></returns>
        private static int SelectScan()
        {
            do
            {
                try
                {
                    Console.Write("Hangi Taramayı (Tarama No) Görüntülemek İstiyorsunuz?:");
                    int select = Convert.ToInt32(Console.ReadLine());
                    return select;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Sadece Tam Sayı Giriniz.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ScanView::SelectScan Exception " + ex.Message);

                }
            } while (true);
           
        
        }

        /// <summary>
        /// Bu fonksiyon ilgili tarama ile ilgili bilgileri ekrana yazar.
        /// This function writes to screen related Scan informations.
        /// </summary>
        /// <param name="id">Scan ID</param>
        /// <param name="scan">ScanModel Object</param>
        private static void ScanInformations(int id,ScanModel scan)
        {
            try
            {
                if (id <= scan.Resources.Length)
                    Console.WriteLine("\nStart Time: " + scan.Resources[id].StartTime
                                 + "\nEnd Time: " + scan.Resources[id].EndTime
                                 + "\nStatus: " + scan.Resources[id].Status
                                 + "\nVulnerabilities"
                                 + "\n\tCriticial: " + scan.Resources[id].Vulnerabilities.Critical.ToString()
                                 + "\n\tModerate: " + scan.Resources[id].Vulnerabilities.Moderate.ToString()
                                 + "\n\tSevere: " + scan.Resources[id].Vulnerabilities.Severe.ToString());
                else
                    Console.WriteLine("Lütfen Geçerli bir değer giriniz.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("ScanView::ScanInformations Exception: " + ex.Message);
               
            }
            
        }

        /// <summary>
        ///  Bu fonksiyon yeni bir Tarama oluşturur ve oluşturulan ID'yi ekrana yazar.
        ///  This function creates a new Scan and created ID writes to the screen.
        /// </summary>
        /// <param name="manager"></param>
        public static void CreateScan(NexposeManager manager)
        {
            ScanController = new ScanController();
            try
            {
                string selected = "";
                do
                {
                    Console.Write("Yeni  Varlık Oluşturmak İstiyor musunuz? (E/H)");
                    selected = Console.ReadLine();
                    string responseId = "";
                    if (selected.ToUpper() == "E")
                    {
                        //Profile Name is scan settings namely it is policy. Profile Adı tarama ayarlarıdır yani policydir.
                        Console.WriteLine("Varlık Adı Giriniz.");
                        string siteName = Console.ReadLine();
                        string scanProfileName = ListAndSelectTemplate(manager);
                        string targetURL = SelectTargetURL();
                        SiteCreateModel siteCreate = new SiteCreateModel(siteName, targetURL, scanProfileName);
                        responseId = ScanController.CreateSite(manager, siteCreate);
                    }
                    else if (selected.ToUpper() == "H")
                    {
                        //Varlıkları Listele
                        SitesModel sitesModel = ScanController.GetSites(manager);
                        int counter = 1;
                        if (sitesModel.Resources.Length == 0)
                        {
                            Console.WriteLine("Herhangi bir varlık bulunmamaktadır. Öncelikle yeni bir varlık oluşturunuz.");
                            break;
                        }

                        foreach (var item in sitesModel.Resources)
                        {
                            Console.WriteLine(counter + ") " +item.Name);
                            counter += 1;
                        }
                        Console.WriteLine("Site Numarasını giriniz: ");
                        int id = Convert.ToInt32(Console.ReadLine());


                        ScanCreate scanCreate = new ScanCreate(null, sitesModel.Resources[id-1].ScanTemplate);

                        ScanCreateResponse scanCreateResponse = ScanController.CreateScan(manager, id.ToString(), scanCreate);
                        if(scanCreateResponse.Id > 0)
                        {
                            Console.WriteLine("Tarama Oluşturuldu. Tarama ID: " + scanCreateResponse.Id);
                            break;
                        }
                    }
                    else
                        Console.WriteLine("Geçersiz Seçim");

                } while (selected != "E" & selected != "H");
             
               
               
                
                //ScanCreate scanCreate = new ScanCreate(scanProfileName, targetURL);
                //string json = JsonConvert.SerializeObject(scanCreate);



                //if (responseJson == null)
                //{
                //    Console.WriteLine("Sistemde herhangi bir tarama mevcut ise öncelikle onu siliniz.");
                //    return;
                //}

                //ScanCreateResponse scanCreateResponse = JsonConvert.DeserializeObject<ScanCreateResponse>(responseJson);
                //Console.WriteLine("Oluşturulan Tarama ID: " + scanCreateResponse.ID);
            }
            catch (Exception ex)
            {

                Console.WriteLine("ScanView::CreateScan Exception: " + ex.Message);
            }

        }

        /// <summary>
        /// Bu fonksiyon tarama template'lerini (policy) listeler.
        /// This function lists scan templates (policy).
        /// </summary>
        /// <returns></returns>
        private static string ListAndSelectTemplate(NexposeManager manager)
        {
            TemplateModel model = ScanController.GetScanTemplates(manager);


            int counter = 1;
            Console.Write("\n");
            foreach (var item in model.Resources)
            {
                Console.WriteLine(counter + ") " + item.Name.ToString());
                counter += 1;
            }

            Console.Write("\n Policy Seçiniz: ");
            int policyId = Convert.ToInt32(Console.ReadLine());
            return model.Resources[policyId - 1].ID;
        }

        /// <summary>
        /// Bu fonksiyon taranacak hedefi seçer.
        /// This function selects scan target.
        /// </summary>
        /// <returns></returns>
        private static string SelectTargetURL()
        {
            Console.Write("Taramak istediğiniz hedef:");
            
            return Console.ReadLine().ToLower();
        }

        public static void GetSite()
        {

        }

    }
}
