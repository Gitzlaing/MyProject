using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.EntitiesModel;
namespace MyProject.Bll
{
   public class JobsBll :BaseBll
    {
        public List<Jobs> GetModelList()
        {
                List<Jobs> modelList = db.Jobs.ToList();
                return modelList;
        }
    }
}
