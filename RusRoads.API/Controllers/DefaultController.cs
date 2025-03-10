using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using RusRoads.API.DTO;
using RusRoads.API.Entities;
using RusRoads.API.Entity;
using RusRoads.API.Exceptions;
using RusRoads.API.Services;

namespace RusRoads.API.Controllers
{
    [ApiController]
    [Route("api/v1")]
    //[Authorize]
    public class DefaultController(RusRoadsContext db, TokenService tokenService) : Controller
    {
        [AllowAnonymous]
        [HttpPost("SignIn")]
        public ActionResult<ErrorModel> SignIn(UserDto userDto)
        {

            var user = db.User.Where(u => u.Name == userDto.Name && u.Password == userDto.Password).FirstOrDefault();
            if (user == null)
                return StatusCode(403, new ErrorModel
                {
                    TimeStamp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHHmmss")),
                    Message = "Неправильно введены данные",
                    ErrorCode = "3241"
                });


            var token = tokenService.CreateToken(userDto.Name);
            return Ok(token);
        }

        [HttpGet("Documents")]
        public ActionResult<ErrorModel> GetDocuments()
        {
            IEnumerable<Object> docs;
            try
            {
                docs = db.Document.Select(d => new
                {
                    id = d.Id,
                    title = d.Title,
                    DateCreated = d.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                    date_updated = d.DateUpdated.ToString("yyyy-MM-dd HH:mm:ss"),
                    category = d.Category,
                    has_comments = d.HasComments
                }).ToList();
            }
            catch (Exception ex)
            {
                var response = new ErrorModel { TimeStamp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHHmmss")), Message = ex.Message, ErrorCode = "3224" };
                return BadRequest(response);
            }
            return Ok(docs);
        }

        [HttpGet("Document/{document_id}/Comments")]
        public ActionResult<ErrorModel> GetComments(int document_id)
        {
            var document = db.Document.Include(d => d.Comments)!.ThenInclude(c => c.Author).Where(d => d.Id == document_id).FirstOrDefault();
            if (document == null)
            {
                var response = new ErrorModel { TimeStamp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHHmmss")), Message = "Нет документа", ErrorCode = "3226" };
                return NotFound(response);
            }
            var comments = document?.Comments!.Select(c => new{
                    id = c.Id,
                    document_id = document_id,
                    text = c.Text,
                    date_created = c.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                    date_updated = c.DateUpdated.ToString("yyyy-MM-dd HH:mm:ss"),
                    author = new {name = c.Author!.FIO, position = c.Author.Position}
                }).ToList();
            
            return Ok(comments);

        }

        [HttpPost("Document/{document_id}/Comment")]
    
        public ActionResult<ErrorModel> CreateComment(CommentDto commentDto)
        {
            var author = db.Employee.Where(e => e.FIO == commentDto.Author!.Name && e.Position == commentDto.Author.Position)
                .Select(e => new
                 {
                    id = e.Id,
                 }).FirstOrDefault();
            if(author == null)
                return BadRequest(new ErrorModel{
                    ErrorCode = "3422",
                    Message = "Пользователя не существует",
                    TimeStamp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHHmmss"))});
            var comment = new Comment 
            {
                DocumentId = commentDto.DocumentId,
                Text = commentDto.Text,
                AuthorId = author.id,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
            try
            {
                db.Comment.Add(comment);
                db.SaveChanges();

            }catch(Exception ex)
            {
                return BadRequest(new ErrorModel{
                    ErrorCode = "3421",
                    Message = ex.Message,
                    TimeStamp = Convert.ToInt32(DateTime.UtcNow.ToString("yyyyMMddHHmmss"))}
                    );
            }
            return Ok(comment);
        }
        [HttpGet ("workingCalendar")]
        public ActionResult<IEnumerable<workingCalendar>> getWorkingCalendar()
        {
            var calendar = db.workingCalendar.ToList();
            return Ok(calendar);
        }



    }
}