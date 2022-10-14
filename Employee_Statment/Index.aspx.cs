using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace Employee_Statment
{
    public partial class Index : System.Web.UI.Page
    {
       
        

       
        protected void Page_Load(object sender, EventArgs e)
        {
            Panelstatment.Visible = false;
            //Panelfinal.Visible = false;

            if (!Page.IsPostBack)
            {
                DropDownPosition.Items.Add(new ListItem("Select the position",""));
                DropDownPosition.Items.Add(new ListItem("Help desk","20"));
                DropDownPosition.Items.Add(new ListItem("Technician","25"));
                DropDownPosition.Items.Add(new ListItem("Enginier","35"));
                DropDownPosition.Items.Add(new ListItem("Developer","45"));
                DropDownPosition.SelectedIndex = 0;

            }
            //if(DropDownPosition.SelectedIndex>0)
            //{
            //    Panelstatment.Visible = true;
            //    Calcul();
            //}
            

        }
        private void Calcul()
        {
            Decimal hour = 0, rate = 0, tax =0, salbr = 0, salnet = 0;
            string name = "", position = "";
            DateTime dt ;
            
            name = TextBoxName.Text;
            position = DropDownPosition.SelectedItem.Text;
            
            rate = Convert.ToDecimal(DropDownPosition.SelectedItem.Value);
           
            hour = Convert.ToDecimal(TextBoxtotalhour.Text) ;
            salbr = hour * rate;
            tax = (salbr * 15) / 100;
            salnet = salbr - tax;
            dt = Convert.ToDateTime(TextBoxDate.Text);
            Literal1.Text = "<br><b>Name = <b>" + name + "</br>";
            Literal1.Text += "<br><b>Priod = <b>" + dt + "</br>";
            Literal1.Text += "<br><b>Position = <b>" + position + "</br>";
            Literal1.Text += "<br><b>Total Hours = <b>" + hour + "</br>";
            Literal1.Text += "<br><b>Salery Brut = <b>" + salbr + "</br>";
            Literal1.Text += "<br><b>Total TAX = <b>" + tax + "</br>";
            Literal1.Text += "<br><b>Salery Net = <b>" + salnet + "</br>";
            
            



        }
        private void Info()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "select count(name) as totala from TableForEmployee ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sqlDataReader;
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Literal2.Text = "<br><b>Rows = <b>" + sqlDataReader["totala"].ToString() + "</br>";
                }
                sqlDataReader.Close();
                string queryb = "select sum(sbrut) as tot from TableForEmployee ";
                SqlCommand cmdb = new SqlCommand(queryb, con);
                SqlDataReader sqlDataReaderb;
                sqlDataReaderb = cmdb.ExecuteReader();
                while (sqlDataReaderb.Read())
                {
                    Literal2.Text += "<br><b>Salar brut = <b>" + sqlDataReaderb["tot"].ToString() + "</br>";
                }
                sqlDataReaderb.Close();
                string querya = "select sum(tax) as totalaa from TableForEmployee ";
                SqlCommand cmda = new SqlCommand(querya, con);
                SqlDataReader sqlDataReadera;
                sqlDataReadera = cmda.ExecuteReader();
                while (sqlDataReadera.Read())
                {
                    Literal2.Text += "<br><b>total tax = <b>" + sqlDataReadera["totalaa"].ToString() + "</br>";
                }
                sqlDataReadera.Close();
                string querybb = "select sum(snet) as totn from TableForEmployee ";
                SqlCommand cmdbb = new SqlCommand(querybb, con);
                SqlDataReader sqlDataReaderbb;
                sqlDataReaderbb = cmdbb.ExecuteReader();
                while (sqlDataReaderbb.Read())
                {
                    Literal2.Text += "<br><b>Salar net = <b>" + sqlDataReaderbb["totn"].ToString() + "</br>";
                }
                sqlDataReaderbb.Close();
                con.Close();
            }

        }
        void Clear()
        {
            TextBoxtotalhour.Text = TextId.Text = TextBoxName.Text = "";
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            Decimal hour = 0, rate = 0, tax = 0, salbr = 0, salnet = 0;
            string name = "", position = "", dtime = "";
            foreach (ListItem item in DropDownPosition.Items)
            {
                rate += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
                if (item.Selected)
                {
                    position += DropDownPosition.SelectedIndex.ToString(item.Text);
                }
            }
            hour = Convert.ToDecimal(TextBoxtotalhour.Text);
            salbr = hour * rate;
            tax = (salbr * 15) / 100;
            salnet = salbr - tax;
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Insert into TableForEmployee( empid,name,position,date,thours,sbrut,tax,snet) values( @empid,@name,@position,@date,@thours,@sbrut,@tax,@snet)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@empid",TextId.Text);
                cmd.Parameters.AddWithValue("@name", TextBoxName.Text);
                cmd.Parameters.AddWithValue("@position", DropDownPosition.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@date",Convert.ToDateTime( TextBoxDate.Text));
                cmd.Parameters.AddWithValue("@thours", TextBoxtotalhour.Text);
                cmd.Parameters.AddWithValue("@sbrut", Convert.ToDecimal(salbr));
                cmd.Parameters.AddWithValue("@tax", Convert.ToDecimal(tax));
                cmd.Parameters.AddWithValue("@snet", Convert.ToDecimal(salnet));
                cmd.ExecuteNonQuery();
                Response.Write("<Script language 'javascript'>alert('Data successfuly insert in database')</script>");
            }
           
            
        }
        void Grid()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                
                string query = "Select * from TableForEmployee";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                cmd.Connection = con;
                con.Open();
                sqlDataAdapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                con.Close();
            }
        }

        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            Grid();
        }
        void Delete()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Delete from TableForEmployee Where /*name=*/id='" + Convert.ToInt32(TextId.Text) +"'" /*'"+TextBoxName.Text+"'"*/;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Response.Write("<Script language 'javascript'>alert('Data successfuly deleted from database')</script>");


            }

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Delete();

        }
        void Search()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                string query = "Select * from TableForEmployee where name='" + TextBoxName.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                cmd.Connection = con;
                con.Open();
                sqlDataAdapter.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@name", TextBoxName.Text);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                con.Close();
            }

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        void Update()
        {
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                string query = "update TableForEmployee set date='" + Convert.ToDateTime(TextBoxDate.Text) + "' ,position='" + DropDownPosition.SelectedItem.ToString()  + "'  ," +
                    "thours='" + Convert.ToDecimal(TextBoxtotalhour.Text) + "',sbrut='" + Convert.ToDecimal(TextBoxtotalhour.Text)*Convert.ToDecimal(DropDownPosition.SelectedValue) + "'," +
                    "tax='" + (Convert.ToDecimal(TextBoxtotalhour.Text) * Convert.ToDecimal(DropDownPosition.SelectedValue))*15/100 + "'," +
                    "snet='"+Convert.ToDecimal( Convert.ToDecimal(TextBoxtotalhour.Text) * Convert.ToDecimal(DropDownPosition.SelectedValue) - (Convert.ToDecimal(TextBoxtotalhour.Text) * Convert.ToDecimal(DropDownPosition.SelectedValue)) * 15 / 100) + "' " +
                    " where id='"+Convert.ToInt32 (TextId.Text)+"'/*name='" + TextBoxName.Text + "'*/ ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<Script language 'javascript'>alert('Data successfuly update in database')</script>");
                con.Close();
            }

        }

        protected void ButtonUpDate_Click(object sender, EventArgs e)
        {
            Update();
        }
       

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
           
        }
        int c = 0;
        decimal th = 0;
        decimal tsb = 0;
        decimal ttx = 0;
        decimal tsn = 0;

        public Color Col { get; private set; }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                c++;
                th += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "thours"));
                tsb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "sbrut"));
                ttx += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "tax"));
                tsn += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "snet"));


                if (Convert.ToDecimal(e.Row.Cells[5].Text) > 70)
                {
                    e.Row.BackColor = Color.Red;
                }
                else
                {
                    e.Row.BackColor = Color.Gray;
                }
                DateTime dateTime;
                if (DateTime.TryParse(e.Row.Cells[4].Text, out dateTime))
                {
                    if (dateTime > DateTime.Now)
                    {
                        e.Row.Cells[4].BackColor = Color.PowderBlue;
                    }

                }
            }
            

             else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = string.Format("Total Items=", c);
                e.Row.Cells[1].Text = string.Format("{0}", c);
                e.Row.Cells[04].Text = string.Format("Total =", c);
                e.Row.Cells[05].Text = string.Format("{0}", th);
                e.Row.Cells[06].Text = string.Format("{0}", tsb);
                e.Row.Cells[07].Text = string.Format("{0}", ttx);
                e.Row.Cells[08].Text = string.Format("{0}", tsn);
               



            }



            

        }

        protected void Buttoncon_Click(object sender, EventArgs e)
        {
            if (Buttoncon.Enabled)
            {
                Panelstatment.Visible = true;
                Calcul();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Buttoninfo_Click(object sender, EventArgs e)
        {
            
            if (Buttoninfo.Enabled)
            {
                Panelfinal.Visible = true;
                Info();
            }
            
        }
    }
}