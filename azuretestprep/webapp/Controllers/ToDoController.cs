using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using webapp.Models;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace webapp.Controllers
{
    public class ToDoController : ApiController
    {
        public ToDoController()
        {
            Repository<ToDoItem>.Initialize();
        }
        // GET api/values
        [SwaggerOperation("GetAll")]
        public async Task<IEnumerable<ToDoItem>> Get()
        {
            return await Repository<ToDoItem>.GetItemsAsync();
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<ToDoItem> Get(int id)
        {
            return await Repository<ToDoItem>.GetItemAsync(id.ToString());
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task<Document> Post([FromBody]ToDoItem item)
        {
            return await Repository<ToDoItem>.CreateItemAsync(item);
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<Document> Put(int id, [FromBody]ToDoItem item)
        {
            return await Repository<ToDoItem>.UpdateItemAsync(id.ToString(), item);
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async void Delete(int id)
        {
            await Repository<ToDoItem>.Delete(id.ToString());
        }
    }
}
