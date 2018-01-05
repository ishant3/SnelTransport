using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_Database_Connection
{
    public class OptimalRouteAlgorithm
    {


        public int GetUnloadTime(decimal number, out int firstpart)
        {
            firstpart = (int)Math.Truncate(number);
            int secondpart = (int)Math.Round(100 * Math.Abs(number - firstpart));
            int total;

            if (firstpart == 0)
            {
                total = secondpart;
                return total;
            }
            else
            {
                return total = firstpart * 60 + secondpart;
            }
        }

        //public List<Distance_Table> CalculateRoute(ref List<Distance_Table> temp_Address, ref List<Distance_Table> originalList1, ref List<Distance_Table> delivery_Address1, ref List<Distance_Table> total_Address1, ref string OriginAddress1,ref int final_Unloadtime1)
        //{
            
        //    List<Distance_Table> originalList = new List<Distance_Table>();
        //    originalList = originalList1;

        //    List<Distance_Table> delivery_Address = new List<Distance_Table>();
        //    delivery_Address = delivery_Address1;

        //    List<Distance_Table> total_Address = new List<Distance_Table>();
        //    total_Address = total_Address1;

        //    List<Distance_Table> finalOptimalRoute = new List<Distance_Table>();



        //    string OriginAddress=OriginAddress1;

        //    int final_Unloadtime= final_Unloadtime1;
        //    int temp_total_time = 0;
        //    int maximum_AllowedTime = 0;
        //    int mytruck_Number = 0;

        //    //for getting first address from origin to nearest address
        //    delivery_Address = temp_Address.Where(p => p.Origin.Contains(OriginAddress)).OrderBy(c => c.Duration).Take(1).ToList();
        //    //finalOptimalRoute.AddRange(delivery_Address);

        //    //for calculating final totoal time
        //    int final_Totaltime = final_Unloadtime + delivery_Address[0].Duration;

        //    // storing the final total time to temp to compare with maximum time
        //    temp_total_time = final_Totaltime;

        //    temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();

        //    delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains(OriginAddress)).Take(1).ToList();
        //    //temp_total_time = final_Totaltime + delivery_Address[0].Duration;

        //    int myfinal_Totaltime = 0;

        //    int i = 1;
        //    while (i <= total_Address.Count - 1)
        //    {
        //        if (myfinal_Totaltime <= maximum_AllowedTime)
        //        {
        //            delivery_Address = temp_Address.Where(p => p.Origin.Contains(delivery_Address[0].Destination)).OrderBy(c => c.Duration).Take(1).ToList();
        //            myfinal_Totaltime = myfinal_Totaltime + delivery_Address[0].Duration + final_Unloadtime;
        //            delivery_Address[0].Truck_Number = mytruck_Number;
        //            finalOptimalRoute.AddRange(delivery_Address);
        //            temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();

        //        }

        //        i++;
        //    }

        //    finalOptimalRoute.Remove(finalOptimalRoute.Last());
        //    delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Origin) && p.Destination.Contains(OriginAddress)).Take(1).ToList();
        //    myfinal_Totaltime = myfinal_Totaltime + delivery_Address[0].Duration;

        //    delivery_Address[0].Truck_Number = mytruck_Number;
        //    finalOptimalRoute.AddRange(delivery_Address);

        
        //        return finalOptimalRoute;
        //}



        public List<Distance_Table> FindOptimalRoute()
        {
            // list for storing the all the calcuated route options from google distance matrix
            List<Distance_Table> originalList = new List<Distance_Table>();

            //for accessing data from db
            EntitiesContext ec = new EntitiesContext();

            // query to get all the distance matrix from db
            originalList = (from cust in ec.Distances
                            orderby cust.Id
                            select cust).ToList();

            // list to store final outcome of optimal route address..
            List<Distance_Table> finalOptimalRoute = new List<Distance_Table>();

            // list used during calculation..............
            List<Distance_Table> delivery_Address = new List<Distance_Table>();

            // list to store address without same origin and destination address
            List<Distance_Table> temp_Address = new List<Distance_Table>();
            List<Distance_Table> temp_Address1 = new List<Distance_Table>();

            //list for total unique address count
            List<Distance_Table> total_Address = new List<Distance_Table>();

            //finding the  total  unique address 
            total_Address = originalList.GroupBy(x => x.Origin).Select(p => p.First()).Distinct().ToList();

            //removing same origin and destination calculation

            List<Distance_Table> temp_AddressPermanent = new List<Distance_Table>();
            temp_AddressPermanent = originalList.Where(p => p.Origin != p.Destination).ToList();

            temp_Address = temp_AddressPermanent;

            //list to get the config properties from db
            List<ConfigOptimalRoute> optimal_ConfigList = new List<ConfigOptimalRoute>();

            //accessing the config file from config Db
            optimal_ConfigList = (from config in ec.OptimalRoute_Config
                                  select config).ToList();

            //truck number from config Db
            int mytruck_Number = optimal_ConfigList[0].Truck_Number;

            // starting address
            string OriginAddress = optimal_ConfigList[0].Name;

            // storing maximum allowed time from config Db
            int maximum_AllowedTime = optimal_ConfigList[0].Maximum_Hour * 60;

            //getting unload time from config Db
            decimal unload_Totaltime = optimal_ConfigList[0].Unload_Time;
            // int unloadTime_Firstpart;

            // converting the total unload time from Config Db to int
            int final_Unloadtime = Convert.ToInt32(unload_Totaltime);

            // variable to store the temporary total time to compare with maximum  time
            int temp_total_time = 0;




           // CalculateRoute(temp_Address, originalList, delivery_Address,);

            if (mytruck_Number == 1)   
            {

                //for getting first address from origin to nearest address
                delivery_Address = temp_Address.Where(p => p.Origin.Contains(OriginAddress)).OrderBy(c => c.Duration).Take(1).ToList();
                //finalOptimalRoute.AddRange(delivery_Address);

                //for calculating final totoal time
                int final_Totaltime = final_Unloadtime + delivery_Address[0].Duration;

                // storing the final total time to temp to compare with maximum time
                temp_total_time = final_Totaltime;

                temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();

                delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains(OriginAddress)).Take(1).ToList();
                //temp_total_time = final_Totaltime + delivery_Address[0].Duration;

                int myfinal_Totaltime = 0;

                int i = 1;
                while (i <= total_Address.Count - 1)
                {
                    if (myfinal_Totaltime <= maximum_AllowedTime)
                    {
                        delivery_Address = temp_Address.Where(p => p.Origin.Contains(delivery_Address[0].Destination)).OrderBy(c => c.Duration).Take(1).ToList();
                        myfinal_Totaltime = myfinal_Totaltime + delivery_Address[0].Duration + final_Unloadtime;
                        delivery_Address[0].Truck_Number = mytruck_Number;
                        finalOptimalRoute.AddRange(delivery_Address);
                        temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();

                    }

                    i++;
                }

                finalOptimalRoute.Remove(finalOptimalRoute.Last());
                delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Origin) && p.Destination.Contains(OriginAddress)).Take(1).ToList();
                myfinal_Totaltime = myfinal_Totaltime + delivery_Address[0].Duration;

                delivery_Address[0].Truck_Number = mytruck_Number;
                finalOptimalRoute.AddRange(delivery_Address);

            }


                return finalOptimalRoute;
            }
        
    }
}