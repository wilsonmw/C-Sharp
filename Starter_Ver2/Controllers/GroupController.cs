using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [HttpGet]
        [Route("groups")]
        public JsonResult everyGroup(){
            return Json(allGroups);
        }

        [HttpGet]
        [Route("groups/{name}")]
        public JsonResult oneGroup(string name){
            List<Group> oneofthem = allGroups.Where(group => group.GroupName == name).ToList();
            return Json(oneofthem);
        }

        [HttpGet]
        [Route("groups/id/{id}")]
        public JsonResult idGroup(int id){
            List<Group> groupById = allGroups.Where(group => group.Id == id).ToList();
            return Json(groupById);
        }

    }
}