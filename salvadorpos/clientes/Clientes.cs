using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interop.QBFC13;
using salvadorpos.Modelo;
using System.Transactions;
using salvadorpos.ServiceReference1;
using PagedList;

namespace salvadorpos
{
    public partial class Clientes : Form
    {
        int pageNumber = 1;
        IPagedList<clientes.claseClientes> lista; 

        IResponse response;
        QuickBooksWebRestSoapClient soap=new QuickBooksWebRestSoapClient();
        mensajeespera me = new mensajeespera();

        public Clientes()
        {
            InitializeComponent();
            mostrarLista();
        }

        public async Task<IPagedList<clientes.claseClientes>> tomarPaginado(int pageNumber, int pageSize) {
            return await Task.Factory.StartNew(() =>
            {
                return listarClientes().OrderBy(x => x.RazonSocial).ToPagedList(pageNumber, pageSize);
            });
        }
        
        private async void Clientes_Load(object sender, EventArgs e)
        {
            //lista = await tomarPaginado(1, 10);
            //btnPrev.Enabled = lista.HasPreviousPage;
            //btnNext.Enabled = lista.HasNextPage;
            //dgvClientes.DataSource = lista.ToList();
            //lblPageNumber.Text = string.Format("Página {0} / {1}", pageNumber, lista.PageCount);

        }
        #region se llena el dataGriedView
        public List<clientes.claseClientes> listarClientes() {
            List<clientes.claseClientes> lista = new List<clientes.claseClientes>();
            try
            {
                #region variables
                string nit = "";
                string ncr = "";
                string diu = "";
                string giro = "";
                string tel = "";
                string rsocial = "";
                string correo = "";
                #endregion
                foreach (var item in soap.ListaClientes())
                {
                    rsocial = item[3].ToString();
                    correo = item[34].ToString();
                    foreach (var x in soap.ListaDataExtCustomer(item[0]))
                    {
                        if (x[2].ToString().Equals("NIT"))
                        {
                            nit = x[4];
                        }
                        else if (x[2].ToString().Equals("NCR"))
                        {
                            ncr = x[4];
                        }
                        else if (x[2].ToString().Equals("GIRO"))
                        {
                            giro = x[4];
                        }
                        else if (x[2].ToString().Equals("DUI"))
                        {
                            diu = x[4];
                        }
                    }
                    lista.Add(new clientes.claseClientes{
                        NIT = nit, NCR = ncr, DUI = diu, GIRO = giro, Telefono = tel, RazonSocial = rsocial, Correo = correo
                    });
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }
        #endregion
        public void mostrarLista() {
            List<clientes.claseClientes> lista = new List<clientes.claseClientes>();
            foreach (var x in listarClientes())
            {
                lista.Add(new clientes.claseClientes
                {
                    RazonSocial = x.RazonSocial,
                    NIT = x.NIT,
                    Correo = x.Correo,
                });
            }
            dgvClientes.DataSource = lista;
            dgvClientes.Columns["NIT"].Visible = false;
            dgvClientes.Columns["NCR"].Visible = false;
            dgvClientes.Columns["DUI"].Visible = false;
            dgvClientes.Columns["GIRO"].Visible = false;
        }
        #region se toman los parametros para crear un cliente
        public List<clientes.claseClientes> crearCliente() {
            List<clientes.claseClientes> lista = new List<clientes.claseClientes>();
            #region variables
            string nit = txtNIT.Text;
            string ncr = txtNCR.Text;
            string diu = txtDUI.Text;
            string giro = txtGiro.Text;
            string tel = txtTelefono.Text;
            string rsocial = txtRazon.Text;
            string correo = txtEmail.Text;
            lista.Add(new clientes.claseClientes {
                NIT = nit, NCR = ncr, DUI = diu, GIRO = giro, Telefono = tel, RazonSocial = rsocial, Correo = correo
            });
            #endregion
            return lista;
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //me.Show();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //me.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        
        public void ingresarcliente()
        {
            try
            {
                using (var quickbooks = new Quickbooks())
                {
                    quickbooks.conectar();
                    ICustomerAdd CustomerAddRq = quickbooks.request.AppendCustomerAddRq();
                    CustomerAddRq.CompanyName.SetValue(txtRazon.Text.Trim());
                    CustomerAddRq.Name.SetValue(txtRazon.Text.Trim());
                    CustomerAddRq.BillAddress.Addr1.SetValue(rtxtDircc.Text.Trim());
                    CustomerAddRq.Email.SetValue(txtEmail.Text.Trim());
                
                    IDataExtMod nit = quickbooks.request.AppendDataExtModRq();
                    IDataExtMod giro = quickbooks.request.AppendDataExtModRq();
                    IDataExtMod ncr = quickbooks.request.AppendDataExtModRq();
                    IDataExtMod dui = quickbooks.request.AppendDataExtModRq();
                    IDataExtMod notaremision = quickbooks.request.AppendDataExtModRq();
                    IDataExtMod fecharem = quickbooks.request.AppendDataExtModRq();

                    nit.DataExtName.SetValue("NIT");
                    nit.DataExtValue.SetValue(txtNIT.Text.Trim());
                    giro.DataExtName.SetValue("GIRO");
                    giro.DataExtValue.SetValue(txtGiro.Text.Trim());
                    ncr.DataExtName.SetValue("NCR");
                    ncr.DataExtValue.SetValue(txtNCR.Text.Trim());
                    dui.DataExtName.SetValue("DUI");
                    dui.DataExtValue.SetValue(txtDUI.Text.Trim());
                    notaremision.DataExtName.SetValue("NOTA DE REMISION");
                    notaremision.DataExtValue.SetValue("na");
                    fecharem.DataExtName.SetValue("FECHA N REMISION");
                    fecharem.DataExtValue.SetValue("na");
                    nit.OwnerID.SetValue("0");
                    giro.OwnerID.SetValue("0");
                    ncr.OwnerID.SetValue("0");
                    dui.OwnerID.SetValue("0");
                    notaremision.OwnerID.SetValue("0");
                    fecharem.OwnerID.SetValue("0");
                    nit.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    nit.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(txtRazon.Text.Trim());
                    giro.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    giro.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(txtRazon.Text.Trim());
                    ncr.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    ncr.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(txtRazon.Text.Trim());
                    dui.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    dui.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(txtRazon.Text.Trim());
                    notaremision.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    notaremision.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(txtRazon.Text.Trim());
                    fecharem.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    fecharem.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(txtRazon.Text.Trim());

                    IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);
                    var estado = respuesta.ResponseList.GetAt(0);

                    if (estado.StatusMessage == "Status OK")
                    {
                        //ingresarsql();
                    }

                    else
                    {
                        MessageBox.Show("No pudimos ingresar el dato", "Intento fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    quickbooks.Dispose();
                }

            }
            catch (Win32Exception win)
            {
                //MessageBox.Show(win.ToString());
                mensajes.err(win);

            }
            catch (Exception laex)
            {
                //MessageBox.Show(laex.ToString());
                mensajes.err(laex);

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<clientes.claseClientes> lista = new List<clientes.claseClientes>();
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Campo obligatorio");

            }

            if (string.IsNullOrEmpty(txtRazon.Text))
            {
                errorProvider1.SetError(txtRazon, "Campo obligatorio");

            }

            if (string.IsNullOrEmpty(txtGiro.Text))
            {
                errorProvider1.SetError(txtGiro, "Campo obligatorio");

            }

            if (string.IsNullOrEmpty(txtNCR.Text))
            {
                errorProvider1.SetError(txtNCR, "Campo obligatorio");

            }


            if (string.IsNullOrEmpty(txtNIT.Text))
            {
                errorProvider1.SetError(txtNIT, "Campo obligatorio");

            }

            if (string.IsNullOrEmpty(txtDUI.Text))
            {
                errorProvider1.SetError(txtDUI, "Campo obligatorio");

            }

            if (string.IsNullOrEmpty(rtxtDircc.Text))
            {
                errorProvider1.SetError(rtxtDircc, "Campo obligatorio");

            }
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtRazon.Text) && !string.IsNullOrEmpty(txtGiro.Text)
                && !string.IsNullOrEmpty(txtNCR.Text) && !string.IsNullOrEmpty(txtNIT.Text) && !string.IsNullOrEmpty(txtDUI.Text)
                && !string.IsNullOrEmpty(rtxtDircc.Text))
            {
                //Insertar clientes

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void modificar()
        {
            string listid = "";
            string editsequence = "";
            //scope_identity_id = 0;
            try
            {
                if (dgvClientes.Rows.Count > 0 && !string.IsNullOrEmpty(txtDUI.Text) && !string.IsNullOrEmpty(txtNIT.Text)
                    && !string.IsNullOrEmpty(txtNCR.Text) && !string.IsNullOrEmpty(txtGiro.Text) && !string.IsNullOrEmpty(txtEmail.Text)
                    && !string.IsNullOrEmpty(txtRazon.Text) && !string.IsNullOrEmpty(rtxtDircc.Text))
                {
                    using (var quickbooks23 = new Quickbooks())
                    {
                        quickbooks23.conectar();
                        ICustomerQuery CustomerQueryRq = quickbooks23.request.AppendCustomerQueryRq();
                        CustomerQueryRq.IncludeRetElementList.Add("ListID");
                        CustomerQueryRq.IncludeRetElementList.Add("EditSequence");
                        CustomerQueryRq.IncludeRetElementList.Add("Name");
                        CustomerQueryRq.OwnerIDList.Add("0");
                        IMsgSetResponse respuesta = quickbooks23.sesionmanager.DoRequests(quickbooks23.request);

                        response = respuesta.ResponseList.GetAt(0);
                        ICustomerRetList lista = response.Detail as ICustomerRetList;

                        ICustomerRet ret;

                        if (response.StatusMessage == "Status OK")
                        {

                            for (int i131 = 0; i131 < lista.Count; i131++)
                            {
                                if (lista.GetAt(i131) != null)
                                {
                                    ret = lista.GetAt(i131);

                                    if (ret.Name.GetValue() == dgvClientes.CurrentRow.Cells[0].Value.ToString())
                                    {
                                        listid = ret.ListID.GetValue();
                                        editsequence = ret.EditSequence.GetValue();
                                    }
                                }

                            }//fin for primero


                        }
                        

                        ICustomerMod CustomerModRq = quickbooks23.request.AppendCustomerModRq();
                        CustomerModRq.ListID.SetValue(listid);
                        CustomerModRq.EditSequence.SetValue(editsequence);
                        CustomerModRq.CompanyName.SetValue(txtRazon.Text.Trim());
                        CustomerModRq.Name.SetValue(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                        CustomerModRq.BillAddress.Addr1.SetValue(rtxtDircc.Text.Trim());
                        CustomerModRq.Email.SetValue(txtEmail.Text.Trim());



                        IDataExtMod nit = quickbooks23.request.AppendDataExtModRq();
                        IDataExtMod giro = quickbooks23.request.AppendDataExtModRq();
                        IDataExtMod ncr = quickbooks23.request.AppendDataExtModRq();
                        IDataExtMod dui = quickbooks23.request.AppendDataExtModRq();
                        IDataExtMod notaremision = quickbooks23.request.AppendDataExtModRq();
                        IDataExtMod fecharem = quickbooks23.request.AppendDataExtModRq();

                        nit.DataExtName.SetValue("NIT");
                        nit.DataExtValue.SetValue(txtNIT.Text.Trim());
                        giro.DataExtName.SetValue("GIRO");
                        giro.DataExtValue.SetValue(txtGiro.Text.Trim());
                        ncr.DataExtName.SetValue("NCR");
                        ncr.DataExtValue.SetValue(txtNCR.Text.Trim());
                        dui.DataExtName.SetValue("DUI");
                        dui.DataExtValue.SetValue(txtDUI.Text.Trim());
                        notaremision.DataExtName.SetValue("NOTA DE REMISION");
                        notaremision.DataExtValue.SetValue("n/a");
                        fecharem.DataExtName.SetValue("FECHA N REMISION");
                        fecharem.DataExtValue.SetValue("n/a");
                        nit.OwnerID.SetValue("0");
                        giro.OwnerID.SetValue("0");
                        ncr.OwnerID.SetValue("0");
                        dui.OwnerID.SetValue("0");
                        notaremision.OwnerID.SetValue("0");
                        fecharem.OwnerID.SetValue("0");
                        nit.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                        nit.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(listid);
                        nit.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                        giro.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                        giro.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(listid);
                        giro.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                        ncr.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                        ncr.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(listid);
                        ncr.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                        dui.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                        dui.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(listid);
                        dui.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                        notaremision.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                        notaremision.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(listid);
                        notaremision.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                        fecharem.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                        fecharem.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(listid);
                        fecharem.ORListTxn.ListDataExt.ListObjRef.FullName.SetValue(dgvClientes.CurrentRow.Cells[0].Value.ToString());


                        IMsgSetResponse respuesta2 = quickbooks23.sesionmanager.DoRequests(quickbooks23.request);
                        //richTextBox1.Text += respuesta.ToXMLString();

                        response = respuesta2.ResponseList.GetAt(0);



                        if (response.StatusMessage == "Status OK")
                        {

                            //modificarsql();
                            //MessageBox.Show(listid + "  " + editsequence);

                        }
                        else
                        {

                            MessageBox.Show(response.StatusMessage);
                        }
                        quickbooks23.Dispose();
                    }

                }
                else
                {

                    MessageBox.Show("Por favor llene todos los campos y asegurese de seleccionar un cliente en la lista de clientes", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch (Win32Exception win)
            {
                MessageBox.Show(win.ToString());
                mensajes.err(win);

            }
            catch (Exception laex)
            {
                MessageBox.Show(laex.ToString());
                mensajes.err(laex);

            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay datos en la lista por favor agreguelos primero", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    foreach (DataGridViewRow row in dgvClientes.Rows)
                    {
                        row.Selected = false;
                    }
                }

                else
                {
                    foreach (DataGridViewRow row in dgvClientes.Rows)
                    {
                        row.Selected = false;
                    }
                    for (int y = 0; y < dgvClientes.Rows.Count; y++)
                    {
                        if (dgvClientes.Rows[y].Cells[0].Value.ToString().ToUpper().Contains(textBox1.Text.Trim().ToUpper()) || textBox1.Text.Trim().ToUpper() == dgvClientes.Rows[y].Cells[0].Value.ToString().ToUpper())
                        {
                            dgvClientes.Rows[y].Selected = true;
                            dgvClientes.FirstDisplayedScrollingRowIndex = y;
                        }
                    }
                }
            }
            catch (Exception rf)
            {
                mensajes.err(rf);

            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                limpiar();
            }
            catch (NullReferenceException ague)
            {
                me.Visible = false;
                MessageBox.Show(ague.ToString());
            }
            catch (Exception ft)
            {
                MessageBox.Show(ft.ToString());
                me.Visible = false;
                //mensajes.err(ft);
            }

        }

        public void limpiar()
        {

            txtDUI.Text = "na";
            txtNIT.Text = "na";
            txtNCR.Text = "na";
            txtGiro.Text = "na";
            txtRazon.Text = "na";
            txtEmail.Text = "";
            rtxtDircc.Text = "na";
            dgvClientes.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                
            }
            catch (Exception euju)
            {
                MessageBox.Show(euju.ToString());
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            modificar();
            errorProvider1.Clear();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void panelOpciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (lista.HasNextPage)
                {
                    lista = await tomarPaginado(--pageNumber, 10);
                    btnPrev.Enabled = lista.HasPreviousPage;
                    btnNext.Enabled = lista.HasNextPage;
                    dgvClientes.DataSource = lista.ToList();
                    lblPageNumber.Text = string.Format("Página {0} / {1}", pageNumber, lista.PageCount);
                }
            }
            catch (Exception)
            {}
            
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (lista.HasPreviousPage)
                {
                    lista = await tomarPaginado(--pageNumber, 10);
                    btnPrev.Enabled = lista.HasPreviousPage;
                    btnNext.Enabled = lista.HasNextPage;
                    dgvClientes.DataSource = lista.ToList();
                    lblPageNumber.Text = string.Format("Página {0} / {1}", pageNumber, lista.PageCount);
                }
            }
            catch (Exception)
            {}
            
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvClientes.Rows[e.RowIndex];
            foreach (var l in selectedRow.Cells)
            {
                
            }
        }
    }
}
