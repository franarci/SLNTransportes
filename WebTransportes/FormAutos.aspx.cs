using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTransportes
{
    public partial class FormAutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                MostrarDatos();

                CargarDropList(dropMarcas);
                DataTable filtrarMarca = CargarDropList(dropFiltroMarcas);

                DataRow dataRow = filtrarMarca.NewRow();
                dataRow["Marca"] = 0;
                dataRow["Marca"] = "[Todas]";
                filtrarMarca.Rows.InsertAt(dataRow, 0);
                dropFiltroMarcas.DataBind();
            }
        }

        private DataTable CargarDropList(DropDownList dropList)
        {
            DataTable dt = AdmAuto.ListarSoloMarcas();
            dropList.DataSource = dt;
            dropList.DataValueField = dt.Columns["Marca"].ToString();
            dropList.DataTextField = dt.Columns["Marca"].ToString();
            dropList.DataBind();

            return dt;
        }

        private void MostrarDatos()
        {
            gridAutos.DataSource = AdmAuto.Listar();
            gridAutos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto(dropMarcas.SelectedValue, txtModelo.Text,txtMatricula.Text, Convert.ToDecimal(txtPrecio.Text));

            int filasAfectadas = AdmAuto.Insertar(auto);
            Actualizar(filasAfectadas);
        }


        private void Actualizar(int filasAfectadas)
        {
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }

            if (!Page.IsPostBack)
            {
                MostrarDatos();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Auto auto= new Auto(dropMarcas.SelectedValue, txtModelo.Text, txtMatricula.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtId.Text));

            int filasAfectadas = AdmAuto.Modificar(auto);
            Actualizar(filasAfectadas);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int filasAfectadas = AdmAuto.Eliminar(Convert.ToInt32(txtId.Text));
            Actualizar(filasAfectadas);
        }

        protected void dropFiltroMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = dropFiltroMarcas.SelectedValue;
            if (marca == "[Todas]")
            {
                MostrarDatos();
            }
            else
            {
                gridAutos.DataSource = AdmAuto.Listar(marca);
                gridAutos.DataBind();
            }
        }
    }
}