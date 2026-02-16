namespace DesignPatternComposite.Component
{
    public abstract class Menu
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }

        protected Menu(string title, string icon = "")
        {
            Title = title;
            Icon = icon;
            IsActive = true;
        }

        public abstract void Render(int indent = 0);
        public abstract int CountItems();

        public virtual void Add(Menu menu)
        {
            throw new NotSupportedException("Esta operação não é suportada neste tipo de menu.");
        }

        public virtual void Remove(Menu menu)
        {
            throw new NotSupportedException("Esta operação não é suportada neste tipo de menu.");
        }

        public virtual Menu GetChild(int index)
        {
            throw new NotSupportedException("Esta operação não é suportada neste tipo de menu.");
        }
    }
}
