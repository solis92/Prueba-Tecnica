using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly DBContext _dbContext;
        public NewsController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{elements}")]
        public async Task<IActionResult> Get(int elements)
        {
            List<News> newsList = new List<News>();
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://hacker-news.firebaseio.com/v0/beststories.json");

                //validate that the Hacker API is working fine
                if (result.IsSuccessStatusCode)
                {
                    List<int> units = await result.Content.ReadFromJsonAsync<List<int>>();
                    var listid = units.Take(elements);

                    foreach (var item in listid)
                    {
                        //VALIDATE IF EXIST ON DATABASE
                        News newfromSQL = await _dbContext.News.FirstOrDefaultAsync(x => x.idnew == item);
                        if (newfromSQL == null)
                        {
                            using (var clientid = new HttpClient())
                            {
                                var resultid = await clientid.GetAsync($"https://hacker-news.firebaseio.com/v0/item/" + item + ".json");
                                var resultdetail = await resultid.Content.ReadFromJsonAsync<NewsDetail>();
                                News template = new News();
                                template.idnew = item;
                                template.title = resultdetail.title;
                                template.uri = resultdetail.url;
                                template.postedBy = resultdetail.by;
                                template.time = DateTimeOffset.FromUnixTimeSeconds(resultdetail.time).DateTime;
                                template.score = resultdetail.score;
                                template.commentCount = resultdetail.descendants;
                                newsList.Add(template);

                                //Insert into database so if this id is called after
                                // the api reduce the requests to external API
                                _dbContext.News.Add(template);
                                _dbContext.SaveChanges();
                            }
                        }
                        else
                        {
                            //SQL Mapped this code add the already saved new from the database to the list
                            newsList.Add(newfromSQL);
                        }
                    }
                    newsList.OrderByDescending(x => x.score); // this order the list in desc
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            return StatusCode(StatusCodes.Status200OK, new { value = newsList });
        }
    }
}
