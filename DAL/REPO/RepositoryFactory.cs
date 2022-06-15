using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class RepositoryFactory
    {

        

        public  static IRepoJSONDeserialize GetRepository()
        {
            return new RepositoryJSON();
        }
        
    }
}
