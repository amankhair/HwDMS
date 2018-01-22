using WpfDMS.DAL;

namespace WpfDMS.BAL
{
    public class Methods<T>
    {
        DmsDB db = new DmsDB();

        public object o { get; set; }
        public T s { get; set; }


    }

}
