using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaBang
{
    class DaBangHelper
    {
        char[] bangchucai = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'r', 'u', 'o', 's', 'p', 'i', 'h', 'k', 'l', 'n', 'm', 't', 'q', 'y', 'v', 'x' };
        char[,] bangtra;
        public String khoa { get; set; }
        public DaBangHelper()
        {
            bangtra = new char[bangchucai.Length, bangchucai.Length];
            for (int i = 0; i < bangchucai.Length; i++)
                for (int j = 0; j < bangchucai.Length; j++)
                    bangtra[i, j] = bangchucai[(i + j) % bangchucai.Length];
        }
        public String MaHoa(String value)
        {
            //sinh khoá
            Random rd = new Random();
            for (int i = 0; i < value.Length; i++)
                khoa += bangchucai[rd.Next(0, bangchucai.Length - 1)];
            //mã hoá
            String result = "";
            for (int i = 0; i < value.Length; i++)
            {
                int vitri = -1;
                for (int j = 0; j < bangchucai.Length; j++)
                {
                    if (bangchucai[j].ToString().Equals(value[i].ToString()))
                    {
                        vitri = j;
                        break;
                    }
                }
                if (vitri == -1)
                    result += value[i].ToString();
                else
                {
                    int vitrikhoa = 0;
                    for (int j = 0; j < bangchucai.Length; j++)
                    {
                        if (bangchucai[j].ToString().Equals(khoa[i].ToString()))
                        {
                            vitrikhoa = j;
                            break;
                        }
                    }
                    result += bangtra[vitri, vitrikhoa];
                }
            }
            return result;
        }
        public String GiaiMa(String value, String key)
        {
            String result = "";
            for (int i = 0; i < value.Length; i++)
            {
                int vitri = -1;
                for (int j = 0; j < bangchucai.Length; j++)
                {
                    if (bangchucai[j].ToString().Equals(value[i].ToString()))
                    {
                        vitri = j;
                        break;
                    }
                }
                if (vitri == -1)
                    result += value[i].ToString();
                else
                {
                    // xác định ký tự khoá tại vị trí i
                    char ktkhoa = key[i];
                    // xác định vị trí khoá trong bảng chữ cái 
                    int vitrikhoa = 0;
                    for (int j = 0; j < bangchucai.Length; j++)
                    {
                        if (bangchucai[j].Equals(ktkhoa))
                        {
                            vitrikhoa = j;
                            break;
                        }
                    }
                    // tìm trong hàng hoặc cột thứ (vị trí khoá) ở bảng tra xem giá trị cần giải mã ở vị trí nào
                    // thì giá trị giải mã được là ký tự ở vị trí đó trong bảng chữ cái
                    int vitrigiaima = 0;
                    for (int j = 0; j < bangchucai.Length; j++)
                    {
                        if (bangtra[vitrikhoa, j].Equals(value[i]))
                        {
                            vitrigiaima = j;
                            break;
                        }
                    }
                    result += bangchucai[vitrigiaima];
                }
            }
            return result;
        }
    }
    
}
