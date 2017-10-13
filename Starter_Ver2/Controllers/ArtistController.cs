using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [Route("artists")]
        [HttpGet]
        public JsonResult AllOfEm(){
           return Json(allArtists);
        }

        [Route("artists/name/{name}")]
        [HttpGet]

        public JsonResult oneArtist(string name){
            List<Artist> thatArtist = allArtists.Where(artist => artist.ArtistName.Contains(name)).ToList();
            return Json(thatArtist);
        }

        [Route("artists/realname/{name}")]
        [HttpGet]
        public JsonResult realArtist(string name){
            List<Artist> realNameArtist = allArtists.Where(artist => artist.RealName.Contains(name)).ToList();
            return Json(realNameArtist);
        }

        [Route("artists/hometown/{town}")]
        [HttpGet]
        public JsonResult hometown(string town){
            List<Artist> hometowns = allArtists.Where(artist => artist.Hometown==town).ToList();
            return Json(hometowns);
        }
        
        [Route("artists/groupid/{id}")]
        [HttpGet]
        public JsonResult groupID(int id){
            List<Artist> groupinem = allArtists.Where(artist => artist.GroupId==id).ToList();
            return Json(groupinem);
        }

    }
}