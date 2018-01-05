using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace Back_End.Data.Entities
{
    public class TryTest
    {
        private EntitiesContext ec;

        public TryTest(EntitiesContext context)

        {
            ec = context;
        }
        

        public void InsertArticle(Article article)
        {
            if (article != null)
            {
                // EntitiesContext ec = new EntitiesContext(); 

                ec.Article.Add(article);
                ec.SaveChanges();

            }

            else
            {
                MyCustomErrorDetail customError = new MyCustomErrorDetail("Correct customer details not found","Please check all the customer fields entered are of correct type!");
                throw new WebFaultException<MyCustomErrorDetail>(customError, HttpStatusCode.NotFound);
                            }

        }
    }
}