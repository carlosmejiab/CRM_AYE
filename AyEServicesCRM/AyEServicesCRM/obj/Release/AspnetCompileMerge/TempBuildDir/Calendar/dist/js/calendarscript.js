var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;



function updateEvent(event, element) {
    //alert(event.description);

    if ($(this).data("qtip")) $(this).qtip("destroy");

    currentUpdateEvent = event;

    $('#updatedialog').dialog('open');

    $("#eventName").val(event.Name);
    $("#eventDesc").val(event.Descripcion);
    $("#eventId").val(event.IdEvent);
    $("#eventStart").text("" + event.StarDateTime.toLocaleString());

    if (event.DueDateTime === null) {
        $("#eventEnd").text("");
    }
    else {
        $("#eventEnd").text("" + event.DueDateTime.toLocaleString());
    }

}

function updateSuccess(updateResult) {
    //alert(updateResult);
}

function deleteSuccess(deleteResult) {
    //alert(deleteResult);
}

function addSuccess(addResult) {
    //alert("added key: "+ addResult);
    
    $('#calendar').fullCalendar('renderEvent',
						{
						    Name: $("#addEventName").val(),
						    StarDateTime: addStartDate,
						    DueDateTime: addEndDate,
						    IdEvent: addResult,
						    Descripcion: $("#addEventDesc").val(),
						    allDay: globalAllDay
						},
						true // make the event "stick"
					);
    
    
    $('#calendar').fullCalendar('unselect');
}

function UpdateTimeSuccess(updateResult) {
    //alert(updateResult);
}


function selectDate(StarDateTime, DueDateTime, allDay) {

    //alert("abre modal");
    ////$('#addDialog').dialog('open');
    
     
    $("#addEventStartDate").text("" + StarDateTime.toLocaleString());
    $("#addEventEndDate").text("" + DueDateTime.toLocaleString());
 
    
    addStartDate = StarDateTime;
    addEndDate = DueDateTime;
    globalAllDay = allDay;
    //alert(allDay);

}

function updateEventOnDropResize(event, allDay) {

    //alert("allday: " + allDay);
    var eventToUpdate = {
        IdEvent: event.IdEvent,
        StarDateTime: event.StarDateTime

    };
   
    if (allDay) {
        eventToUpdate.StarDateTime.setHours(0, 0, 0);
        
    }

    if (event.DueDateTime === null) {
        eventToUpdate.DueDateTime = eventToUpdate.StarDateTime;

    }
    else {
        eventToUpdate.DueDateTime = event.DueDateTime;
        if (allDay) {
            eventToUpdate.DueDateTime.setHours(0, 0, 0);
        }
    }

    eventToUpdate.StarDateTime = eventToUpdate.StarDateTime.format("dd-MM-yyyy hh:mm:ss tt");
    eventToUpdate.DueDateTime = eventToUpdate.DueDateTime.format("dd-MM-yyyy hh:mm:ss tt");

    PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);

}

function eventDropped(event,dayDelta,minuteDelta,allDay,revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event, allDay);



}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);

}


$(document).ready(function() {

    // update Dialog
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "update": function() {
                //alert(currentUpdateEvent.title);
                var eventToUpdate = {
                    IdEvent: currentUpdateEvent.IdEvent,
                    Name: $("#eventName").val(),
                    Descripcion: $("#eventDesc").val()
                };
                PageMethods.UpdateEvent(eventToUpdate, updateSuccess);
                $(this).dialog("close");

                currentUpdateEvent.Name = $("#eventName").val();
                currentUpdateEvent.Descripcion = $("#eventDesc").val();
                $('#calendar').fullCalendar('updateEvent', currentUpdateEvent);

            },
            "delete": function() {

                if (confirm("do you really want to delete this event?")) {

                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                }

            }

        }
    });

    //add dialog
    $('#addDialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "Add": function() {

            //alert("sent:" + addStartDate.format("dd-MM-yyyy hh:mm:ss tt") + "==" + addStartDate.toLocaleString());
                var eventToAdd = {
                    Name: $("#addEventName").val(),
                    Descripcion: $("#addEventDesc").val(),
                    StarDateTime: addStartDate.format("dd-MM-yyyy hh:mm:ss tt"),
                    DueDateTime: addEndDate.format("dd-MM-yyyy hh:mm:ss tt")
                };

                PageMethods.addEvent(eventToAdd, addSuccess);
                $(this).dialog("close");


            }

        }
    });


    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var calendar = $('#MainContent_calendar').fullCalendar({
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        eventClick: updateEvent,
        selectable: true,
        selectHelper: true,
        select: selectDate,
        editable: false,
        events: "JsonResponse.ashx",
        eventDrop: eventDropped,
        eventResize: eventResized,
        color: 'yellow',
        draggable: false,
        eventRender: function(event, element) {
            element.qtip({
                content: event.Descripcion,
                position: { corner: { tooltip: 'bottomLeft', target: 'topRight'} },
                style: {
                    border: {
                        width: 1,
                        radius: 3,
                        color: '#2779AA'

                    },
                    color: 'yellow',
                    padding: 10,
                    textAlign: 'center',
                    tip: true, // Give it a speech bubble tip with automatic corner detection
                    name: 'cream' // Style it according to the preset 'cream' style
                }

            });
        }

    });

});

