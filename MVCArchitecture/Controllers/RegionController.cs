using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers
{
    internal class RegionController
    {
        private Region _regionModel;
        private ViewRegion _viewRegion;

        public RegionController(Region regionModel, ViewRegion viewRegion)
        {
            _regionModel = regionModel;
            _viewRegion = viewRegion;
        }
        public void getall()
        {
            var result = _regionModel.getall();
            if(result.Count is 0)
            {
                _viewRegion.isempty();
            }
            else
            {
                _viewRegion.getall(result);
            }
        }
        public void getbyid()
        {
            var getid = _viewRegion.getbyid();
            var result = _regionModel.getbyid(getid);

            _viewRegion.getoutput(result);
        }
        public void insert()
        {
            var region = _viewRegion.create();
            var result = _regionModel.insert(region);

            switch(result)
            {
                case 0:
                    _viewRegion.error();
                    break;
                case -1:
                    _viewRegion.failure();
                    break;
                default:
                    _viewRegion.success();
                    break;
            }
        }
        public void update()
        {
            var region = _viewRegion.edit();
            var result = _regionModel.update(region);

            switch (result)
            {
                case 0:
                    _viewRegion.error();
                    break;
                case -1:
                    _viewRegion.failure();
                    break;
                default:
                    _viewRegion.success();
                    break;
            }
        }
        public void delete()
        {
            var getid = _viewRegion.delete();
            var result = _regionModel.delete(getid);

            switch (result)
            {
                case 0:
                    _viewRegion.error();
                    break;
                case -1:
                    _viewRegion.failure();
                    break;
                default:
                    _viewRegion.success();
                    break;
            }
        }
    }
}
