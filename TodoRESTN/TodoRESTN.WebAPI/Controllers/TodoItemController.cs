using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoRESTN.WebAPI.Data;
using TodoRESTN.WebAPI.Models;

namespace TodoRESTN.WebAPI.Controllers
{
    public enum ErrorCode
    {
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        ITodoRepository _todoList;

        public TodoItemController(ITodoRepository todoList)
        {
            _todoList = todoList;
        }
        [HttpGet]
        public IActionResult List()
        {
           return Ok(_todoList.GetAll);
        }
        [HttpPost]
        public IActionResult Create([FromBody]TodoItem item)
        {

            try
            {
                if(item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _todoList.DoesItemExist(item.ID);
                if(existingItem)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _todoList.Insert(item);
            }
            catch (Exception)
            {

                return BadRequest(ErrorCode.CouldNotCreateItem);
            }


            return Ok(item);
        }
        [HttpPut]
        public IActionResult Edit([FromBody]TodoItem item)
        {
            try
            {
                if(item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _todoList.Find(item.ID);
                if(existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _todoList.Update(item);
            }
            catch (Exception)
            {

                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var todoItem = _todoList.Find(id);
                if(todoItem==null)
                {
                    return BadRequest(ErrorCode.RecordNotFound.ToString());
                }
                _todoList.Delete(id);
            }
            catch (Exception)
            {

                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }


            return NoContent();
        }
    }
}