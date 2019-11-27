using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLib
{
    public class Map
    {
        private List<Case> mapContent= new List<Case>();

        public Map()
        {

        }
        public Map(List<Case> mapContent)
        {
            this.mapContent = mapContent;
        }

        public void generateMap(int levelID)
        {
            if (levelID == 0)
            {
                voidCase caseVoid = new voidCase();
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                      mapContent.Add(caseVoid);  
                    }
                }
            }
        }

        public List<Case> MapContent
        {
            get { return mapContent; }
        }
    }


    public class Case
    {

        private string caseType;
        public Case()
        {
        }

        public string CaseType
        {
            get { return caseType; }
            set { caseType = value; }
        }

    }
    public class voidCase : Case
    {
        public voidCase(string caseType = "void") : base()
        {
            this.CaseType = caseType;
        }
    }
    public class solidCase : Case
    {
 
        public solidCase(string caseType = "solid") : base()
        {
            this.CaseType = caseType;
        }
    }
    


    
}
