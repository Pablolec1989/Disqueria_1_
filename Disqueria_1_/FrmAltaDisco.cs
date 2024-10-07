using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Disqueria_1_
{
    public partial class FrmAltaDisco : Form
    {
        public FrmAltaDisco()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaDisco alta = new FrmAltaDisco();
            alta.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Disco disco = new Disco();
            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                disco.Titulo = txtTitulo.Text;
                disco.CantCanciones = (int)NudCantCanc.Value;
                disco.UrlImagenTapa = txtUrlImagen.Text;
                disco.FechaLanz = dtpFechaLanz.Value;
                disco.Estilo = (Estilo)cboEstilo.SelectedItem;

                negocio.agregar(disco);
                MessageBox.Show("Agregado exitosamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }

        private void FrmAltaDisco_Load(object sender, EventArgs e)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            try
            {
                cboEstilo.DataSource = discoNegocio.listar();
                cboEstilo.ValueMember = "Estilo";
                cboEdicion.DataSource = discoNegocio.listar();
                cboEdicion.ValueMember = "Edicion";
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }
    }
}
