using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    internal class LocationController
    {
        private Location _ModelLocation;
        private ViewLocation _LocationView;

        public LocationController(Location modelLocation, ViewLocation locationView)
        {
            _ModelLocation = modelLocation;
            _LocationView = locationView;
        }
        public void getall()
        {
            var result = _ModelLocation.getall();
            if(result.Count is 0)
            {
                _LocationView.isempty();
            }
            else
            {
                _LocationView.getall(result);
            }
        }
        public void getbyid()
        {
            var getid = _LocationView.getbyid();
            var result = _ModelLocation.getbyid(getid);

            _LocationView.getoutput(result);

        }
        public void insert()
        {
            var data = _LocationView.create();
            var result = _ModelLocation.insert(data);

            switch(result)
            {
                case 0:
                    _LocationView.error();
                    break;
                case -1:
                    _LocationView.failure();
                    break;
                default:
                    _LocationView.success();
                    break;
            }
        }
        public void update()
        {
            var data = _LocationView.edit();
            var result = _ModelLocation.update(data);

            switch (result)
            {
                case 0:
                    _LocationView.error();
                    break;
                case -1:
                    _LocationView.failure();
                    break;
                default:
                    _LocationView.success();
                    break;
            }
        }
        public void delete()
        {
            var getid = _LocationView.delete();
            var result = _ModelLocation.delete(getid);

            switch (result)
            {
                case 0:
                    _LocationView.error();
                    break;
                case -1:
                    _LocationView.failure();
                    break;
                default:
                    _LocationView.success();
                    break;
            }
        }
    }
}
