using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Lenzerheide.Api.Controllers
{
    [RoutePrefix("api/printpdf")]
    public class PrintPdfController : ApiController
    {
        // GET api/printpdf/get/1001
        [HttpGet()]
        [Route("get/{kundenId:int}")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult GetPdfByKundenId(int kundenId)
        {
            if (kundenId <= 0)
            {
                return NotFound();
            }

            try
            {

                var path = HttpContext.Current.Server.MapPath(string.Format(@"~/App_Data/dummy_pdf.pdf"));
                var pdf = new FileInfo(path);

                if (!pdf.Exists)
                {
                    return NotFound();
                }

                var response = Request.CreateResponse(HttpStatusCode.OK);

                response.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = string.Format(@"customer_letter_{0}.pdf", kundenId.ToString());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                return ResponseMessage(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
