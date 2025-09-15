namespace ClickUpMcpServer.Models;

public class GetFolders
{
    public class Response
    {
        public Folders[] folders { get; set; }
    }

    public class Folders
    {
        public string id { get; set; }
        public string name { get; set; }
        public int orderindex { get; set; }
        public bool override_statuses { get; set; }
        public bool hidden { get; set; }
        public Space space { get; set; }
        public string task_count { get; set; }
        public bool archived { get; set; }
        public Statuses[] statuses { get; set; }
        public Lists[] lists { get; set; }
        public string permission_level { get; set; }
    }

    public class Space
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Statuses
    {
        public string id { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public int orderindex { get; set; }
        public string color { get; set; }
    }

    public class Lists
    {
        public string id { get; set; }
        public string name { get; set; }
        public int orderindex { get; set; }
        public object status { get; set; }
        public object priority { get; set; }
        public object assignee { get; set; }
        public int task_count { get; set; }
        public object due_date { get; set; }
        public object start_date { get; set; }
        public Space1 space { get; set; }
        public bool archived { get; set; }
        public object override_statuses { get; set; }
        public Statuses1[] statuses { get; set; }
        public string permission_level { get; set; }
    }

    public class Space1
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool access { get; set; }
    }

    public class Statuses1
    {
        public string id { get; set; }
        public string status { get; set; }
        public int orderindex { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public string status_group { get; set; }
    }
}