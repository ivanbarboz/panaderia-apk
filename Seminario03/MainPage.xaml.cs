using Seminario03.Data;
using Seminario03.Modelo;
using Seminario03.Modelos;

namespace Seminario03
{
    public partial class MainPage : ContentPage
    {
        public List<Producto> Productos { get; set; }
        public List<string> Opciones { get; set; }


        public MainPage()
        {
            InitializeComponent();

            Productos = ClsProducto.GetProductos();
            Opciones = ClsCategoria.GetCategorias().Select(c => c.nombre).ToList();

            this.productosCollectionView.ItemsSource = Productos;
            this.selector.ItemsSource = Opciones;
        }

        /*
        async private void OnCounterClicked(object sender, EventArgs e)
        {
            List<Producto> listaProductos = ClsProducto.GetProductos();
            List<Categoria> listaCategorias = ClsCategoria.GetCategorias();
            List<Producto> listaProductosCategoria = ClsProducto.GetProductosPorCategoria(1);

            foreach (Producto p in listaProductosCategoria)
            {
                await DisplayAlert("Título", p.nombre, "OK");
            }

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }*/
    }

}
