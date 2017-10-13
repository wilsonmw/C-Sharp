using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Models;

namespace wall.Controllers
{
    public class WallController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("wall")]
        public IActionResult Wall(){
            int? id = HttpContext.Session.GetInt32("userId");           
            List<Dictionary<string,object>> currentUser = _dbConnector.Query($"SELECT * FROM users WHERE(idusers = '{id}')");
            ViewBag.name = currentUser[0]["FirstName"];
            ViewBag.userId = currentUser[0]["idusers"];
            List<Dictionary<string,object>> allMessages = _dbConnector.Query($"SELECT Content, FirstName, LastName, messages.CreatedAt, users_idusers, idmessages FROM messages JOIN users ON users.idusers = messages.users_idusers ORDER BY messages.CreatedAt DESC");
            ViewBag.allMessages = allMessages;
            List<Dictionary<string,object>> allComments = _dbConnector.Query("SELECT commentContent, FirstName, LastName, comments.CreatedAt, comments.users_idusers, idcomments, messages_idmessages FROM comments JOIN messages ON messages.idmessages = comments.messages_idmessages JOIN users ON users.idusers = comments.users_idusers ORDER BY comments.CreatedAt");
            ViewBag.allComments = allComments;
            return View("wall");
        }

        [HttpPost]
        [Route("postMessage")]
        public IActionResult postMessage(Message newMessage){
            if(ModelState.IsValid){
                int? userId = HttpContext.Session.GetInt32("userId");
                _dbConnector.Execute($"INSERT INTO messages(content, users_idusers) VALUES('{newMessage.Content}','{userId}')");
                return RedirectToAction("Wall");
            }
            else{
                ViewBag.messageError = "Message must be between 5 and 1000 characters.";
                return View("wall");
            }
        }
        
        [HttpPost]
        [Route("delete")]
        public  IActionResult Delete(int id){
            System.Console.WriteLine(id);
            _dbConnector.Execute($"DELETE FROM comments WHERE messages_idmessages={id}");
            _dbConnector.Execute($"DELETE FROM messages WHERE idmessages={id}");
            
            return RedirectToAction("Wall");
        }
        [HttpPost]
        [Route("postComment")]
        public IActionResult postComment(Comment newComment, int id){
            if(ModelState.IsValid){
                int? userId = HttpContext.Session.GetInt32("userId");
                _dbConnector.Execute($"INSERT INTO comments(commentContent, users_idusers, messages_idmessages) VALUES('{newComment.commentContent}','{userId}','{id}')");
                return RedirectToAction("Wall");
            }
            else{
                ViewBag.messageError = "Message must be between 5 and 1000 characters.";
                return View("wall");
            }
        }

        [HttpPost]
        [Route("deleteComment")]
        public  IActionResult DeleteComment(int id){
            _dbConnector.Execute($"DELETE FROM comments WHERE idcomments={id}");
            return RedirectToAction("Wall");
        }

    }

}