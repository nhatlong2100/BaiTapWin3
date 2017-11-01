using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyObject
{
    public class PrimeProxy : MarshalByRefObject
    {
        //Biến lưu số lần client gọi hàm lấy danh sách số nguyên tố
        private int m_RequestNumber = 0;
        //Biến lưu tên client hiện tại gọi hàm
        private string m_strCurrentClient = "";
        //Biến lưu danh sách client đã connect
        private List<string> m_listClient = new List<string>();

        /// <summary>
        /// Kiểm tra số nguyên tố
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool isPrime(int k)
        {
            if (k < 2) return false;
            for (int i = 2; i <= Math.Sqrt(k); i++)
                if (k % 2 == 0)
                    return false;
                else
                    return true;
            return true;
        }

        /// <summary>
        /// Thiết lập client hiện tại connect tới server
        /// và lưu tên vào danh scah1
        /// </summary>
        /// <param name="clientName"></param>
        public void setConnectClient(string clientName)
        {
            m_strCurrentClient = clientName;
            if (!m_listClient.Contains(clientName))
                m_listClient.Add(clientName);
        }

        /// <summary>
        /// Hàm trả về danh sách các số ngto
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<int> getListPrime(int n)
        {
            m_RequestNumber++;
            List<int> lst = new List<int>();
            lst.Clear();
            for (int i = 2; i <= n; i++)
                if (isPrime(i))
                    lst.Add(i);
            return lst;
        }

        public int RequestNumber
        {
            get { return this.m_RequestNumber; }
        }
        public string CurrentClient
        {
            get { return this.m_strCurrentClient; }
        }
        public List<string> ListClient
        {
            get { return this.m_listClient; }
        }
    }
}
