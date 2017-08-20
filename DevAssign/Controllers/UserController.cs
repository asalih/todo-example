using DevAssign.Business;
using DevAssign.Data.Model;
using DevAssign.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevAssign.Controllers
{
    [UserAuthFilter]
    [RoutePrefix("user")]
    public class UserController : BaseController
    {
        [Route("~/user")]
        public ActionResult UserMain()
        {
            return View();
        }

        [Route("signout")]
        public ActionResult Signout()
        {
            Session.Remove(Consts.SESSION_USER_KEY);
            return RedirectToAction("Index", "Common");
        }

        #region ToDo
        [Route("todolist")]
        public ActionResult ToDoList()
        {
            var toDoRepo = UnitOfWork.GetRepository<ToDo>();

            int userId = SessionUser.Id;
            var list = toDoRepo.GetAll(todo => todo.UserId == userId, "Tasks").ToList();
            return PartialView(list);
        }

        [HttpGet, Route("todo/{id:int}")]
        public ActionResult ToDo(int id)
        {
            var toDoRepo = UnitOfWork.GetRepository<ToDo>();
            var todo = toDoRepo.GetById(id);
            return PartialView("ToDoItem", todo);
        }
        [HttpPost, Route("todo")]
        public ActionResult CreateToDo(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { erro = true }, JsonRequestBehavior.AllowGet);
            }
            toDo.UserId = SessionUser.Id;
            toDo.CreateDate = DateTime.Now;

            var toDoRepo = UnitOfWork.GetRepository<ToDo>();
            var todo = toDoRepo.Add(toDo);
            base.UnitOfWork.SaveChanges();

            return PartialView("ToDoItem", todo);
        }
        [HttpPut, Route("todo/{id:int}")]
        public ActionResult UpdateToDo(int id, string toDoName)
        {
            var toDoRepo = UnitOfWork.GetRepository<ToDo>();
            var toDoToUpdate = toDoRepo.GetById(id);
            toDoToUpdate.ToDoName = toDoName;

            toDoRepo.Update(toDoToUpdate);
            base.UnitOfWork.SaveChanges();

            return PartialView("ToDoItem", toDoToUpdate);
        }

        [HttpDelete, Route("todo/{id:int}")]
        public ActionResult DeleteToDo(int id)
        {
            var toDoRepo = UnitOfWork.GetRepository<ToDo>();
            var entity = toDoRepo.GetById(id);
            toDoRepo.Delete(entity);
            UnitOfWork.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Task
        [HttpGet, Route("task/{id:int}")]
        public ActionResult Task(int id, string taskBody)
        {
            var taskRepo = base.UnitOfWork.GetRepository<Task>();
            var entityToUpdate = taskRepo.GetById(id);

            return PartialView("Task", entityToUpdate);
        }

        [HttpPost, Route("task/{todoid:int}")]
        public ActionResult CreateTask(int todoid, string taskBody)
        {
            var taskRepo = base.UnitOfWork.GetRepository<Task>();
            var task = taskRepo.Add(new Data.Model.Task() { ToDoId = todoid, TaskBody = taskBody, CreateDate = DateTime.Now });

            base.UnitOfWork.SaveChanges();

            return PartialView("Task", task);
        }

        [HttpPut, Route("task/{id:int}")]
        public ActionResult UpdateTask(int id, string taskBody)
        {
            var taskRepo = base.UnitOfWork.GetRepository<Task>();
            var entityToUpdate = taskRepo.GetById(id);
            entityToUpdate.TaskBody = taskBody;

            taskRepo.Update(entityToUpdate);
            base.UnitOfWork.SaveChanges();

            return PartialView("Task", entityToUpdate);
        }

        [HttpDelete, Route("task/{id:int}")]
        public ActionResult DeleteTask(int id, string taskBody)
        {
            var taskRepo = base.UnitOfWork.GetRepository<Task>();
            var entity = taskRepo.GetById(id);
            taskRepo.Delete(entity);
            UnitOfWork.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Reminder
        [HttpGet, Route("reminder/{taskId:int}")]
        public ActionResult Reminders(int taskId)
        {
            var reminderRepository = base.UnitOfWork.GetRepository<Reminder>();
            var list = reminderRepository.GetAll(rem => rem.TaskId == taskId);

            return PartialView(list);
        }

        [HttpPost, Route("reminder/{taskId:int}")]
        public ActionResult CreateReminder(int taskId, long ticks)
        {
            DateTime remindDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(ticks).ToLocalTime();

            if (remindDate < DateTime.Now)
            {
                return new EmptyResult();
            }

            var reminderRepo = UnitOfWork.GetRepository<Reminder>();
            var result = reminderRepo.Add(new Data.Model.Reminder()
            {
                TaskId = taskId,
                CreateDate = DateTime.Now,
                When = remindDate
            });

            UnitOfWork.SaveChanges();

            return PartialView("ReminderItem", result);
        }

        [HttpDelete, Route("reminder/{id:int}")]
        public ActionResult DeleteReminder(int id)
        {
            var reminderRepo = UnitOfWork.GetRepository<Reminder>();
            var entity = reminderRepo.GetById(id);
            reminderRepo.Delete(entity);
            UnitOfWork.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}