using System.Collections.Generic;
using System.Web.Http.Results;
using Controllers.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Controllers.Tests
{
    [TestClass]
    public class ValuesControllerTests
    {
        [TestMethod]
        public void Test_Controller__Response_Is_Ok()
        {
            var controller = new ValuesController();
            var result = controller.Get();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<string>>));
        }

        [TestMethod]
        public void Test_Controller__Values_Are_Returned()
        {
            var controller = new ValuesController();
            var result = controller.Get();
            var contentResult = result as OkNegotiatedContentResult<List<string>>;
            Assert.IsTrue(contentResult.Content.Contains("Rahman"));
        }

        [TestMethod]
        public void Test_getting_a_string_for_an_id_smaller_than_10()
        {
             var controller = new ValuesController();
            var result = controller.Get(1);
            var contentResult = result as OkNegotiatedContentResult<string>;
            Assert.IsTrue(contentResult.Content == "Hosha");
        }

        [TestMethod]
        public void Test_getting_a_bad_request_for_an_id_greater_than_10()
        {
            var controller = new ValuesController();
            var result = controller.Get(11);
            var contentResult = result as BadRequestErrorMessageResult;
            Assert.IsInstanceOfType(contentResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void Test_getting_a_bad_request_and_message_for_an_id_greater_than_10()
        {
            var controller = new ValuesController();
            var result = controller.Get(11);
            var contentResult = result as BadRequestErrorMessageResult;     //NOTE: this is bad result with message
            Assert.AreEqual(contentResult.Message, "Id should be smaller than 10.");
        }

        [TestMethod]
        public void Test_getting_a_bad_request_for_empty_name()
        {
            var controller = new ValuesController();
            var result = controller.GetByName("");
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));  //NOTE: this only bad result!!
        }

    }
}
