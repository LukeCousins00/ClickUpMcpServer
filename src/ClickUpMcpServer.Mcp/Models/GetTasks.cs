namespace ClickUpMcpServer.Models;

internal class GetTasks
{
    public class Response
    {
        public Task[] tasks { get; set; }
        public bool last_page { get; set; }
    }

    public class Task
    {
        public string id { get; set; }
        public object custom_id { get; set; }
        public int custom_item_id { get; set; }
        public string name { get; set; }
        public string text_content { get; set; }
        public string description { get; set; }
        public Status status { get; set; }
        public string orderindex { get; set; }
        public string date_created { get; set; }
        public string date_updated { get; set; }
        public object date_closed { get; set; }
        public object date_done { get; set; }
        public bool archived { get; set; }
        public Creator creator { get; set; }
        public object[] assignees { get; set; }
        public object[] group_assignees { get; set; }
        public Watcher[] watchers { get; set; }
        public object[] checklists { get; set; }
        public Tag[] tags { get; set; }
        public object parent { get; set; }
        public object top_level_parent { get; set; }
        public Priority priority { get; set; }
        public object due_date { get; set; }
        public object start_date { get; set; }
        public int points { get; set; }
        public int time_estimate { get; set; }
        public Custom_Fields[] custom_fields { get; set; }
        public object[] dependencies { get; set; }
        public object[] linked_tasks { get; set; }
        public object[] locations { get; set; }
        public string team_id { get; set; }
        public string url { get; set; }
        public Sharing sharing { get; set; }
        public string permission_level { get; set; }
        public List list { get; set; }
        public Project project { get; set; }
        public Folder folder { get; set; }
        public Space space { get; set; }
    }

    public class Status
    {
        public string status { get; set; }
        public string id { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public int orderindex { get; set; }
    }

    public class Creator
    {
        public int id { get; set; }
        public string username { get; set; }
        public object color { get; set; }
        public string email { get; set; }
        public object profilePicture { get; set; }
    }

    public class Priority
    {
        public string color { get; set; }
        public string id { get; set; }
        public string orderindex { get; set; }
        public string priority { get; set; }
    }

    public class Sharing
    {
        public bool _public { get; set; }
        public object public_share_expires_on { get; set; }
        public string[] public_fields { get; set; }
        public object token { get; set; }
        public bool seo_optimized { get; set; }
    }

    public class List
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool access { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool hidden { get; set; }
        public bool access { get; set; }
    }

    public class Folder
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool hidden { get; set; }
        public bool access { get; set; }
    }

    public class Space
    {
        public string id { get; set; }
    }

    public class Watcher
    {
        public int id { get; set; }
        public string username { get; set; }
        public object color { get; set; }
        public string initials { get; set; }
        public string email { get; set; }
        public object profilePicture { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public string tag_fg { get; set; }
        public string tag_bg { get; set; }
        public int creator { get; set; }
    }

    public class Custom_Fields
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Type_Config type_config { get; set; }
        public string date_created { get; set; }
        public bool hide_from_guests { get; set; }
        public string value { get; set; }
        public object value_richtext { get; set; }
        public bool required { get; set; }
    }

    public class Type_Config
    {
    }

}
