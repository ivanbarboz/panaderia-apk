using Seminario03.Data;
using Seminario03.Modelo;
using Seminario03.Modelos;

namespace Seminario03
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

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
        }
    }

}
