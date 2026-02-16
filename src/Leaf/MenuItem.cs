using DesignPatternComposite.Component;

namespace DesignPatternComposite.Leaf
{
    public class MenuItem : Menu
    {
        public string Url { get; set; }

        public MenuItem(string title, string url, string icon = "") : base(title, icon)
        {
            Url = url;
        }

        public override int CountItems() => 1;

        public override void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} → {Url}");
        }
    }
}
