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
namespace salvadorpos.Inicio
{
    public partial class iniciar : Form
    {
        IResponse response;
        public iniciar()
        {
            InitializeComponent();
        }

        private void iniciar_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            //backgroundWorker2.RunWorkerAsync();
            //backgroundWorker3.RunWorkerAsync();
            //backgroundWorker4.RunWorkerAsync();
            //backgroundWorker5.RunWorkerAsync();
            //backgroundWorker6.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               
                using (var sq = new sql())
                {

                    //sq.conexion();

                    //sq.cadenasql = "drop table if exists cusstomers";
                    //sq.comando = new MySqlCommand(sq.cadenasql,sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "CREATE TABLE IF not exists cusstomers ( id bigint(111) NOT null AUTO_INCREMENT PRIMARY KEY, `customername` VARCHAR(150) NOT NULL ,`companyname` VARCHAR(150) NOT NULL,`phone` VARCHAR(150) NOT NULL,`email` VARCHAR(150) NOT NULL,`shipto` VARCHAR(150) NOT NULL,`nit` VARCHAR(150) NOT NULL,`giro` VARCHAR(150) NOT NULL,`dui` VARCHAR(150) NOT NULL,`ncr` VARCHAR(150) NOT NULL)";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //using (var quickbooks = new Quickbooks())
                    //{
                    //    quickbooks.conectar();
                    //    ICustomerQuery CustomerQueryRq = quickbooks.request.AppendCustomerQueryRq();

                    //    CustomerQueryRq.OwnerIDList.Add("0");
                    //    CustomerQueryRq.IncludeRetElementList.Add("Name");
                    //    CustomerQueryRq.IncludeRetElementList.Add("CompanyName");
                    //    CustomerQueryRq.IncludeRetElementList.Add("Phone");
                    //    CustomerQueryRq.IncludeRetElementList.Add("Email");
                    //    CustomerQueryRq.IncludeRetElementList.Add("DataExtRet");
                    //    CustomerQueryRq.IncludeRetElementList.Add("ShipAddress");
                    //    //CustomerQueryRq.IncludeRetElementList.Add("Name");


                    //    IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);
                    //    //richTextBox1.Text += respuesta.ToXMLString();

                    //    response = respuesta.ResponseList.GetAt(0);



                    //    ICustomerRetList lista = response.Detail as ICustomerRetList;

                    //    ICustomerRet ret;

                    //    if (response.StatusMessage == "Status OK")
                    //    {

                    //        for (int i131 = 0; i131 < lista.Count; i131++)
                    //        {
                    //            string name = "";
                    //            string phone = "";
                    //            string email = "";
                    //            string cname = "";
                    //            string nit = "";
                    //            string giro = "";
                    //            string dui = "";
                    //            string ncr = "";
                    //            string ship = "";
                    //            if (lista.GetAt(i131) != null)
                    //            {
                    //                ret = lista.GetAt(i131);

                    //                if (ret.Name!=null)
                    //                {
                    //                    name = ret.Name.GetValue();

                    //                }
                    //                else
                    //                {
                    //                    name = "sin datos";
                    //                }

                    //                if (ret.CompanyName != null)
                    //                {
                    //                    cname = ret.CompanyName.GetValue();

                    //                }
                    //                else
                    //                {
                    //                    cname = "sin datos";
                    //                }
                    //                if (ret.Phone != null)
                    //                {
                    //                    phone = ret.Phone.GetValue();

                    //                }
                    //                else
                    //                {
                    //                    phone = "sin datos";
                    //                }

                    //                if (ret.Email != null)
                    //                {
                    //                    email = ret.Email.GetValue();

                    //                }
                    //                else
                    //                {
                    //                    email = "sin datos";
                    //                }

                    //                if (ret.ShipAddress!=null&&ret.ShipAddress.Addr1!=null)
                    //                {
                    //                    ship = ret.ShipAddress.Addr1.GetValue() ;

                    //                }
                    //                else
                    //                {

                    //                    ship = "sin datos";
                    //                }

                                    


                    //                if (ret.DataExtRetList != null)
                    //                {
                    //                    for (int i425 = 0; i425 < ret.DataExtRetList.Count; i425++)
                    //                    {
                    //                        IDataExtRet DataExtRet = ret.DataExtRetList.GetAt(i425);

                    //                        if (DataExtRet != null)
                    //                        {
                    //                            if (DataExtRet.DataExtName.GetValue() == "NIT")
                    //                            {
                                                   
                    //                               nit = DataExtRet.DataExtValue.GetValue();

                    //                            }
                    //                            else if (DataExtRet.DataExtName.GetValue() == "NCR")
                    //                            {

                    //                                ncr = DataExtRet.DataExtValue.GetValue();
                    //                            }
                    //                            else if (DataExtRet.DataExtName.GetValue() == "DUI")
                    //                            {

                    //                                dui = DataExtRet.DataExtValue.GetValue();
                    //                            }
                    //                            else if (DataExtRet.DataExtName.GetValue() == "GIRO")
                    //                            {

                    //                                giro = DataExtRet.DataExtValue.GetValue();
                    //                            }
                    //                        }





                    //                        //MessageBox.Show(DataExtRet.DataExtValue.GetValue());
                    //                    }

                    //                }
                    //                sq.cadenasql = "insert into cusstomers (customername,companyname,phone,email,shipto,nit,giro,dui," +
                    //                    "ncr)values (@name,@cname,@phone," +
                    //                    "@email,@shipto,@nit,@giro,@dui,@ncr)";

                    //                sq.comando = new MySqlCommand(sq.cadenasql,sq.con);
                    //                sq.comando.Parameters.AddWithValue("@name", name);
                    //                sq.comando.Parameters.AddWithValue("@cname", cname);
                    //                sq.comando.Parameters.AddWithValue("@phone", phone);
                    //                sq.comando.Parameters.AddWithValue("@email", email);
                    //                sq.comando.Parameters.AddWithValue("@shipto", ship);
                    //                sq.comando.Parameters.AddWithValue("@nit", nit);
                    //                sq.comando.Parameters.AddWithValue("@giro", giro);
                    //                sq.comando.Parameters.AddWithValue("@dui", dui);
                    //                sq.comando.Parameters.AddWithValue("@ncr", ncr);
                    //                sq.comando.ExecuteNonQuery();


                    //            }



                    //            backgroundWorker1.ReportProgress(i131+3);

                    //        }//fin for primero


                    //    }



                    //    quickbooks.Dispose();


                    //}

                    ////sq.rol();
                    //sq.Dispose();
                }


            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show(nre.ToString() + response.StatusCode.ToString());

            }
            catch (Exception err)
            {
                mensajes.err(err);


            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            progressBar1.Value = e.ProgressPercentage;

            label1.Text = "Cargando clientes >> "+e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "clientes cargados correctamente";
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Maximum;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string name = "";
                string subitem = "";
                string desc = "";
                string cogs = "";
                double price = 0;
                string tax ="";
                string income = "";
                string asset = "";
                double onhand =0;

                using (var sq = new sql())
                {

                    //sq.conexion();

                    //sq.cadenasql = "drop table if exists inventory";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "CREATE TABLE if not EXISTS inventory(id bigint(111) NOT NULL AUTO_INCREMENT PRIMARY KEY, name VARCHAR(150) NOT NULL,subitem VARCHAR(150) NOT NULL,description VARCHAR(150) NOT NULL,cogsaccount VARCHAR(150) NOT NULL,price DOUBLE(10,2) NOT NULL, tax VARCHAR(50) NOT NULL, incomeaccount VARCHAR(150) NOT NULL,assetaccount VARCHAR(150) NOT NULL)";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    using (var quickbooks = new Quickbooks())
                    {
                        quickbooks.conectar();
                        IItemInventoryQuery ItemInventoryQueryRq = quickbooks.request.AppendItemInventoryQueryRq();

                      


                        IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);
                       

                        response = respuesta.ResponseList.GetAt(0);



                        IItemInventoryRetList lista = response.Detail as IItemInventoryRetList;

                        IItemInventoryRet ret;

                        if (response.StatusMessage == "Status OK")
                        {

                            for (int i131 = 0; i131 < lista.Count; i131++)
                            {
                                if (lista.GetAt(i131) != null)
                                {
                                    ret = lista.GetAt(i131);

                                    if (ret.Name != null)
                                    {
                                        name = ret.Name.GetValue();
                                       
                                        
                                    }
                                    else
                                    {
                                        name = "sin datos";
                                    }

                                    if (ret.ParentRef != null)
                                    {
                                        subitem = ret.ParentRef.FullName.GetValue();
                                      
                                    }
                                    else
                                    {
                                        subitem = "sin datos";
                                    }
                                    if (ret.SalesDesc != null)
                                    {
                                        desc =ret.SalesDesc.GetValue();
                                       
                                       
                                    }
                                    else
                                    {
                                        desc = "sin datos";
                                    }

                                    if (ret.COGSAccountRef != null)
                                    {
                                        cogs = ret.COGSAccountRef.FullName.GetValue();
                                      
                                    }
                                    else
                                    {
                                        cogs = "sin datos";
                                    }

                                    if (ret.SalesPrice != null)
                                    {
                                        price = (double)ret.SalesPrice.GetValue();

                                    }
                                    else
                                    {

                                        price = 0;
                                    }
                                    if (ret.SalesTaxCodeRef != null)
                                    {
                                        tax = ret.SalesTaxCodeRef.FullName.GetValue();

                                    }
                                    else
                                    {

                                        tax = "sin datos";
                                    }
                                    if (ret.IncomeAccountRef != null)
                                    {
                                        income = ret.IncomeAccountRef.FullName.GetValue();
                                    
                                       
                                    }
                                    else
                                    {

                                        income = "sin datos";
                                    }
                                   
                                    if (ret.AssetAccountRef != null)
                                    {
                                        asset = ret.AssetAccountRef.FullName.GetValue();
                                     
                                    }
                                    else
                                    {

                                        asset = "sin datos";
                                    }
                                  





                                    //sq.cadenasql = @"insert into inventory (name,subitem,description,cogsaccount,price,tax,incomeaccount,assetaccount)values" +
                                    //    "(@name,@sub,@des,@cogs" +
                                    //    ",@price,@tax,@income,@asset)";

                                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                                    //sq.comando.Parameters.AddWithValue("@name",name);
                                    //sq.comando.Parameters.AddWithValue("@sub", subitem);
                                    //sq.comando.Parameters.AddWithValue("@des", desc);
                                    //sq.comando.Parameters.AddWithValue("@cogs", cogs);
                                    //sq.comando.Parameters.AddWithValue("@price", price);
                                    //sq.comando.Parameters.AddWithValue("@tax", tax);
                                    //sq.comando.Parameters.AddWithValue("@income", income);
                                    //sq.comando.Parameters.AddWithValue("@asset", asset);
                                    //sq.comando.ExecuteNonQuery();


                                }



                                backgroundWorker2.ReportProgress(i131+3);

                            }//fin for primero


                        }



                        quickbooks.Dispose();


                    }

                    //sq.rol();
                    sq.Dispose();
                }


            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show(nre.ToString() + response.StatusCode.ToString());

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                mensajes.err(err);


            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;

            label2.Text = "Cargando inventory >> " + e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label2.Text = "productos de inventario cargados correctamente";
            progressBar2.Style = ProgressBarStyle.Blocks;
            progressBar2.Value = progressBar2.Maximum;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string name = "";
                
                string desc = "";
               
                double  price = 0;
                string tax = "";
                string account = "";
              
                

                using (var sq = new sql())
                {

                    //sq.conexion();

                    //sq.cadenasql = "drop table if exists nonInventory";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "CREATE TABLE if not EXISTS nonInventory(id bigint(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,name VARCHAR(150) NOT NULL,description VARCHAR(150) NOT NULL,price DOUBLE(10,2) NOT NULL, tax VARCHAR(50) NOT NULL, account VARCHAR(150) NOT NULL)";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    using (var quickbooks = new Quickbooks())
                    {
                        quickbooks.conectar();
                        IItemNonInventoryQuery ItemNonInventoryQueryRq = quickbooks.request.AppendItemNonInventoryQueryRq();




                        IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);


                        response = respuesta.ResponseList.GetAt(0);



                        IItemNonInventoryRetList lista = response.Detail as IItemNonInventoryRetList;

                        IItemNonInventoryRet ret;

                        if (response.StatusMessage == "Status OK")
                        {

                            for (int i131 = 0; i131 < lista.Count; i131++)
                            {
                                if (lista.GetAt(i131) != null)
                                {
                                    ret = lista.GetAt(i131);

                                    if (ret.Name != null)
                                    {
                                        name = ret.Name.GetValue();


                                    }
                                    else
                                    {
                                        name = "sin datos";
                                    }

                                   
                                    if (ret.ORSalesPurchase.SalesOrPurchase.Desc!=null)
                                    {
                                        desc = ret.ORSalesPurchase.SalesOrPurchase.Desc.GetValue();


                                    }
                                    else
                                    {
                                        desc = "sin datos";
                                    }

                                   

                                    if (ret.ORSalesPurchase.SalesOrPurchase.ORPrice.Price != null)
                                    {
                                        price = (double)ret.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.GetValue();

                                    }
                                    else
                                    {

                                        price = 0;
                                    }
                                    tax = "Non";
                                    
                                    if (ret.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName != null)
                                    {
                                        account = ret.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue();

                                    }
                                    else
                                    {

                                        account = "sin datos";
                                    }
                                  





                                    //sq.cadenasql = @"insert into nonInventory (name,description,price,tax,account)values" +
                                    //    "(@name,@des" +
                                    //    ",@price,@tax,@account)";

                                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                                    //sq.comando.Parameters.AddWithValue("@name", name);

                                    //sq.comando.Parameters.AddWithValue("@des", desc);
                                   
                                    //sq.comando.Parameters.AddWithValue("@price", price);
                                    //sq.comando.Parameters.AddWithValue("@tax", tax);
                                   
                                    //sq.comando.Parameters.AddWithValue("@account", account);
                                 
                                    //sq.comando.ExecuteNonQuery();


                                }



                                backgroundWorker2.ReportProgress(i131 + 3);

                            }//fin for primero


                        }



                        quickbooks.Dispose();


                    }

                    //sq.rol();
                    sq.Dispose();
                }


            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show(nre.ToString() + response.StatusCode.ToString());

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                mensajes.err(err);


            }
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar3.Value = e.ProgressPercentage;

            label3.Text = "Cargando no inventario >> " + e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label3.Text = "productos de no inventario cargados correctamente";
            progressBar3.Style = ProgressBarStyle.Blocks;
            progressBar3.Value = progressBar3.Maximum;
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string numero = "";

                DateTime fecha = new DateTime();

                string customer="";

                double canti=0;
                double monto=0;

                using (var sq = new sql())
                {

                    //sq.conexion2();

                    //sq.cadenasql = "drop table if exists estimate";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "CREATE TABLE if not exists estimate(id   bigint(111) NOT NULL AUTO_INCREMENT PRIMARY KEY,numero VARCHAR(50)  NOT NULL,fecha DATETIME NOT NULL,customer VARCHAR(150) NOT NULL)";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "drop table if exists detalleestimate";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "CREATE TABLE if not exists detalleestimate(id bigint(111) NOT NULL AUTO_INCREMENT PRIMARY KEY,numero VARCHAR(50) NOT NULL,cantidad DOUBLE(10,2) NOT NULL,monto DOUBLE(10,2) NOT NULL)";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    using (var quickbooks = new Quickbooks())
                    {
                        quickbooks.conectar();
                        IEstimateQuery EstimateQueryRq = quickbooks.request.AppendEstimateQueryRq();
                        EstimateQueryRq.IncludeLineItems.SetValue(true);



                        IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);

                        //MessageBox.Show(respuesta.ToXMLString());
                        response = respuesta.ResponseList.GetAt(0);
                        //richTextBox1.Invoke(new MethodInvoker(delegate {
                        //    richTextBox1.Text = respuesta.ToXMLString();
                        //}));
                        

                        IEstimateRetList lista = response.Detail as IEstimateRetList;
                        
                        IEstimateRet ret;
                      
                        if (response.StatusMessage == "Status OK")
                        {

                            for (int i131 = 0; i131 < lista.Count; i131++)
                            {
                                if (lista.GetAt(i131) != null)
                                {
                                    ret = lista.GetAt(i131);
                                   
                                    if (ret.RefNumber != null)
                                    {
                                        numero = ret.RefNumber.GetValue();
                                       

                                    }
                                    else
                                    {
                                        numero = "sin datos";
                                    }

                                   

                                    if (ret.TxnDate != null)
                                    {
                                        fecha = ret.TxnDate.GetValue();


                                    }
                                    else
                                    {
                                        fecha = DateTime.Now;
                                    }



                                    if (ret.CustomerRef != null)
                                    {
                                        customer = ret.CustomerRef.FullName.GetValue();

                                    }
                                    else
                                    {

                                        customer = "sin datos";
                                    }






                                    //sq.cadenasql = @"insert into estimate (numero,fecha,customer)values" +
                                    //    "(@numb,@date" +
                                    //    ",@custom)";

                                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                                    //sq.comando.Parameters.AddWithValue("@numb", numero);

                                    //sq.comando.Parameters.AddWithValue("@date", fecha);

                                    //sq.comando.Parameters.AddWithValue("@custom", customer);
                                  

                                    //sq.comando.ExecuteNonQuery();


                                    if (ret.OREstimateLineRetList != null)
                                    {

                                        for (int x = 0; x < ret.OREstimateLineRetList.Count; x++)
                                        {

                                            //IOREstimateLineRet rete = ret.OREstimateLineRetList.Append();
                                            IEstimateLineRet rete = ret.OREstimateLineRetList.GetAt(x).EstimateLineRet;
                                            if (rete.Quantity != null)
                                            {
                                                canti = (double)rete.Quantity.GetValue();
                                            }
                                            else
                                            {

                                                canti = 0.6;
                                            }
                                            if (rete.Amount != null)
                                            {
                                                monto = (double)rete.Amount.GetValue();
                                            }
                                            else
                                            {

                                                monto = 23.8855;
                                            }

                                       //     sq.cadenasql = @"insert into detalleestimate (numero,cantidad,monto)values" +
                                       //"(@numero,@cant" +
                                       //",@mon)";

                                       //     sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                                       //     sq.comando.Parameters.AddWithValue("@numero", numero);

                                       //     sq.comando.Parameters.AddWithValue("@cant", canti);

                                       //     sq.comando.Parameters.AddWithValue("@mon", monto);


                                       //     sq.comando.ExecuteNonQuery();

                                        }


                                    }
                                    else
                                    {
                                        canti = 0;
                                        monto = 0;
                                    }


                                }



                                backgroundWorker4.ReportProgress(i131 + 3);

                            }//fin for primero


                        }
                        else
                        {

                            MessageBox.Show(response.StatusCode.ToString());
                        }



                        quickbooks.Dispose();


                    }

                    sq.rol();
                    sq.Dispose();
                }


            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show(nre.ToString() + response.StatusCode.ToString());

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                mensajes.err(err);


            }
        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          

            progressBar4.Value = e.ProgressPercentage;

            label4.Text = "Cargando facturas >> " + e.ProgressPercentage;
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label4.Text = "facturas cargadas correctamente";
            progressBar4.Style = ProgressBarStyle.Blocks;
            progressBar4.Value = progressBar4.Maximum;
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string nombre = "";

                string genero = "";

                string telefono="";




                using (var sq = new sql())
                {

                    //sq.conexion();

                    //sq.cadenasql = "drop table if exists employee";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "CREATE TABLE if not EXISTS employee(id bigint(111) NOT NULL AUTO_INCREMENT PRIMARY KEY,nombre VARCHAR(150) NOT NULL,genero VARCHAR(50) NOT NULL,telefono VARCHAR(50) NOT NULL)";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    using (var quickbooks = new Quickbooks())
                    {
                        quickbooks.conectar();
                        IEmployeeQuery EmployeeQueryRq = quickbooks.request.AppendEmployeeQueryRq();




                        IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);


                        response = respuesta.ResponseList.GetAt(0);



                        IEmployeeRetList lista = response.Detail as IEmployeeRetList;

                        IEmployeeRet ret;

                        if (response.StatusMessage == "Status OK")
                        {

                            for (int i131 = 0; i131 < lista.Count; i131++)
                            {
                                if (lista.GetAt(i131) != null)
                                {
                                    ret = lista.GetAt(i131);

                                    if (ret.Name != null)
                                    {
                                        nombre = ret.Name.GetValue();


                                    }
                                    else
                                    {
                                        nombre = "sin datos";
                                    }


                                    if (ret.Gender != null)
                                    {
                                        genero = ret.Gender.GetAsString();


                                    }
                                    else
                                    {
                                        genero = "sin datos";
                                    }



                                    if (ret.Phone != null)
                                    {
                                        telefono = ret.Phone.GetValue();

                                    }
                                    else
                                    {

                                        telefono = "sin datos";
                                    }






                                    //sq.cadenasql = @"insert into employee (nombre,genero,telefono)values" +
                                    //    "(@name,@gender" +
                                    //    ",@tele)";

                                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                                    //sq.comando.Parameters.AddWithValue("@name", nombre);

                                    //sq.comando.Parameters.AddWithValue("@gender", genero);

                                    //sq.comando.Parameters.AddWithValue("@tele", telefono);


                                    //sq.comando.ExecuteNonQuery();


                                }



                                backgroundWorker5.ReportProgress(i131 + 3);

                            }//fin for primero


                        }
                        else
                        {

                            MessageBox.Show(response.StatusCode.ToString());
                        }



                        quickbooks.Dispose();


                    }

                    //sq.rol();
                    sq.Dispose();
                }


            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show(nre.Message + response.StatusCode.ToString());

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
          


            }
        }

        private void backgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar5.Value = e.ProgressPercentage;

            label5.Text = "Cargando Empleados >> " + e.ProgressPercentage;
        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label5.Text = "empleados cargados correctamente";
            progressBar5.Style = ProgressBarStyle.Blocks;
            progressBar5.Value = progressBar5.Maximum;
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string name = "";
                Int64 estado = 0;

                using (var sq = new sql())
                {

                    //sq.conexion();

                    //sq.cadenasql = "drop table if exists terminos";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    //sq.cadenasql = "CREATE TABLE `salvador`.`terminos` ( `Id` bigint(111) NOT NULL AUTO_INCREMENT, `Nombre` VARCHAR(200) NOT NULL , `Estado` INT(11) NOT NULL , PRIMARY KEY (`Id`)) ENGINE = InnoDB;";
                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                    //sq.comando.ExecuteNonQuery();

                    using (var quickbooks = new Quickbooks())
                    {
                        quickbooks.conectar();
                        ITermsQuery TermsQueryRq = quickbooks.request.AppendTermsQueryRq();




                        IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);


                        response = respuesta.ResponseList.GetAt(0);



                        IORTermsRetList lista = response.Detail as IORTermsRetList;

                        IORTermsRet ret;

                        if (response.StatusMessage == "Status OK")
                        {

                            for (int i131 = 0; i131 < lista.Count; i131++)
                            {
                                if (lista.GetAt(i131) != null)
                                {
                                    ret = lista.GetAt(i131);

                                    if (ret.StandardTermsRet != null)
                                    {
                                        name = ret.StandardTermsRet.Name.GetValue();
                                        if (ret.StandardTermsRet.IsActive.GetValue())
                                        {
                                            estado = 1;
                                        }
                                        else{
                                            estado = 0;
                                        }

                                    }
                                    else
                                    {
                                        name = "sin datos";
                                    }

                                    





                                    //sq.cadenasql = @"insert into terminos (Nombre,Estado)values" +
                                    //    "(@name,@estado)";

                                    //sq.comando = new MySqlCommand(sq.cadenasql, sq.con);
                                    //sq.comando.Parameters.AddWithValue("@name", name);
                                    //sq.comando.Parameters.AddWithValue("@estado", estado);
                                    //sq.comando.ExecuteNonQuery();


                                }



                                backgroundWorker6.ReportProgress(i131 + 3);

                            }//fin for primero


                        }



                        quickbooks.Dispose();


                    }

                    //sq.rol();
                    sq.Dispose();
                }


            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show(nre.Message + response.StatusCode.ToString());

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
    


            }
        }

        private void backgroundWorker6_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar6.Value = e.ProgressPercentage;

            label6.Text = "Cargando Términos >> " + e.ProgressPercentage;
        }

        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label6.Text = "Términos cargados correctamente";
            progressBar6.Style = ProgressBarStyle.Blocks;
            progressBar6.Value = progressBar6.Maximum;
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
