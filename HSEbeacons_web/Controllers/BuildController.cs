using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HseDataAccess;
using System.Web.Http.Results;

namespace HSEbeacons_web.Controllers
{
    public class BuildController : ApiController
    {
        private DB_9DE66D_beaconsEntities builds = new DB_9DE66D_beaconsEntities();
        //information about all buildings
        [Route("api/Build/GetBuildings")]
        public object GetBuildings()
        {
            return (builds.new_builds.ToList<new_builds>().Select(p => new { buildingId = p.buildingId, buildingName = p.buildingName, Image = p.imageFile, country = p.country, city = p.city, street = p.street, house = p.house, matrixFile = p.matrixFile, description =p.description, lattitude = p.latt, longtitude = p.longt, compass = p.compass }));
        }

        //information about buildings by id
        [Route("api/Build/GetBuildingsById/{id}")]
        public object GetBuildingsById(int id)
        {
            return (builds.new_builds.ToList<new_builds>().Where(e => e.buildingId == id).Select(p => new { buildingId = p.buildingId, buildingName = p.buildingName, Image = p.imageFile, country = p.country, city = p.city, street = p.street, house = p.house, matrixFile = p.matrixFile, description =p.description, lattitude = p.latt, longtitude = p.longt, compass = p.compass }));
        }

        //building names
        [Route("api/Build/GetBuildingNames")]
        public object GetBuildingNames() {
            return (builds.new_builds.ToList<new_builds>().Select(p => new { buildingName = p.buildingName}));
        }

        //matrix of building by id
        [Route("api/Build/GetMatrix/{id}")]
        public object GetMatrix(int id)
        {
            return (builds.new_builds.ToList<new_builds>().Where(e => e.buildingId == id).Select(p => new {matrixFile = p.matrixFile}));
        }

        //building id by beacon id
        [Route("api/Build/GetBuildingIdByBeaconId/{id}")]
        public object GetBuildingIdByBeaconId (int id)
         {
             IEnumerable<new_ibeacons> map = builds.new_ibeacons.Where(e => e.beaconId == id);
             List<new_floors> tmp_list = new List<new_floors>();
             foreach (new_ibeacons f_id in map)
             {
                 IEnumerable<new_floors> floor = builds.new_floors.Where(e => e.floorId == f_id.mapIdFK);
                 foreach (new_floors b_id in floor)
                 {
                     tmp_list.Add(b_id);
                 }
             }
             return tmp_list.Select(p => new { buildingIdFk = p.buildingIdFk });
          }
    }
}
