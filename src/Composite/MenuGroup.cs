using DesignPatternComposite.Component;
using DesignPatternComposite.Leaf;

namespace DesignPatternComposite.Composite
{
    public class MenuGroup : Menu
    {
        private readonly List<Menu> _children = new();

        public MenuGroup(string title, string icon = "") : base(title, icon)
        {
        }

        public override void Add(Menu menu)
        {
            _children.Add(menu);
        }

        public override void Remove(Menu menu)
        {
            _children.Remove(menu);
        }

        public override Menu GetChild(int index)
        {
            return _children[index];
        }

        public override void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} ▼");

            foreach (var child in _children)
            {
                child.Render(indent + 1);
            }
        }

        public override int CountItems()
        {
            return _children.Sum(child => child.CountItems());
        }

        public void DisableAllItems()
        {
            foreach (var child in _children)
            {
                child.IsActive = false;

                if (child is MenuGroup group)
                {
                    group.DisableAllItems();
                }
            }
        }

        public MenuItem? FindItemByUrl(string url)
        {
            foreach (var child in _children)
            {
                if (child is MenuItem item && item.Url == url)
                {
                    return item;
                }

                if (child is MenuGroup group)
                {
                    var found = group.FindItemByUrl(url);
                    if (found != null)
                        return found;
                }
            }

            return null;
        }
    }
}
