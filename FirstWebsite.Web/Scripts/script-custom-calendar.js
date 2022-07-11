$(document).ready(function () {
    $('#customcalendar').fullCalendar({
        header:
        {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonText: {
            today: 'today',
            month: 'Month',
            week: 'Week',
            day: 'Day'
        },
        events: function (start, end, timezone, callback) {
            $.ajax({
                url: '/Home/GetCalendarData',
                type: "GET",
                dataType: "JSON",

                success: function (result) {
                    var events = [];

                    $.each(result, function (i, data) {
                        if (data.personalDisplay || data.Type == 3)
                        {
                            var type = data.Type;
                            var bgc = "#ffffff";
                            var bdc = "#999999";
                            if (type == 1) {
                                bgc = "#2eb82e";
                            }
                            else if (type == 2) {
                                bgc = "#33adff";
                            }
                            else {
                                bgc = "#ff6666";
                            }
                            events.push(
                                {
                                    title: data.Title,
                                    start: moment(data.Start_Date).format('YYYY-MM-DD'),
                                    end: moment(data.End_Date).format('YYYY-MM-DD'),
                                    backgroundColor: bgc,
                                    borderColor: bdc
                                });
                        }
                    });

                    callback(events);
                }
            });
            $('#calendar').fullCalendar('option', { contentHeight: 600 });
        },

        eventRender: function (event, element) {
            element.qtip(
                {
                    content: event.description
                });
        },

        editable: false
    });
}); 