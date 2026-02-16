using DesignPatternComposite.Composite;
using DesignPatternComposite.Leaf;

namespace DesignPatternComposite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Menus CMS - PADRÃO COMPOSITE ===\n");

            var manager = new MenuManager();

            // Item simples no nível raiz (Leaf)
            manager.Add(new MenuItem("Home", "/", "🏠"));

            // Grupo com itens (Composite)
            var productsMenu = new MenuGroup("Produtos", "📦");
            productsMenu.Add(new MenuItem("Todos", "/produtos"));
            productsMenu.Add(new MenuItem("Categorias", "/categorias"));
            productsMenu.Add(new MenuItem("Ofertas", "/ofertas"));

            // Subgrupo dentro de grupo (Composite dentro de Composite!)
            var clothingMenu = new MenuGroup("Roupas", "👕");
            clothingMenu.Add(new MenuItem("Camisetas", "/roupas/camisetas"));
            clothingMenu.Add(new MenuItem("Calças", "/roupas/calcas"));

            // Adiciona o subgrupo ao grupo principal
            productsMenu.Add(clothingMenu);

            // Adiciona o grupo ao manager
            manager.Add(productsMenu);

            // Outro grupo
            var adminMenu = new MenuGroup("Administração", "⚙️");
            adminMenu.Add(new MenuItem("Usuários", "/admin/usuarios"));
            adminMenu.Add(new MenuItem("Configurações", "/admin/config"));
            manager.Add(adminMenu);

            manager.RenderMenu();

            Console.WriteLine($"\nTotal de itens no menu: {manager.GetTotalItems()}");

            var item = manager.FindItemByUrl("/roupas/camisetas");
            if (item != null)
            {
                Console.WriteLine($"\n✓ Item encontrado: {item.Title}");
            }
        }
    }
}
