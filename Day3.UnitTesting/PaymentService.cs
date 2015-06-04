using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day3.UnitTesting
{
    public class PaymentService
    {

        IXmlFileService _fileService = null;
        ILogger _logger;

        public PaymentService(IXmlFileService fileService, ILogger logger)
        {
            _fileService = fileService;
            _logger = logger;
        }

        public Tuple<XmlDocument,DateTime> Pay(string fromAccount, string toAccount, double amount)
        {
            var xml = new XmlDocument();
            var id = Guid.NewGuid();
            var xmlText = "<payment from='{0}' to='{1}' amount='{2}' id='{3}' />";
            xmlText = string.Format(xmlText, fromAccount, toAccount, amount, id);
            xml.LoadXml(xmlText);

            var filename = string.Format("c:\\paymentservice\\{0}.xml", id);
            var fileTime = _fileService.SaveFile(xml, filename);

            _logger.Log(id, filename);

            _logger.Log();

            return new Tuple<XmlDocument,DateTime>(xml,fileTime);
        }




    }
}
