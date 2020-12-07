using ServiceReferenceTest.XAVServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceReferenceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
                | System.Net.SecurityProtocolType.Ssl3
                | System.Net.SecurityProtocolType.Tls
                | System.Net.SecurityProtocolType.Tls11;
            try
            {
                XAVService xavSvc = new XAVService();
                XAVRequest xavRequest = new XAVRequest();
                UPSSecurity upss = new UPSSecurity();
                UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
                upssSvcAccessToken.AccessLicenseNumber = "";
                upss.ServiceAccessToken = upssSvcAccessToken;
                UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
                upssUsrNameToken.Username = "";
                upssUsrNameToken.Password = "";
                upss.UsernameToken = upssUsrNameToken;
                xavSvc.UPSSecurityValue = upss;
                RequestType request = new RequestType();

                //Below code contains dummy data for reference. Please update as required.
                String[] requestOption = { "1" };
                request.RequestOption = requestOption;
                xavRequest.Request = request;
                xavRequest.MaximumCandidateListSize = "10";
                AddressKeyFormatType addressKeyFormat = new AddressKeyFormatType();
                String[] addressLine = { "3930 KRISTI COURT" };
                //addressKeyFormat.ItemsElementName = new ItemsChoiceType[] { ItemsChoiceType.PoliticalDivision1,ItemsChoiceType.PoliticalDivision2,ItemsChoiceType.PostcodePrimaryLow };
                String[] addressKeyFormatItems = { "CA", "Cumming", "95827" };
                //addressKeyFormat.Items = addressKeyFormatItems;
                addressKeyFormat.AddressLine = addressLine;
                addressKeyFormat.Urbanization = "SACRAMENTO CA 95827";
                addressKeyFormat.ConsigneeName = "Some Consignee";
                addressKeyFormat.CountryCode = "US";
                addressKeyFormat.PoliticalDivision1 = "CA";
                addressKeyFormat.PoliticalDivision2 = "Cumming";
                addressKeyFormat.PostcodePrimaryLow = "95827";
                Console.WriteLine($"Original Extended Post:{addressKeyFormat.PostcodeExtendedLow}");
                xavRequest.AddressKeyFormat = addressKeyFormat;
                //System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                Console.WriteLine(jss.Serialize(xavRequest));
                XAVResponse xavResponse = xavSvc.ProcessXAV(xavRequest);
                Console.WriteLine("Response Status Code " + xavResponse.Response.ResponseStatus.Code);
                Console.WriteLine("Response Status Description " + xavResponse.Response.ResponseStatus.Description);
                Console.WriteLine(xavResponse.Candidate[0].AddressKeyFormat.PostcodeExtendedLow);
                Console.WriteLine(xavResponse.Candidate[0].AddressKeyFormat.PostcodePrimaryLow);
                Console.ReadLine();
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("---------XAV Web Service returns error----------------");
                Console.WriteLine("---------\"Hard\" is user error \"Transient\" is system error----------------");
                Console.WriteLine("SoapException Message= " + ex.Message);
                Console.WriteLine("");
                Console.WriteLine("SoapException Category:Code:Message= " + ex.Detail.LastChild.InnerText);
                Console.WriteLine("");
                Console.WriteLine("SoapException XML String for all= " + ex.Detail.LastChild.OuterXml);
                Console.WriteLine("");
                Console.WriteLine("SoapException StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------");
                Console.WriteLine("CommunicationException= " + ex.Message);
                Console.WriteLine("CommunicationException-StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");
                Console.WriteLine("");

            }
            catch (Exception ex)
            {
                Console.WriteLine("G EX");
                Console.WriteLine("-------------------------");
                Console.WriteLine(" Generaal Exception= " + ex.Message);
                Console.WriteLine(" Generaal Exception-StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");

            }
            finally
            {
                Console.ReadKey();
            }

            //NXAVServices.XAVPortTypeClient xvp = new NXAVServices.XAVPortTypeClient();
            //NXAVServices.UPSSecurity upssecu = new NXAVServices.UPSSecurity();
            //upssecu.ServiceAccessToken = new NXAVServices.UPSSecurityServiceAccessToken() { AccessLicenseNumber = "******" };
            //upssecu.UsernameToken = new NXAVServices.UPSSecurityUsernameToken() { Username = "******", Password = "******" };

            //NXAVServices.XAVRequest nRequest = new NXAVServices.XAVRequest();
            //NXAVServices.RequestType rt = new NXAVServices.RequestType();
            //String[] requestOption1 = { "1" };
            //rt.RequestOption = requestOption1;
            //nRequest.Request = rt;

            //NXAVServices.AddressKeyFormatType addressKeyFormat1 = new NXAVServices.AddressKeyFormatType();
            //String[] addressLine1 = { "3930 KRISTI COURT" };
            ////addressKeyFormat.ItemsElementName = new ItemsChoiceType[] { ItemsChoiceType.PoliticalDivision1,ItemsChoiceType.PoliticalDivision2,ItemsChoiceType.PostcodePrimaryLow };
            ////String[] addressKeyFormatItems = { "CA", "Cumming", "95827" };
            ////addressKeyFormat.Items = addressKeyFormatItems;
            //addressKeyFormat1.AddressLine = addressLine1;
            //addressKeyFormat1.Urbanization = "SACRAMENTO CA 95827";
            //addressKeyFormat1.ConsigneeName = "Some Consignee";
            //addressKeyFormat1.CountryCode = "US";
            //nRequest.AddressKeyFormat = addressKeyFormat1;
            //xvp.ProcessXAV(upssecu, nRequest);
        }
    }
}
