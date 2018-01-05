using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Back_End
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

            //list for total unique address count
            List<Distance_Table> total_Address = new List<Distance_Table>();

            //finding the  total  unique address 
            total_Address = originalList.GroupBy(x => x.Origin).Select(p => p.First()).Distinct().ToList();

            //removing same origin and destination calculation
            temp_Address = originalList.Where(p => p.Origin != p.Destination).ToList();

            //list to get the config properties from db
            List<ConfigOptimalRoute> optimal_ConfigList = new List<ConfigOptimalRoute>();

            //accessing the config file from config Db
            optimal_ConfigList = (from config in ec.OptimalRoute_Config
                                  select config).ToList();

            // starting address
            string OriginAddress = optimal_ConfigList[0].Name;

            // storing maximum allowed time from config Db
            int maximum_AllowedTime = optimal_ConfigList[0].Maximum_Hour * 60;

            //getting unload time from config Db
            decimal unload_Totaltime= optimal_ConfigList[0].Unload_Time;
                                 // int unloadTime_Firstpart;

            // converting the total unload time from Config Db to int
            int final_Unloadtime = Convert.ToInt32(unload_Totaltime);
            
            // variable to store the temporary total time to compare with maximum  time
            int temp_total_time = 0;

            //for getting first address from origin to nearest address
            delivery_Address = temp_Address.Where(p => p.Origin.Contains(OriginAddress)).OrderBy(c => c.Duration).Take(1).ToList();
            //finalOptimalRoute.AddRange(delivery_Address);
           
            //for calculating final totoal time
            int final_Totaltime = final_Unloadtime + delivery_Address[0].Duration;

            // storing the final total time to temp to compare with maximum time
            temp_total_time = final_Totaltime;

            //
            temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();           

            delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains(OriginAddress)).Take(1).ToList();
            temp_total_time = final_Totaltime + delivery_Address[0].Duration;

            int myfinal_Totaltime=0;


            if (temp_total_time <= maximum_AllowedTime)
            {
                int i = 1;
                while (i <= total_Address.Count - 1)
                {

                    delivery_Address = temp_Address.Where(p => p.Origin.Contains(delivery_Address[0].Destination)).OrderBy(c => c.Duration).Take(1).ToList();
                    myfinal_Totaltime = myfinal_Totaltime + delivery_Address[0].Duration + final_Unloadtime;
                    delivery_Address[0].Truck_Number = 2;



                    if (myfinal_Totaltime <= maximum_AllowedTime)
                    {                      
                        finalOptimalRoute.AddRange(delivery_Address);
                        temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();

                    }



                    else
                    {
                        //finalOptimalRoute.RemoveAt(finalOptimalRoute.Count - 1);
                        //delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains(OriginAddress)).Take(1).ToList();
                        //final_Totaltime = final_Totaltime + delivery_Address[0].Duration;
                        //finalOptimalRoute.AddRange(delivery_Address);
                        break;

                    }
                    i++;
                }
            }

            //  finalOptimalRoute.RemoveAt(finalOptimalRoute.Count - 1);

           // finalOptimalRoute.RemoveAt(finalOptimalRoute.Count - 1);
            delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains(OriginAddress)).Take(1).ToList();
            myfinal_Totaltime = myfinal_Totaltime + delivery_Address[0].Duration;

            // delivery_Address[0].Truck_Number = 2;
            finalOptimalRoute.AddRange(delivery_Address);

            return finalOptimalRoute;
        }
    }
}