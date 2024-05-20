using Clases;
using ConexionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFINALNivel2_Planissig
{
    public partial class AltaArticulo : Form
    {
        public AltaArticulo()
        {
            InitializeComponent();
        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                art.Nombre = txtBoxNombre.Text;
                art.CodigoArt = txtBoxCodigo.Text;
                art.Descripcion = txtBoxDescripcion.Text;
                art.Marca = (Relacion)cmBoxM.SelectedItem;
                art.Tipo = (Relacion)cmBoxC.SelectedItem;
                art.Precio = decimal.Parse(txtBoxPrecio.Text);
                art.Imagen = txtBoxImagen.Text;
                
                negocio.agregarArticulo(art);
                MessageBox.Show("Agregado exitosamente");
                Close(); 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); 
            }           
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            ArticuloNegocio artnego = new ArticuloNegocio();
            try
            {
                cmBoxC.DataSource = artnego.listar();
                cmBoxM.DataSource = artnego.listar(); 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); 
            }
        }
    }
}
