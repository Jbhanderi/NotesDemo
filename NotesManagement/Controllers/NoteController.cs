using NotesManagement.Data.Models;
using NotesManagement.Filters;
using NotesManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesManagement.Controllers
{
    [NotesManagementAuthAttribute]
    public class NoteController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Note()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNotePartialView(int? noteID)
        {
            Note note = null;

            if (noteID.HasValue)
            {
                note = _unitOfWork.NoteService.GetByID(noteID.Value);
            }
            else
            {
                note = new Note();
                note.UserID = loginUserIdentity.User.UserID;
            }
            return PartialView("_Note", note);
        }

        [HttpGet]
        public ActionResult GetNotes()
        {
            List<Note> lstNotes = _unitOfWork.NoteService.GetUserNotes(loginUserIdentity.User.UserID).ToList();
            return PartialView("_Notes", lstNotes);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult AddOrUpdateNote(Note note)
        {
            if (note.NoteID > 0)
            {
                _unitOfWork.NoteService.Update(note);
            }
            else
            {
                _unitOfWork.NoteService.Insert(note);
            }
            _unitOfWork.Commit();
            return Json(new object[] { true, "Note Saved Successfully." });
        }

        [HttpPost]
        public ActionResult DeleteNote(int noteID)
        {
            try
            {
                _unitOfWork.NoteService.Delete(noteID);
                _unitOfWork.Commit();
                return Json(new object[] { true, "Note Deleted Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new object[] { false, ex.Message });
            }
        }

    }
}