//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using GraphQL;
//using GraphQL.Instrumentation;
//using GraphQL.NewtonsoftJson;
//using GraphQL.Types;
//using GraphQL.Validation.Complexity;
//using GraphQLWebAPI.Queries;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http.Extensions;

//namespace GraphQLWebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GraphQLController : ControllerBase
//    {
//        private readonly ISchema _schema;
//        private readonly IDocumentExecuter _executer;
//        private readonly IDocumentWriter _writer;

//        public GraphQLController(
//            IDocumentExecuter executer,
//            IDocumentWriter writer,
//            ISchema schema)
//        {
//            _executer = executer;
//            _writer = writer;
//            _schema = schema;
//        }

//        // This will display an example error
//        [HttpGet]
//        public Task GetAsync(HttpContext context)
//        {
//            return PostAsync(context, new GraphQLQuery { Query = "query foo { hero { id name appearsIn } }", Variables = null });
//        }

//        [HttpPost]
//        public async Task PostAsync(HttpContext context, GraphQLQuery query)
//        {
//            var inputs = query.Variables.ToInputs();
//            var queryToExecute = query.Query;

//            var result = await _executer.ExecuteAsync(_ =>
//            {
//                _.Schema = _schema;
//                _.Query = queryToExecute;
//                _.OperationName = query.OperationName;
//                _.Inputs = inputs;

//                _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
//                _.EnableMetrics = true;

//            }).ConfigureAwait(false);


//           await WriteResponseAsync(context, result);
//        }

//        private async Task WriteResponseAsync(HttpContext context, ExecutionResult result)
//        {
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = result.Errors?.Any() == true ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.OK;

//            await _writer.WriteAsync(context.Response.Body, result);
//        }
//    }
//}