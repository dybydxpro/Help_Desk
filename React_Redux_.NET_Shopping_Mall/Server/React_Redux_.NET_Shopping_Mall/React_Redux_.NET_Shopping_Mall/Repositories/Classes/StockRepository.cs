using React_Redux_.NET_Shopping_Mall.Data;
using React_Redux_.NET_Shopping_Mall.Repositories.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace React_Redux_.NET_Shopping_Mall.Repositories.Classes
{
    public class StockRepository : DatabaseConfig, IStockRepository
    {
        public List<Stock> GetStock()
        {
            List<Stock> carts = new List<Stock>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getAllStock", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        foreach (DataRow dr in dt.Rows)
                        {
                            Stock val = new Stock();
                            val.Id = Convert.ToInt32(dr[0]);
                            val.ItemName = Convert.ToString(dr[1]);
                            val.Description = Convert.ToString(dr[2]);
                            val.Unit = Convert.ToString(dr[3]);
                            val.AvailableQty = Convert.ToInt32(dr[4]);
                            val.UnitPrice = Convert.ToDouble(dr[5]);
                            val.CreatedAt = Convert.ToDateTime(dr[6]);
                            val.UpdatedAt = Convert.ToDateTime(dr[7]);
                            carts.Add(val);
                        }

                        return carts;
                    }
                }
            }
            catch (Exception ex)
            {
                
                return carts;
            }
        }

        public Stock GetStockById(int id)
        {
            Stock cart = new Stock();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getStockById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);

                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt); ;

                        List<Stock> carts = new List<Stock>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            Stock val = new Stock();
                            val.Id = Convert.ToInt32(dr[0]);
                            val.ItemName = Convert.ToString(dr[1]);
                            val.Description = Convert.ToString(dr[2]);
                            val.Unit = Convert.ToString(dr[3]);
                            val.AvailableQty = Convert.ToInt32(dr[4]);
                            val.UnitPrice = Convert.ToDouble(dr[5]);
                            val.CreatedAt = Convert.ToDateTime(dr[6]);
                            val.UpdatedAt = Convert.ToDateTime(dr[7]);
                            carts.Add(val);
                        }

                        if(carts.Count > 0)
                        {
                            cart = carts[0];
                        }
                        return cart;
                    }
                }
            }
            catch (Exception ex)
            {

                return cart;
            }
        }

        public bool PostStock(StockAdd obj)
        {
            DateTime dt = DateTime.Now;
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_postStock", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
                        cmd.Parameters.AddWithValue("@Description", obj.Description);
                        cmd.Parameters.AddWithValue("@Unit", obj.Unit);
                        cmd.Parameters.AddWithValue("@AvailableQty", obj.AvailableQty);
                        cmd.Parameters.AddWithValue("@UnitPrice", obj.UnitPrice);
                        cmd.Parameters.AddWithValue("@CreatedAt", dt);
                        cmd.Parameters.AddWithValue("@UpdatedAt", dt);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        int i = cmd.ExecuteNonQuery();

                        if (i >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool PutStock(Stock obj)
        {
            DateTime dt = DateTime.Now;
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_putStock", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
                        cmd.Parameters.AddWithValue("@Description", obj.Description);
                        cmd.Parameters.AddWithValue("@Unit", obj.Unit);
                        cmd.Parameters.AddWithValue("@AvailableQty", obj.AvailableQty);
                        cmd.Parameters.AddWithValue("@UnitPrice", obj.UnitPrice);
                        cmd.Parameters.AddWithValue("@UpdatedAt", dt);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteStock(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_deleteStock", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
