namespace Burk.Model.Misc
{
    public class MenuItem
    {
        public int id { get; set; }
        public string text { get; set; }
        public int? parentid { get; set; }

        private MenuItem _parent;
        public MenuItem Parent
        {
            get { return _parent; }
            set { _parent = value; parentid = value.id; }
        }
    }
}
