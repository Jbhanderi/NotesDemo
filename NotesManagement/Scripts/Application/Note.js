$(function () {

    GetNotePartialView(null);

    $(document).off("click", "#btnAddNewNote").on("click", "#btnAddNewNote", function () {
        GetNotePartialView(null);
    });

    $(document).off("click", "#btnSaveNote").on("click", "#btnSaveNote", function () {
        var form = $("form");
        if (form.valid()) {
            SaveNote();
        }
    });

    $(document).off("click", ".deleteNote").on("click", ".deleteNote", function (e) {


        var noteID = $(this).attr("data-id");

        bootbox.confirm({
            message: "Are you sure you want to delete this note?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    DeleteNote(noteID);
                }
            }
        });


    });

    $(document).off("click", ".lnkEditNote").on("click", ".lnkEditNote", function (e) {
        var noteID = $(this).attr("data-id");
        GetNotePartialView(noteID);
    });

});

function GetAllNotes() {

    var notePromise = $.ajax({
        url: urlHome_GetNotes,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html'
    });

    notePromise.done(function (data) {
        $("#divNotes").html(data);
    });

}

function GetNotePartialView(noteID) {
    var notePromise = $.ajax({
        url: urlHome_GetNotePartialView,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
        data: { noteID: noteID }
    });

    notePromise.done(function (data) {
        $("#divNote").html(data);
        $.validator.unobtrusive.parse("form");
    });
}

function SaveNote() {

    var data = $("form").serializeObject();

    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;

    var notePromise = $.ajax({
        url: urlHome_AddOrUpdateNote,
        contentType: 'application/json; charset=utf-8',
        headers: headers,
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(data)
    });

    notePromise.done(function (data) {
        if (data[0]) {
            GetNotePartialView(null);
            GetAllNotes();
        }
    });

}

function DeleteNote(noteID) {

    var notePromise = $.ajax({
        url: urlHome_DeleteNote,
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify({ noteID: noteID })
    });

    notePromise.done(function (data) {
        if (data[0]) {
            GetAllNotes();
        }
    });

}

