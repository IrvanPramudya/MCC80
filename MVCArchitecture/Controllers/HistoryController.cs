using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    class HistoryController
    {
        private History _ModelHistory;
        private ViewHistory _HistoryView;

        public HistoryController(History modelHistory, ViewHistory historyView)
        {
            _ModelHistory = modelHistory;
            _HistoryView = historyView;
        }

        public void getall()
        {
           var result = _ModelHistory.getall();
            if(result.Count == 0)
            {
                _HistoryView.isempty();
            }
        }
        public void getbyid()
        {
            var getid = _HistoryView.getbyid();
            var result = _ModelHistory.getbyid(getid);

            _HistoryView.getoutput(result);
        }
        public void insert()
        {
            var data = _HistoryView.create();
            var result = _ModelHistory.insert(data);

            switch (result)
            {
                case 0:
                    _HistoryView.error();
                    break;
                case -1:
                    _HistoryView.failure();
                    break;
                default:
                    _HistoryView.success();
                    break;
            }
        }
        public void update()
        {
            var data = _HistoryView.edit();
            var result = _ModelHistory.update(data);

            switch (result)
            {
                case 0:
                    _HistoryView.error();
                    break;
                case -1:
                    _HistoryView.failure();
                    break;
                default:
                    _HistoryView.success();
                    break;
            }
        }
        public void delete()
        {
            var getid = _HistoryView.delete();
            var result = _ModelHistory.delete(getid);

            switch (result)
            {
                case 0:
                    _HistoryView.error();
                    break;
                case -1:
                    _HistoryView.failure();
                    break;
                default:
                    _HistoryView.success();
                    break;
            }
        }
    }
}
