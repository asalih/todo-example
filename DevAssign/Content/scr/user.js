(function ($) {
    var app = {};
    app.renderAll = function (cb) {
        $(".todos").empty().append("<p>Loading...</p>");
        $.ajax({
            url: '/user/todolist/',
            type: 'GET',
            async: 'true',
            success: function (result) {
                $(".todos").empty().append(result);
                if (cb)
                    cb();
            }
        });
    }

    app.openTaskModalForCreate = function () {
        $("#taskModal").modal("show");
        $("#activeToDo").val($(this).attr("data-id"));
        $(".saveTask").unbind().click(app.createTask);

    }

    app.openTaskModalForUpdate = function () {
        var parent = $(this).parents("[data-task]");
        $("#taskModal").modal("show");
        $("#activeTask").val(parent.attr("data-task"));
        $("#taskBody").val(parent.find(".taskBody").text());
        $(".saveTask").unbind().click(app.updateTask);
    }

    app.openReminderModel = function () {
        $("#reminderContent").empty().html("Loading...");
        $("#reminderModal").modal("show");
        var id = $(this).parents("[data-task]").attr("data-task");
        $("#activeTaskForReminder").val(id);

        $.ajax({
            url: '/user/reminder/' + id,
            type: 'GET',
            async: 'true',
            success: function (result) {
                $("#reminderContent").empty().html(result);
                $(".delete-reminder").off("click").on("click", app.deleteReminder);
            }
        });

    }

    app.createTask = function () {
        var $btn = $(this).bootstrapBtn('loading')
        $.ajax({
            url: '/user/task/' + $("#activeToDo").val(),
            type: 'POST',
            async: 'true',
            data: { taskBody: $("#taskBody").val() },
            success: function (result) {
                $("[data-selector='todo_" + $("#activeToDo").val() + "']>ul").prepend(result);
                $("#taskModal").modal("toggle");
                $btn.bootstrapBtn('reset');
                app.taskBind();
            }
        });
    }

    app.updateTask = function () {
        var $btn = $(this).bootstrapBtn('loading')
        $.ajax({
            url: '/user/task/' + $("#activeTask").val(),
            type: 'PUT',
            async: 'true',
            data: { taskBody: $("#taskBody").val() },
            success: function (result) {
                $("[data-task='" + $("#activeTask").val() + "']").replaceWith(result);
                $("#taskModal").modal("toggle");
                $btn.bootstrapBtn('reset');
                app.taskBind();
            },
        });
    }

    app.deleteTask = function () {
        if (!confirm("Are you sure?")) { return };
        let row = $(this).parents("[data-task]");
        let id = row.attr("data-task");
        $.ajax({
            url: '/user/task/' + id,
            type: 'DELETE',
            async: false,
            success: function (result) {
                row.remove();
            }
        });
    }

    app.saveToDo = function () {
        var id = $("#toDoId").val();
        $(".cancelToDo").hide();
        if (id !== "") {
            $.ajax({
                url: '/user/todo/' + id,
                type: 'PUT',
                data: { toDoName: $("#toDoName").val() },
                async: false,
                success: function (result) {
                    app.renderAll(app.loadCallBack);
                }
            });
        }
        else {
            $.ajax({
                url: '/user/todo/',
                type: 'POST',
                data: { toDoName: $("#toDoName").val() },
                async: false,
                success: function (result) {
                    app.renderAll(app.loadCallBack);
                }
            });
        }
    }

    app.deleteToDo = function () {
        if (!confirm("Are you sure?")) { return; }
        $.ajax({
            url: '/user/todo/' + $(this).attr("data-id"),
            type: 'DELETE',
            async: false,
            success: function (result) {
                app.renderAll(function () { app.todoBind(); app.taskBind(); });
            }
        });
    }

    app.createReminder = function () {
        var min = parseInt($("#minute").val()) * 60 * 1000;
        var hour = parseInt($("#hour").val()) * 60 * 60 * 1000;
        $.ajax({
            url: '/user/reminder/' + $("#activeTaskForReminder").val(),
            type: 'POST',
            async: false,
            data: {
                ticks: Date.parse($("#remindDate").val()) + min + hour,
            },
            success: function (result) {
                $("#reminderContent>ul").prepend(result);
            }
        });
    }

    app.deleteReminder = function () {
        var row = $(this).parents("li[data-reminder-id]");
        $.ajax({
            url: '/user/reminder/' + $(this).attr("data-reminder-id"),
            type: 'DELETE',
            async: false,
            success: function (result) {
                row.remove();
            }
        });
    }

    app.todoBind = function () {
        $('.add-task').off("click").on('click', app.openTaskModalForCreate);
        $("#saveToDo").off("click").on("click", app.saveToDo);
        $(".delete-toDo").off("click").on("click", app.deleteToDo);
        $(".edit-toDo").off("click").on("click", function () {
            var parent = $(this).parents(".todoitem").find("h4");
            $("#toDoName").val(parent.text());
            $("#toDoId").val($(this).attr("data-id"));
            $("#cancelToDo").show();
        });
        $("#cancelToDo").off("click").on("click", function () {
            $("#cancelToDo").hide();
            $("#toDoId,#toDoName").val("")
        });
    }

    app.taskBind = function () {
        $('.deleteTask').off("click").on('click', app.deleteTask);
        $('.editTask').off("click").on('click', app.openTaskModalForUpdate);
        $(".addReminder").off("click").on('click', app.openReminderModel);

        $('#taskModal').on('hidden.bs.modal', function () {
            app.clearInputs();
        });
    }

    app.clearInputs = function () {
        $("#activeTask,#activeToDo,#taskBody").val("")
    }

    app.loadCallBack = function () {
        app.todoBind();
        app.taskBind();


        $("#remindDate").datepicker({ minDate: 0, dateFormat: "mm/dd/yy" });
        $("#saveReminder").off("click").on("click", app.createReminder);
    }


    $(document).ready(function () {
        setTimeout(function () {
            app.renderAll(app.loadCallBack);
        }, 50);
    });
})($);