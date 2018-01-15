using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int Fibonacci(int n)
    {
        if (n < 1 || n > 100)
            return -1;

        int a = 0, b = 1, tmp = 0;

        for (int i = 0; i < n; i++)
        {
            tmp = a;
            a = b;
            b = tmp + a;
        }

        System.Threading.Thread.Sleep(2000);
        return a;
    }

    [WebMethod]
    public string XmlToJson(string xml)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return JsonConvert.SerializeXmlNode(doc);
        }
        catch (System.Xml.XmlException e)
        {
            return "Bad Xml format";
        }
    }


}