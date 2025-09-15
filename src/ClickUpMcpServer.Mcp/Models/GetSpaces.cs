using System.Text.Json.Serialization;

namespace ClickUpMcpServer.Models;

public class GetSpaces
{
    public class Response
    {
        public Spaces[] spaces { get; set; }
    }

    public class Spaces
    {
        public string id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        [JsonPropertyName("private")]
        public bool Private { get; set; }
        public object? avatar { get; set; }
        public object? admin_can_manage { get; set; }
        public Statuses[] statuses { get; set; }
        public bool multiple_assignees { get; set; }
        public Features features { get; set; }
        public bool archived { get; set; }
    }

    public class Statuses
    {
        public string id { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public int orderindex { get; set; }
        public string color { get; set; }
    }

    public class Features
    {
        public Due_dates due_dates { get; set; }
        public Sprints sprints { get; set; }
        public Time_tracking time_tracking { get; set; }
        public Points points { get; set; }
        public Custom_items custom_items { get; set; }
        public Priorities priorities { get; set; }
        public Tags tags { get; set; }
        public Time_estimates time_estimates { get; set; }
        public Check_unresolved check_unresolved { get; set; }
        public Milestones milestones { get; set; }
        public Custom_fields custom_fields { get; set; }
        public Remap_dependencies remap_dependencies { get; set; }
        public Status_pies status_pies { get; set; }
        public Multiple_assignees multiple_assignees { get; set; }
        public Emails emails { get; set; }
        public bool scheduler_enabled { get; set; }
        public bool dependency_type_enabled { get; set; }
    }

    public class Due_dates
    {
        public bool enabled { get; set; }
        public bool start_date { get; set; }
        public bool remap_due_dates { get; set; }
        public bool remap_closed_due_date { get; set; }
    }

    public class Sprints
    {
        public bool enabled { get; set; }
    }

    public class Time_tracking
    {
        public bool enabled { get; set; }
        public bool harvest { get; set; }
        public bool rollup { get; set; }
        public int default_to_billable { get; set; }
    }

    public class Points
    {
        public bool enabled { get; set; }
    }

    public class Custom_items
    {
        public bool enabled { get; set; }
    }

    public class Priorities
    {
        public bool enabled { get; set; }
        public Priorities1[] priorities { get; set; }
    }

    public class Priorities1
    {
        public string color { get; set; }
        public string id { get; set; }
        public string orderindex { get; set; }
        public string priority { get; set; }
    }

    public class Tags
    {
        public bool enabled { get; set; }
    }

    public class Time_estimates
    {
        public bool enabled { get; set; }
        public bool rollup { get; set; }
        public bool per_assignee { get; set; }
    }

    public class Check_unresolved
    {
        public bool enabled { get; set; }
        public bool subtasks { get; set; }
        public object checklists { get; set; }
        public object comments { get; set; }
    }

    public class Milestones
    {
        public bool enabled { get; set; }
    }

    public class Custom_fields
    {
        public bool enabled { get; set; }
    }

    public class Remap_dependencies
    {
        public bool enabled { get; set; }
    }

    public class Status_pies
    {
        public bool enabled { get; set; }
    }

    public class Multiple_assignees
    {
        public bool enabled { get; set; }
    }

    public class Emails
    {
        public bool enabled { get; set; }
    }
}