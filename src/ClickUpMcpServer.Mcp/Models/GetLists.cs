namespace ClickUpMcpServer.Models;

internal class GetLists
{
    public class Response
    {
        public List[] lists { get; set; }
    }

    public class List
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
        public Folder folder { get; set; }
        public Space space { get; set; }
        public bool archived { get; set; }
        public object override_statuses { get; set; }
        public string permission_level { get; set; }
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
        public string name { get; set; }
        public bool access { get; set; }
    }

}
