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

        public List<Distance_Table> FindOptimalRoute()
        {
            List<Distance_Table> originalList = new List<Distance_Table>();

            EntitiesContext ec = new EntitiesContext();
            originalList = (from cust in ec.Distances
                            orderby cust.Id
                            select cust).ToList();

            List<Distance_Table> finalOptimalRoute = new List<Distance_Table>();
            List<Distance_Table> delivery_Address = new List<Distance_Table>();
            List<Distance_Table> temp_Address = new List<Distance_Table>();
            List<Distance_Table> total_Address = new List<Distance_Table>();

            total_Address = originalList.GroupBy(x => x.Origin).Select(p => p.First()).Distinct().ToList();
            temp_Address = originalList.Where(p => p.Origin != p.Destination).ToList();

            List<ConfigOptimalRoute> optimal_ConfigList = new List<ConfigOptimalRoute>();
            optimal_ConfigList = (from config in ec.OptimalRoute_Config
                       select config).ToList();

            int maximum_AllowedTime = optimal_ConfigList[0].Maximum_Hour * 60;
            decimal unload_Totaltime = optimal_ConfigList[0].Unload_Time;
            int unloadTime_Firstpart;

            int final_Unloadtime =GetUnloadTime(unload_Totaltime, out unloadTime_Firstpart);
            int temp_total_time = 0;

            delivery_Address = temp_Address.Where(p => p.Origin.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).OrderBy(c => c.Duration).Take(1).ToList();
           int final_Totaltime = final_Unloadtime + delivery_Address[0].Duration ;
           temp_total_time = final_Totaltime;
           temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();

            delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).Take(1).ToList();
            temp_total_time = final_Totaltime + delivery_Address[0].Duration;

            if (temp_total_time <= maximum_AllowedTime)
            {
                int i = 1;
                while (i <= total_Address.Count - 2)
                {

                    delivery_Address = temp_Address.Where(p => p.Origin.Contains(delivery_Address[0].Destination)).OrderBy(c => c.Duration).Take(1).ToList();
                    final_Totaltime = final_Totaltime + delivery_Address[0].Duration + final_Unloadtime;

                    if (final_Totaltime <= maximum_AllowedTime)
                    {
                        finalOptimalRoute.AddRange(delivery_Address);
                        temp_Address = temp_Address.Where(p => p.Destination != delivery_Address[0].Origin).OrderBy(c => c.Duration).ToList();
                    }
                    else
                    {
                        delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).Take(1).ToList();
                        final_Totaltime = final_Totaltime + delivery_Address[0].Duration;
                        finalOptimalRoute.AddRange(delivery_Address);
                    }
                    i++;
                }
            }

            delivery_Address = originalList.Where(p => p.Origin.Contains(delivery_Address[0].Destination) && p.Destination.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).Take(1).ToList();
            final_Totaltime = final_Totaltime + delivery_Address[0].Duration;
            finalOptimalRoute.AddRange(delivery_Address);

            return finalOptimalRoute;
        }
    }
}