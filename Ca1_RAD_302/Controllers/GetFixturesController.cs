using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ca1_RAD_302.Models;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Ca1_RAD_302.Controllers
{
    public class GetFixturesController : ApiController
    {
        private Ca1_RAD_302Context db = new Ca1_RAD_302Context();

        

    //static async task runasync()
    //    {
    //        using (var client = new httpclient())
    //        {
    //            client.baseaddress = new uri("https://api.pinnaclesports.com/v1/fixtures?sportid=29");
    //            client.defaultrequestheaders.accept.clear();
    //            client.defaultrequestheaders.accept.add(new mediatypewithqualityheadervalue("application/json"));
    //            string credentials = string.format("{0}:{1}", "gg862057", "@1sideside");
    //            byte[] bytes = encoding.utf8.getbytes(credentials);
    //            string base64 = convert.tobase64string(bytes);
    //            string authorization = string.concat("basic ", base64);

    //            httpresponsemessage response = await client.getasync("api/getfixtures");
    //            var gizmo = new getfixtures() { sportid = 29, islive = false };
    //            response = await client.postasjsonasync("api/getfixtures", gizmo);
    //            if (response.issuccessstatuscode)
    //            {
    //                uri gizmourl = response.headers.location;
                    
    //            }
                
    //        }
    //    }




        //[System.Web.Http.HttpGet]
        //public async Task<FixturesResponse> getdata()
        //{
        //    var request = (HttpWebRequest)WebRequest.Create("https://api.pinnaclesports.com/v1/fixtures?sportid=29");
        //    string credentials = String.Format("{0}:{1}", "yourclientid", "yourpassword");
        //    byte[] bytes = Encoding.UTF8.GetBytes(credentials);
        //    string base64 = Convert.ToBase64String(bytes);
        //    string authorization = String.Concat("Basic ", base64);
        //    request.Headers.Add("Authorization", authorization);
        //    request.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)");
        //    request.Method = "POST";
        //    request.Accept = "application/json";
        //    request.ContentType = "application/json; charset=utf-8";

        //    string postJson = "{\"SportId\":\"29\"}";


        //    byte[] byteArray = Encoding.UTF8.GetBytes(postJson);
        //    Stream dataStream = request.GetRequestStream();
        //    dataStream.Write(byteArray, 0, byteArray.Length);
        //    dataStream.Close();

        //    HttpWebResponse response;
        //    try
        //    {
        //        response = (HttpWebResponse)request.GetResponse();
        //    }
        //    catch (WebException ex)
        //    {
        //        response = (HttpWebResponse)ex.Response;
        //    }

        //    var stream = response.GetResponseStream();
        //    string responseBody;
        //    using (var reader = new StreamReader(stream))
        //    {
        //        responseBody = reader.ReadToEnd();
        //    }

        //    FixturesResponse Data;
        //    Data = JsonConvert.DeserializeObject<FixturesResponse>(responseBody);

        //    return Data;
        //}





        // GET: api/GetFixtures
        public IQueryable<GetFixtures> GetGetFixtures()
        {
            return db.GetFixtures;
        }

        // GET: api/GetFixtures/5
        [ResponseType(typeof(GetFixtures))]
        public async Task<IHttpActionResult> GetGetFixtures(int id)
        {
            GetFixtures getFixtures = await db.GetFixtures.FindAsync(id);
            if (getFixtures == null)
            {
                return NotFound();
            }

            return Ok(getFixtures);
        }

        // PUT: api/GetFixtures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGetFixtures(int id, GetFixtures getFixtures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != getFixtures.Id)
            {
                return BadRequest();
            }

            db.Entry(getFixtures).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetFixturesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GetFixtures
        [ResponseType(typeof(GetFixtures))]
        public async Task<IHttpActionResult> PostGetFixtures(GetFixtures getFixtures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GetFixtures.Add(getFixtures);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = getFixtures.Id }, getFixtures);
        }

        // DELETE: api/GetFixtures/5
        [ResponseType(typeof(GetFixtures))]
        public async Task<IHttpActionResult> DeleteGetFixtures(int id)
        {
            GetFixtures getFixtures = await db.GetFixtures.FindAsync(id);
            if (getFixtures == null)
            {
                return NotFound();
            }

            db.GetFixtures.Remove(getFixtures);
            await db.SaveChangesAsync();

            return Ok(getFixtures);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GetFixturesExists(int id)
        {
            return db.GetFixtures.Count(e => e.Id == id) > 0;
        }
    }
}