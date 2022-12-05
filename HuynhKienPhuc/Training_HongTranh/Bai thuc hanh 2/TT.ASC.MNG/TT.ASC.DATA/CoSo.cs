using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public class CoSo
    {
        public int ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }

        public CoSo()
        {

        }

        public CoSo(int id, string ma)
        {
            ID = id;
            Ma = ma;
        }

        public CoSo(int id, string ma, string ten)
        {
            ID = id;
            Ma = ma;
            Ten = ten;
        }

        public void Copy(CoSo pCoSo)
        {
            ID = pCoSo.ID;
            Ma = pCoSo.Ma;
            Ten = pCoSo.Ten;
        }

        public int Compare(CoSo pCoSo)
        {
            if(this != pCoSo)
            {
                return 1;
            }
            return 0;
        }

        public virtual void Print()
        {
            Console.WriteLine("ID: {0}, Mã: {1}, Tên: {2}", ID, Ma, Ten);
        }

        public bool ValidateData()
        {
            if(Ma != null && Ten != null)
            {
                return true;
            }
            return false;
        }
    }
}
