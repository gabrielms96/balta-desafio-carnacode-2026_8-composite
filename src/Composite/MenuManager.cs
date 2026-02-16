using DesignPatternComposite.Component;
using DesignPatternComposite.Leaf;

namespace DesignPatternComposite.Composite
{
    public class MenuManager
    {
        private readonly List<Menu> _rootItems = new();

        public void Add(Menu menu)
        {
            _rootItems.Add(menu);
        }

        public void Remove(Menu menu)
        {
            _rootItems.Remove(menu);
        }

        public void RenderMenu()
        {
            Console.WriteLine("=== Menu Principal ===\n");

            foreach (var item in _rootItems)
            {
                item.Render();
            }
        }

        public int GetTotalItems()
        {
            return _rootItems.Sum(item => item.CountItems());
        }

        public MenuItem? FindItemByUrl(string url)
        {
            foreach (var item in _rootItems)
            {
                if (item is MenuItem menuItem && menuItem.Url == url)
                {
                    return menuItem;
                }

                if (item is MenuGroup group)
                {
                    var found = group.FindItemByUrl(url);
                    if (found != null)
                        return found;
                }
            }

            return null;
        }

        public void DisableAllItems()
        {
            foreach (var item in _rootItems)
            {
                item.IsActive = false;

                if (item is MenuGroup group)
                {
                    group.DisableAllItems();
                }
            }
        }
    }
}
