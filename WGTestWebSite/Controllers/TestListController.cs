using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WGSystem.Collections.Generic;

namespace WGTestWebSite.Controllers
{
    /// <summary>
    /// Controller for testing the generic collections API functions
    /// </summary>
    [Produces("application/json")]
    [Route("api/TestList")]
    public class TestListController : Controller
    {
        /// <summary>
        /// Contains the generic collections factory to be tested
        /// </summary>
        private WGGenericCollectionsFactory wGGenericCollectionsFactory;

        /// <summary>
        /// Allow the generic collection factory dependency to be injected
        /// </summary>
        /// <param name="collectionsFactory">Instance of a WGGenericCollectionsFactory</param>
        public TestListController(WGGenericCollectionsFactory collectionsFactory)
        {
            wGGenericCollectionsFactory = collectionsFactory;
        }

        /// <summary>
        /// Implement the HttpGet function of the controller
        /// </summary>
        /// <returns>An object that implements IEnumerable</returns>
        // GET: api/TestList
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IList<string> data = wGGenericCollectionsFactory.CreateList<string>();
            data.Add("Key");
            data.Add("Value");

            return (IEnumerable<string>)data;
        }

        // GET: api/TestList/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestList
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
