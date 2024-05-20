using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionDB;
using Clases; 

namespace TPFINALNivel2_Planissig
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvArticulos.DataSource = listaArticulos;
            dgvArticulos.Columns["Imagen"].Visible = false; 
            cargarImagen(listaArticulos[0].Imagen); 
        }

        private void VentaStock_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
          Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
          cargarImagen(seleccionado.Imagen);     
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pboxArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pboxArticulo.Load("https://media.istockphoto.com/id/1147544807/es/vector/no-imagen-en-miniatura-gr%C3%A1fico-vectorial.jpg?s=612x612&w=0&k=20&c=Bb7KlSXJXh3oSDlyFjIaCiB9llfXsgS7mHFZs6qUgVk=");
              
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaArticulo alta = new AltaArticulo();
            alta.ShowDialog(); 
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
