using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Xml;

namespace Day3.UnitTesting.UnitTests
{

    [TestClass]
    public class PaymentServiceTests
    {
        [TestMethod]
        public void PaymetService_When_Pay_Returns_Correct_Result()
        {
            //arrange
            var fromAccount = "0001";
            var toAccount = "0009";
            var amount = 100.0;
            var fileService = MockRepository.GenerateStub<IXmlFileService>();
            var expectedDateTime = new DateTime(2001,9,11);
            fileService.Stub(m => m.SaveFile(Arg<XmlDocument>.Is.Anything, Arg<string>.Is.Anything)).Return(expectedDateTime);
            
            var logger = MockRepository.GenerateMock<ILogger>();
            logger.Expect(m => m.Log()).Repeat.Times(1);
            var ps = new PaymentService(fileService, logger);

            //act
            var result = ps.Pay(fromAccount, toAccount, amount);

            //assert
            Assert.IsNotNull(result);
            var resultXml = result.Item1;
            var resultTime = result.Item2;
            var resultFromAccount = resultXml.SelectSingleNode("/payment/@from").InnerText;
            var resultToAccount = resultXml.SelectSingleNode("/payment/@to").InnerText;
            var resultAmount = double.Parse(resultXml.SelectSingleNode("/payment/@amount").InnerText);

            Assert.AreEqual(fromAccount, resultFromAccount);
            Assert.AreEqual(toAccount, resultToAccount);
            Assert.AreEqual(amount, resultAmount);

            Assert.AreEqual(expectedDateTime, resultTime);

            logger.AssertWasCalled(
              m=> m.Log(),
              options => options.Repeat.Times(1)
          );

        }
    }
}
