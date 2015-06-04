using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tertigo.Service;
using Rhino.Mocks;
using System.Text;

namespace Tetrigo.Service.UnitTests
{
    [TestClass]
    public class StaticMethodExecutorTests
    {
        [TestMethod]
        public void StaticMethodExecutor_GetTypeAndMethod_ReturnsCorrectResult()
        {
            var sme = new StaticMethodExecutor();
            var url = "/System.Path.Join";
            
            //act
            var result = sme.GetTypeAndMethod(url);

            //assert
            Assert.AreEqual("System.Path", result.Item1);
            Assert.AreEqual("Join", result.Item2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StaticMethodExecutor_GetTypeAndMethod_ReturnsCorrectResult_IfGivenEmptyValue()
        {
            //arrange
            var sme = new StaticMethodExecutor();
            var url = "";

            //act
            var result = sme.GetTypeAndMethod(url);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StaticMethodExecutor_GetTypeAndMethod_ReturnsCorrectResult_IfGivenTypeButEmptyMethod()
        {
            //arrange
            var sme = new StaticMethodExecutor();
            var url = "System.Path.";

            //act
            var result = sme.GetTypeAndMethod(url);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StaticMethodExecutor_GetTypeAndMethod_ReturnsCorrectResult_IfNotGivenTypeButMethodNotEmpty()
        {
            //arrange
            var sme = new StaticMethodExecutor();
            var url = "..Exec";

            //act
            var result = sme.GetTypeAndMethod(url);
        }


        [TestMethod]
        public void StaticMethodExecutor_ExecuteStaticProperty_Returns_Correct_Result()
        {
            //arrange
            var sme = new StaticMethodExecutor();
            
            //act
            var result = sme.ExecuteStaticProperty("Now", "System.DateTime");

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(DateTime), result.GetType());
        }

        [TestMethod]
        public void StaticMethodExecutor_ReturnResult_ReturnsJsonString_ForJsonContentType()
        {
            //arrange
            var sme = new StaticMethodExecutor();
            var contextWriter = MockRepository.GenerateStub<IHttpContextWriter>();
            var sb = new StringBuilder();
            contextWriter.Stub(m => m.Write(Arg<object>.Is.Anything)).
                WhenCalled(args =>
                {
                    var obj = args.Arguments[0];
                    sb.Append(obj);
                });

            //act
            sme.ReturnResult(contextWriter, new { name="Visar", surname="Elmazi"  }, "application/json");

            //assert
            Assert.AreEqual("{\"name\":\"Visar\",\"surname\":\"Elmazi\"}", sb.ToString());
        }
    }
}
