using CRUD_USUARIO.DATA;
using CRUD_USUARIO.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_USUARIO
{
    public partial class USUARIO : Form
    {
        private bool modo_modificar = false;
        public USUARIO(Persona ParametroPersona)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            if (ParametroPersona != null)
            {
                lblTitulo.Text = "Modificar Registro";
                modo_modificar = true;
                txtIdPersona.Text = ParametroPersona.IdPersona.ToString();
                txtDocumentoidentidad.Text = ParametroPersona.DocumentoIdentidad;
                txtNombres.Text = ParametroPersona.Nombres;
                txtApellidos.Text = ParametroPersona.Apellidos;
                txtTelefono.Text = ParametroPersona.Telefono;

                controlFoto.Image = null;
                controlFoto.Image = Image.FromStream(new MemoryStream(ParametroPersona.Foto));
                controlFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                txtIdPersona.Text = "0";
            }
                

        }

        private void USUARIO_Load(object sender, EventArgs e)
        {
            DiseñoInicial();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiseñoInicial()
        {
            
            controlFoto.BorderStyle = BorderStyle.FixedSingle;
            this.ActiveControl = txtDocumentoidentidad;
            txtRutaFoto.Enabled = false;
            btnGuardar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;
            btnBuscarImage.Cursor = Cursors.Hand;
        }

        private void btnBuscarImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Filter = "Imagen jpg|*.jpg";

            
            if(oFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaFoto.Text = oFileDialog.FileName;

                controlFoto.Image = new Bitmap(oFileDialog.FileName);
                controlFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Persona oPersona = new Persona();
            byte[] BitesImagen;
          

            using (MemoryStream ms = new MemoryStream())
            {
                controlFoto.Image.Save(ms, controlFoto.Image.RawFormat);
                BitesImagen = ms.GetBuffer();
            }



            oPersona.IdPersona = int.Parse(txtIdPersona.Text);
            oPersona.DocumentoIdentidad = txtDocumentoidentidad.Text;
            oPersona.Nombres = txtNombres.Text;
            oPersona.Apellidos = txtApellidos.Text;
            oPersona.Telefono = txtTelefono.Text;
            oPersona.Foto = BitesImagen;


            string mensajeOk = "";
            bool respuesta = false; ;
            if (modo_modificar)
            {
                mensajeOk = "Se guardaron los cambios \n¿Desea hacer un nuevo registro?";
                respuesta = new Operaciones().ModificarPersona(oPersona);
            }
            else
            {
                mensajeOk = "Persona Registrada \n¿Desea hacer un nuevo registro?";
                respuesta = new Operaciones().CrearPersona(oPersona);
            }



            if (respuesta)
            {
                if (MessageBox.Show(mensajeOk, "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lblTitulo.Text = "Nuevo Registro";
                    txtDocumentoidentidad.Text = "";
                    txtNombres.Text = "";
                    txtApellidos.Text = "";
                    txtTelefono.Text = "";
                    txtRutaFoto.Text = "";
                    controlFoto.Image = null;
                }
                else
                {
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Persona se encuentra registrada","Mensaje");
            }

        }
    }
}
