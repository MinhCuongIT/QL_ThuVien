using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class DBConection
    {
        protected SqlConnection connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QL_ThuVien;Integrated Security=True");
    }
}
