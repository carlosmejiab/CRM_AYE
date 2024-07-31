<%@ WebHandler Language="C#" Class="JsonResponse" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;

public class JsonResponse : IHttpHandler, IRequiresSessionState
{


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        DateTime start = new DateTime(1970, 1, 1);
        DateTime end = new DateTime(1970, 1, 1);
        UsersEntity users= new UsersEntity() ;
        //users.IdEmployee
        start = start.AddSeconds(double.Parse(context.Request.QueryString["start"]));
        end = end.AddSeconds(double.Parse(context.Request.QueryString["end"]));

        String result = String.Empty;

        result += "[";

        List<int> idList = new List<int>();
        foreach (EventEntity cevent in EventBS.getEvents(start, end,users))
        {
            result += convertCalendarEventIntoString(cevent);
            idList.Add(cevent.IdEvent);
        }

        if (result.EndsWith(","))
        {
            result = result.Substring(0, result.Length - 1);
        }

        result += "]";
        //store list of event ids in Session, so that it can be accessed in web methods
        context.Session["idList"] = idList;

        context.Response.Write(result);
    }

    private String convertCalendarEventIntoString(EventEntity cevent)
    {
        String allDay = "true";
        if(ConvertToTimestamp(cevent.StarDateTime).ToString().Equals(ConvertToTimestamp(cevent.DueDateTime).ToString()))
        {

            if (cevent.StarDateTime.Hour == 0 && cevent.StarDateTime.Minute == 0 && cevent.DueDateTime.Second == 0)
            {
                allDay = "true";
            }
            else
            {
                allDay = "false";
            }
        }
        else{
            allDay = "false";
        }
        return    "{" +
                  "id: '" + cevent.IdEvent + "'," +
                  "title: '" + cevent.Name + "'," +
                  "start:  " + ConvertToTimestamp(cevent.StarDateTime).ToString() + "," +
                  "end: " + ConvertToTimestamp(cevent.DueDateTime).ToString() + "," +
                  "allDay:" + allDay + "," +
                  "description: '" + cevent.Descripcion + "'" +","+
                  "color: 'yellow'" +
                  "},";
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private long ConvertToTimestamp(DateTime value)
    {
        //create Timespan by subtracting the value provided from
        //the Unix Epoch
        //TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

        //return the total seconds (which is a UNIX timestamp)
        //return (double)span.TotalSeconds;

        long epoch = (value.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        return epoch;

    }

}