using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmCGType.SelectedIndex = 0;
            cmbGraphType.SelectedIndex = 0;

        }

        private void btnNode_Click(object sender, EventArgs e)
        {
            // Provide the input Grid View based on the number of nodes
            int cols = Convert.ToInt32(txtNodeCount.Text); // No of nodes

            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                DataRow dr = null;
                int k = 0;
                for (int i = 0; i < cols; i++)
                {
                    k++;
                    dt.Columns.Add(new DataColumn("Node " + k, typeof(string)));
                }
                k = 0;
                dr = dt.NewRow(); // Add a single row
                dt.Rows.Add(dr);

                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;

                /* Create Columns and add for DataGridView2 */

                System.Data.DataTable dt2 = new System.Data.DataTable();
                DataRow dr2 = null;
                for (int i = 0; i < cols; i++)
                {
                    k++;
                    dt2.Columns.Add(new DataColumn("Node " + k, typeof(string)));
                }
                k = 0;

                dr2 = dt2.NewRow(); // Add a single row
                dt2.Rows.Add(dr2);

                dataGridView2.DataSource = dt2;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ReadOnly = true;

            }
            catch (Exception e1) { MessageBox.Show(e1.Message); }

        }

        private void btnCalcGraph_Click(object sender, EventArgs e)
        {
            try
            {

                int cols = Convert.ToInt32(txtNodeCount.Text); // No of nodes
                int val = 0;
                string cgType = cmCGType.SelectedItem.ToString(); // Type of Cartesian Graph
                cgType = Regex.Replace(cgType, @"\u00A0", " ");
                // Create a string array to store total weights
                string[] totalWeights = new string[cols];
                string str = null;
                int value;

                // Check whether the Input Grid values are proper, else exit
                   for (int j = 0; j < cols; j++)
                    {
                        str = dataGridView1.Rows[0].Cells[j].Value.ToString();
                        if (int.TryParse(str, out value))
                        {
                            ;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Input format! Check Input Data!");
                            return;
                        }
                    }


                if (cgType.Equals("Sequential or P Structure"))
                {

                    /* Formula  */
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        for (int i = 0; i < cols; i++)
                        {
                            if (i == 0)
                            {
                                int m = Convert.ToInt32(row.Cells[i].Value.ToString()) + Convert.ToInt32(row.Cells[i + 1].Value.ToString());
                                totalWeights[i] = m.ToString();
                            }
                            else if (i == cols - 1) //nth element
                            {
                                int m = Convert.ToInt32(row.Cells[i].Value.ToString()) + Convert.ToInt32(row.Cells[i - 1].Value.ToString());
                                totalWeights[i] = m.ToString();
                            }
                            else // intermediate element
                            {
                                int m = Convert.ToInt32(row.Cells[i - 1].Value.ToString()) + Convert.ToInt32(row.Cells[i + 1].Value.ToString()) + Convert.ToInt32(row.Cells[i].Value.ToString());
                                totalWeights[i] = m.ToString();

                            }


                            // Fill the values in DataGridView2
                        }

                    }

                    // Put the result onto DataGridView 2 
                    //var index = this.dataGridView2.Rows.Add();
                    for (int j = 0; j < cols; j++)
                    {
                        this.dataGridView2.Rows[0].Cells[j].Value = totalWeights[j];
                    }
                }

                else if (cgType == "Cyclic or C Structure")
                {
                    /* Formula  */
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        for (int i = 0; i < cols; i++)
                        {
                            if (i == 0)
                            {
                                int m = Convert.ToInt32(row.Cells[i].Value.ToString()) + Convert.ToInt32(row.Cells[i + 1].Value.ToString()) + Convert.ToInt32(row.Cells[cols - 1].Value.ToString());
                                totalWeights[i] = m.ToString();
                            }
                            else if (i == cols - 1) //nth element
                            {
                                int m = Convert.ToInt32(row.Cells[i].Value.ToString()) + Convert.ToInt32(row.Cells[i - 1].Value.ToString()) + Convert.ToInt32(row.Cells[0].Value.ToString());
                                totalWeights[i] = m.ToString();
                            }
                            else // intermediate element
                            {
                                int m = Convert.ToInt32(row.Cells[i - 1].Value.ToString()) + Convert.ToInt32(row.Cells[i + 1].Value.ToString()) + Convert.ToInt32(row.Cells[i].Value.ToString());
                                totalWeights[i] = m.ToString();

                            }


                            // Fill the values in DataGridView2
                        }

                    }

                    // Put the result onto DataGridView 2 
                    //var index = this.dataGridView2.Rows.Add();
                    for (int j = 0; j < cols; j++)
                    {
                        this.dataGridView2.Rows[0].Cells[j].Value = totalWeights[j];
                    }
                }
                else // Intertwined or K - Structure
                {

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        for (int i = 0; i < cols; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                val += Convert.ToInt32(row.Cells[j].Value.ToString());
                            }
                            totalWeights[i] = val.ToString();
                            val = 0;
                        }
                    }

                }

                // Put the result onto DataGridView 2 
                //var index = this.dataGridView2.Rows.Add();
                for (int j = 0; j < cols; j++)
                {
                    this.dataGridView2.Rows[0].Cells[j].Value = totalWeights[j];
                }


            } catch (Exception e2) { MessageBox.Show(e2.Message); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Compute Total Weights 


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInputMatrix_Click(object sender, EventArgs e)
        {
            // Provide the input Grid View based on the number of nodes
            int rows = Convert.ToInt32(txtRows.Text); // Row Count
            int cols = Convert.ToInt32(txtCols.Text); // Col Count

            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                DataRow dr = null;
                int r = 0;
                for (int i = 0; i < cols; i++)
                {
                    r++;
                    dt.Columns.Add(new DataColumn("Node" + r, typeof(string)));
                }
                r = 0;

                // Create the rows based on rowcount
                for (int k = 0; k < rows; k++)
                {
                    dr = dt.NewRow(); // Add a single row
                    dt.Rows.Add(dr);
                }

                dataGridView3.DataSource = dt;
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.AllowUserToDeleteRows = false;
                // dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                /* Create Columns and add for DataGridView2 */

                System.Data.DataTable dt2 = new System.Data.DataTable();
                DataRow dr2 = null;
                for (int i = 0; i < cols; i++)
                {
                    r++;
                    dt2.Columns.Add(new DataColumn("Node " + r, typeof(string)));
                }
                r = 0;

                for (int k = 0; k < rows; k++)
                {
                    dr2 = dt2.NewRow(); // Add a single row
                    dt2.Rows.Add(dr2);
                }

                dataGridView4.DataSource = dt2;
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.AllowUserToDeleteRows = false;
                dataGridView4.ReadOnly = true;
               // dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void btnWeights_Click(object sender, EventArgs e)
        {
            // Provide the input Grid View based on the number of nodes
            int rows = Convert.ToInt32(txtRows.Text); // Row Count
            int cols = Convert.ToInt32(txtCols.Text); // Col Count

           // MessageBox.Show("Rows: "+rows.ToString() + " Cols: " + cols.ToString());

            int val = 0, cnt=0, colVal=0; // cnt indicates row index
            string cgType = cmbGraphType.SelectedItem.ToString(); // Type of Cartesian Graph
            cgType = Regex.Replace(cgType, @"\u00A0", " ");
            // Create a string array to store total weights
            int[,] totalWeights = new int[rows, cols];
            int[] rowArrayTotal = new int[rows]; // Gives row total for each 'i'
            int[] colArrayTotal = new int[cols]; // Gives cols total for each 'i'
            string str=null;
            int value;
            
            // Check whether the Input Grid values are proper, else exit
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    str = dataGridView3.Rows[i].Cells[j].Value.ToString();
                    if (int.TryParse(str, out value))
                    {
                       ;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Input format! Check Input Data!");
                        return;
                    }
                }
            }

          
            if (cgType.Equals("Pm*Pn"))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        /*  Corner Nodes Logic */
                        // 0,0
                        if (i == 0 && j == 0)
                        {
                            // S00 + S01 + S10
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[0].Value.ToString());
                        }
                        // 0, n
                        if (i == 0 && j == cols - 1)
                        {
                            // S0 cols-1, 0 cols-2, 1 cols-1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 2].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[cols - 1].Value.ToString());
                        }
                        // m,0
                        if (i == rows - 1 && j == 0)
                        {
                            // rows-1 0, rows-2 0, rows-1 1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[1].Value.ToString());
                        }
                        // m,n
                        if (i == rows - 1 && j == cols - 1)
                        {
                            // rows-1 cols-1, rows-2 cols-1, rows-1 cols-2
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 2].Value.ToString());
                        }

                        /*  End Corner Nodes Logic */

                        /*  Edge Nodes Logic */
                        // Left Edge
                        if (j == 0 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j+1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }

                        // Right Edge
                        if (j == cols - 1 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString());
                        }

                        // Top Edge
                        if (i == 0 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i+1,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString());
                        }

                        // Bottom Edge
                        if (i == rows - 1 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i-1,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString());
                        }

                        // Middle Nodes
                        if (i > 0 && i < rows - 1 && j > 0 && j < cols - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1] + [i,j+1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }

                    }

                }
            }// end Pm*Pn

            // Start Pm*Cn
            else if (cgType.Equals("Pm*Cn"))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        /*  Corner Nodes Logic */
                        // 0,0
                        if (i == 0 && j == 0)
                        {
                            // S00 + S01 + S10 + S0 cols-1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString());
                        }
                        // 0, n
                        if (i == 0 && j == cols - 1)
                        {
                            // S0 cols-1, 0 cols-2, 1 cols-1, 0 0
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 2].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString());
                        }
                        // m,0
                        if (i == rows - 1 && j == 0)
                        {
                            // rows-1 0, rows-2 0, rows-1 1, rows-1 cols-1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString());
                        }
                        // m,n
                        if (i == rows - 1 && j == cols - 1)
                        {
                            // rows-1 cols-1, rows-2 cols-1, rows-1 cols-2, rows-1 0
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 2].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString());
                        }

                        /*  End Corner Nodes Logic */

                        /*  Edge Nodes Logic */
                        // Left Edge
                        if (j == 0 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j+1] + [i,cols-1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[cols - 1].Value.ToString());
                        }

                        // Right Edge
                        if (j == cols - 1 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1] + [i,0]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value.ToString());
                        }

                        // Top Edge
                        if (i == 0 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i+1,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString());
                        }

                        // Bottom Edge
                        if (i == rows - 1 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i-1,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString());
                        }

                        // Middle Nodes
                        if (i > 0 && i < rows - 1 && j > 0 && j < cols - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1] + [i,j+1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }
                    }
                }
            } // End Pm*Cn 


            // Start Pm*Kn
            else if (cgType.Equals("Pm*Kn"))
            {
                cnt = 0;
                val = 0;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        val += Convert.ToInt32(cell.Value);
                    }

                    //MessageBox.Show(cnt.ToString() + " : " + val.ToString());
                    rowArrayTotal[cnt] = val;
                    val = 0;
                    cnt++;
                }
                // Outside the loop reset cnt as 0 again
                cnt = 0;

                // Formula = Sum of all the nodes
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        // First row
                        if (i == 0)
                        {
                            // Row's total + [i+1,j]
                            totalWeights[i, j] = rowArrayTotal[i] + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString());
                        }
                        else if (i == rows - 1) // last row
                        {
                            // Row's total + [i-1,j]
                            totalWeights[i, j] = rowArrayTotal[i] + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString());
                        }
                        else // middle rows
                        {
                            // Row's total + [i+1,j] + [i-1,j]
                            totalWeights[i, j] = rowArrayTotal[i] + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString());
                        }
                    }
                }
            } // end Pm*Kn

            // Start Cm*Pn
            else if (cgType.Equals("Cm*Pn"))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        /*  Corner Nodes Logic */
                        // 0,0
                        if (i == 0 && j == 0)
                        {
                            // S00 + S01 + S10 + S rows-1 0
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString());
                        }
                        // 0, n
                        if (i == 0 && j == cols - 1)
                        {
                            // S0 cols-1, 0 cols-2, 1 cols-1, rows-1 cols-1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 2].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString());
                        }
                        // m,0
                        if (i == rows - 1 && j == 0)
                        {
                            // rows-1 0, rows-2 0, rows-1 1, 0 0
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString());
                        }
                        // m,n
                        if (i == rows - 1 && j == cols - 1)
                        {
                            // rows-1 cols-1, rows-1 cols-2, rows-2 cols-1, 0 cols-1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 2].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString());
                        }

                        /*  End Corner Nodes Logic */

                        /*  Edge Nodes Logic */
                        // Left Edge
                        if (j == 0 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j+1] 
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }

                        // Right Edge
                        if (j == cols - 1 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1] 
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString());
                        }

                        // Top Edge
                        if (i == 0 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i+1,j] + [rows-1,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[j].Value.ToString());
                        }

                        // Bottom Edge
                        if (i == rows - 1 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i-1,j] + [0,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[j].Value.ToString());
                        }

                        // Middle Nodes
                        if (i > 0 && i < rows - 1 && j > 0 && j < cols - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1] + [i,j+1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }
                    }
                }
            } // End Cm*Pn

            // Start Cm*Cn
            else if (cgType.Equals("Cm*Cn"))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        /*  Corner Nodes Logic */
                        // 0,0
                        if (i == 0 && j == 0)
                        {
                            // 0 0 + 0 1 + 1 0 +  rows-1 0 +  0 cols-1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString());
                        }
                        // 0, n
                        if (i == 0 && j == cols - 1)
                        {
                            // S0 cols-1, 0 cols-2, 1 cols-1, rows-1 cols-1, 0 0
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 2].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString());
                        }
                        // m,0
                        if (i == rows - 1 && j == 0)
                        {
                            // rows-1 0, rows-2 0, rows-1 1, 0 0, rows-1 cols-1
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString());
                        }
                        // m,n
                        if (i == rows - 1 && j == cols - 1)
                        {
                            // rows-1 cols-1, rows-1 cols-2, rows-2 cols-1, 0 cols-1, rows-1 0
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[cols - 2].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 2].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[cols - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[0].Value.ToString());
                        }

                        /*  End Corner Nodes Logic */

                        /*  Edge Nodes Logic */
                        // Left Edge
                        if (j == 0 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j+1] + [i,cols-1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[cols - 1].Value.ToString());
                        }

                        // Right Edge
                        if (j == cols - 1 && i != 0 && i != rows - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1] + [i,0]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value.ToString());
                        }

                        // Top Edge
                        if (i == 0 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i+1,j] + [rows-1,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[j].Value.ToString());
                        }

                        // Bottom Edge
                        if (i == rows - 1 && j != 0 && j != cols - 1)
                        {
                            // [i,j] + [i,j-1] + [i,j+1] + [i-1,j] + [0,j]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[j].Value.ToString());
                        }

                        // Middle Nodes
                        if (i > 0 && i < rows - 1 && j > 0 && j < cols - 1)
                        {
                            // [i,j] + [i-1,j] + [i+1,j] + [i,j-1] + [i,j+1]
                            totalWeights[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }
                    }
                }
            } // End Cm*Cn

            // Start Cm*Kn
            else if (cgType.Equals("Cm*Kn"))
            {
                //cnt = 0;
                val = 0;
                // Calculate rowwise summation 
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        val += Convert.ToInt32(cell.Value);
                    }

                    // MessageBox.Show(val.ToString());
                    rowArrayTotal[cnt] = val;
                    val = 0;
                    cnt++;
                }
                // Outside the loop reset cnt as 0 again
                cnt = 0;
               
                // Formula = Sum of all the nodes
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        // First row
                        if (i == 0)
                        {
                            // Row's total + [i+1,j] + [row-1,j]
                            totalWeights[i, j] = rowArrayTotal[i] + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[rows - 1].Cells[j].Value.ToString());
                        }
                        else if (i == rows - 1) // last row
                        {
                            // Row's total + [i-1,j] + [0,j]
                            totalWeights[i, j] = rowArrayTotal[i] + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[0].Cells[j].Value.ToString());
                        }
                        else // middle rows
                        {
                            // Row's total + [i+1,j] + [i-1,j]
                            totalWeights[i, j] = rowArrayTotal[i] + Convert.ToInt32(dataGridView3.Rows[i + 1].Cells[j].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i - 1].Cells[j].Value.ToString());
                        }
                    }
                }
            } // end Cm*Kn

            // Start Km*Pn
            else if (cgType.Equals("Km*Pn"))
            {
                colVal = 0; 
                val = 0;
                //Calculate Column totals and put into Array
                for (int j = 0; j < cols; j++)
                {
                    colVal = j;
                    for (int i = 0; i < rows; i++)
                    {
                        val+= Convert.ToInt32(this.dataGridView3.Rows[i].Cells[colVal].Value);
                    }
                    colArrayTotal[j] = val;
                    val = 0; //reset val to 0
                }

                // Formula = Sum of all the nodes
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        // First Column
                        if (j == 0)
                        {
                            // Column's total + [i,j+1] 
                            totalWeights[i, j] = colArrayTotal[j] + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }
                        else if (j == cols - 1) // last column
                        {
                            // Column's total + [i,j-1] 
                            totalWeights[i, j] = colArrayTotal[j] + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString());
                        }
                        else // middle rows
                        {
                            // Columns's total + [i,j-1] + [i,j+1]
                            totalWeights[i, j] = colArrayTotal[j] + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }
                    }
                }

            } // End Km*Pn

            // Start Km*Cn
            else if (cgType.Equals("Km*Cn"))
            {
                colVal = 0;
                val = 0;
                //Calculate Column totals and put into Array
                for (int j = 0; j < cols; j++)
                {
                    colVal = j;
                    for (int i = 0; i < rows; i++)
                    {
                        val += Convert.ToInt32(this.dataGridView3.Rows[i].Cells[colVal].Value);
                    }
                    colArrayTotal[j] = val;
                    val = 0; //reset val to 0
                }

                // Formula = Sum of all the nodes
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        // First Column
                        if (j == 0)
                        {
                            // Column's total + [i,j+1] + [i, cols-1]
                            totalWeights[i, j] = colArrayTotal[j] + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[cols-1].Value.ToString());
                        }
                        else if (j == cols - 1) // last column
                        {
                            // Column's total + [i,j-1] + [i,0]
                            totalWeights[i, j] = colArrayTotal[j] + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value.ToString());
                        }
                        else // middle rows
                        {
                            // Columns's total + [i,j-1] + [i,j+1]
                            totalWeights[i, j] = colArrayTotal[j] + Convert.ToInt32(dataGridView3.Rows[i].Cells[j - 1].Value.ToString()) + Convert.ToInt32(dataGridView3.Rows[i].Cells[j + 1].Value.ToString());
                        }
                    }
                }

            } // End Km*Cn


            // Start Km*Kn
            else // It is Km*Kn
            {
                val = 0;
                // Summate each cell value in the Grid and assign to each cell
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        val += Convert.ToInt32(cell.Value);
                    }
                }
                
                // Populate each cell with "Val" value
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        totalWeights[i, j] = val;
;                    }
                }

            } // End Km*Kn

            // Populate DataGrdiView4 with final values
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.dataGridView4.Rows[i].Cells[j].Value = totalWeights[i, j].ToString();
                }
            }


        } // End Method

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRows.Text) || String.IsNullOrEmpty(txtCols.Text))
            {
                MessageBox.Show("Enter the Data before exporting to excel");
                return;
            }

            // Provide the input Grid View based on the number of nodes
                int rows = Convert.ToInt32(txtRows.Text); // Row Count
                int cols = Convert.ToInt32(txtCols.Text); // Col Count

                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                app.DefaultSaveFormat = XlFileFormat.xlOpenXMLWorkbook;
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from Gridview";
                         
            try
            {
                // storing header part in Excel 
                for (int i = 0; i < cols; i++)
                {
                    worksheet.Cells[1, 1] = dataGridView3.Columns[i].HeaderText;
                }

                worksheet.Cells[1, 1] = "Input Data";
                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Merge();

                // Input Data
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = this.dataGridView3.Rows[i].Cells[j].Value.ToString();
                    }
                }

                worksheet.Cells[rows + 2, 1] = "Output Data";
                worksheet.Range[worksheet.Cells[rows + 2, 1], worksheet.Cells[rows + 2, 2]].Merge();
                // Output Data
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        worksheet.Cells[i + rows + 3, j + 1] = this.dataGridView4.Rows[i].Cells[j].Value.ToString();
                    }
                }

                workbook.Application.Visible = true;

                // save the application  
                /* workbook.Saved = true;
                 workbook.SaveAs("d:\\output.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Type.Missing, Type.Missing, Type.Missing);
                 //workbook.SaveAs(@"c:\\output.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                 workbook.Close(null, null, null);
                 app.Workbooks.Close();
                 //workbook.SaveAs("c:\\output.xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                 // Exit from the application  */
                //workbook.Close(0);
                //app.Quit();
            } // end try

            finally
            {
                // Close the open workbook
                app.Workbooks.Close();
                app.Quit();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lblNodeCount_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtNodeCount.Text))
            {
                MessageBox.Show("Enter the Data before exporting to excel");
                return;
            }
            
            // Provide the input Grid View based on the number of nodes
            int cols = Convert.ToInt32(txtNodeCount.Text); // Col Count

            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            app.DefaultSaveFormat = XlFileFormat.xlOpenXMLWorkbook;
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from Gridview";
            // storing header part in Excel  

            try
            {
                for (int i = 0; i < cols; i++)
                {
                    worksheet.Cells[1, 1] = dataGridView1.Columns[i].HeaderText;
                }

                worksheet.Cells[1, 1] = "Input Data";
                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Merge();

                // Input Data
                for (int j = 0; j < cols; j++)
                {
                    worksheet.Cells[2, j + 1] = this.dataGridView1.Rows[0].Cells[j].Value.ToString();
                }


                worksheet.Cells[3, 1] = "Output Data";
                worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]].Merge();
                // Output Data
                for (int j = 0; j < cols; j++)
                {
                    worksheet.Cells[4, j + 1] = this.dataGridView2.Rows[0].Cells[j].Value.ToString();
                }


                workbook.Application.Visible = true;
            }
            
            finally
            {
                // Close the open workbook
                app.Workbooks.Close();
                app.Quit();
            }

        }

        private void txtNodeCount_TextChanged(object sender, EventArgs e)
        {

        }
    } // End Partial Class
} // End Namespace