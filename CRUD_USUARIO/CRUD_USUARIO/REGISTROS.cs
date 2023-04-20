using CRUD_USUARIO.DATA;
using CRUD_USUARIO.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_USUARIO
{
    public partial class REGISTROS : Form
    {
        public REGISTROS()
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void REGISTROS_Load(object sender, EventArgs e)
        {
            DiseñoInicial();
            MostrarListaPersonas();


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            USUARIO formUsuario = new USUARIO(null);
            formUsuario.ShowDialog();
            MostrarListaPersonas();
            
        }

        private void DiseñoInicial()
        {
            btnNuevo.Cursor = Cursors.Hand;

            datagridPersona.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridPersona.MultiSelect = false;
            datagridPersona.ReadOnly = true;
            datagridPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridPersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridPersona.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        private void MostrarListaPersonas()
        {
            List<Persona> oListaPersona = new Operaciones().ObtenerPersonas();

            datagridPersona.DataSource = null;
            datagridPersona.Columns.Clear();
            datagridPersona.Rows.Clear();
            datagridPersona.Refresh();

            datagridPersona.DataSource = oListaPersona;
            datagridPersona.Columns["IdPersona"].Visible = false;
            datagridPersona.Columns["Foto"].Visible = false;

            bool te = datagridPersona.Columns.Contains("Accion");

            if (!datagridPersona.Columns.Contains("Accion"))
            {
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.HeaderText = "Accion";
                boton.Text = "Modificar";
                boton.Name = "btnModificar";
                boton.UseColumnTextForButtonValue = true;
                datagridPersona.Columns.Add(boton);
            }


        }

        private void datagridPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridPersona.Columns[e.ColumnIndex].Name == "btnModificar")
            {
                Persona persona = (Persona)datagridPersona.SelectedRows[0].DataBoundItem;
                USUARIO formUsuario = new USUARIO(persona);
                formUsuario.ShowDialog();
                MostrarListaPersonas();
            }
        }

        
        
    }
}
