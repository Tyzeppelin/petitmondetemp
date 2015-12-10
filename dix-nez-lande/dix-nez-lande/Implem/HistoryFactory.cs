using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    public class HistoryFactory
    {
        #region Singleton

        private static HistoryFactory _instance = null;

        private HistoryFactory()
        {
        }

        public static HistoryFactory getHistoryFactory()
        {
            if (_instance == null)
                _instance = new HistoryFactory();
            return _instance;
        }
        #endregion

        public History createHistory()
        {
            return new HistoryImpl();
        }
    }
}
