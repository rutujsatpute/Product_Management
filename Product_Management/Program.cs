using System.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Xsl;

namespace Product_Management
{

    class Product
    {
        public void addproduct(SqlConnection con)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from ProductManagement", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "ProductTable");

            var row = ds.Tables[0].NewRow();

            Console.WriteLine("Enter the Product Name: ");
            row["Product_name"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter the Product Description: ");
            row["Product_description"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter the Quantity: ");
            row["Quantity"] = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter the price of Product: ");
            row["Price"] = Convert.ToInt32(Console.ReadLine());

            ds.Tables[0].Rows.Add(row);

            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Product added successfully");
        }

        public void viewproduct(SqlConnection con)
        {
            Console.WriteLine("Enter the Product_id: ");
            int Product_id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp1 = new SqlDataAdapter($"Select * from ProductManagement Where Product_id = {Product_id}", con);
            DataSet ds = new DataSet();
            adp1.Fill(ds, "ProductTable");

            for (int i = 0; i < ds.Tables["ProductTable"].Rows.Count; i++)
            {


                for (int j = 0; j < ds.Tables["ProductTable"].Columns.Count; j++)
                {
                    Console.WriteLine($"{ds.Tables[0].Rows[i][j]} |");

                }
                Console.WriteLine();
            }
            
        }

        public void viewallproducts(SqlConnection con)
        {
            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ProductManagement", con);
            DataSet ds = new DataSet();
            adp2.Fill(ds, "ProductTable");
            for (int i = 0; i < ds.Tables["ProductTable"].Rows.Count; i++)
            {

                for (int j = 0; j < ds.Tables["ProductTable"].Columns.Count; j++)
                {
                    Console.WriteLine($"{ds.Tables[0].Rows[i][j]} |");

                }
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.WriteLine($"{ds.Tables[0].Rows.Count}");
        }

        public void updateproductdetails(SqlConnection con)
        {
            Console.WriteLine("Enter the Product id: ");
            int Product_id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp3 = new SqlDataAdapter($"Select * from ProductManagement where Product_id = {Product_id}", con);
            DataSet ds = new DataSet();
            adp3.Fill(ds, "ProductTable");

            Console.WriteLine("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Description: ");
            string descriptions = Console.ReadLine();
            Console.WriteLine("Enter the Product Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Product Price: ");
            int prc = Convert.ToInt32(Console.ReadLine());



            DateTime date = DateTime.Now;



            ds.Tables[0].Rows[0]["name"] = name;
            ds.Tables[0].Rows[0]["descriptions"] = descriptions;
            ds.Tables[0].Rows[0]["qty"] = qty;
            ds.Tables[0].Rows[0]["prc"] = prc;

            SqlCommandBuilder builder = new SqlCommandBuilder(adp3);
            adp3.Update(ds);
            Console.WriteLine("Product deatils successfully");
        }

        public void deleteproduct(SqlConnection con)
        {
            Console.WriteLine("\"Enter the product id which you want to delete: ");
            int Product_id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp4 = new SqlDataAdapter($"Select * from ProductManagement where Product_id = {Product_id}", con);

            
            DataSet ds = new DataSet();
            adp4.Fill(ds, "ProductTable");
            ds.Tables[0].Rows[0].Delete();

            SqlCommandBuilder builder = new SqlCommandBuilder(adp4);
            adp4.Update(ds);
            Console.WriteLine("Product Deleted Successfully");
        }
        internal class Program
        {

            static void Main(string[] args)
            {
                SqlConnection con = new SqlConnection("Server=IN-PF2HZG00; database=Mytable; Integrated Security=true");
                try
                {


                    Product pro = new Product();
                    string res = "";
                    do
                    {
                        Console.WriteLine("------ Welcome to Product Management App ------");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("1. Add Product");
                        Console.WriteLine("2. View Product By Id");
                        Console.WriteLine("3. View All Products");
                        Console.WriteLine("4. Update Product Details");
                        Console.WriteLine("5. Delete Product");

                        Console.WriteLine("Select the Options to Perform the Task");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    pro.addproduct(con); break;
                                }
                            case 2:
                                {
                                    pro.viewproduct(con); break;

                                }
                            case 3:
                                {
                                    pro.viewallproducts(con); break;
                                }
                            case 4:
                                {
                                    pro.updateproductdetails(con); break;
                                }
                            case 5:
                                {
                                    pro.deleteproduct(con); break;
                                }
                        }
                        Console.WriteLine("Do You want ro continue [y/n]");
                        res = Console.ReadLine();
                    } while (res == "y");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Somthing Went Wrong. Please Try Again");
                }
            }
        }
    }
}