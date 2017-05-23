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
    public class MapController : ApiController
    {
        private DB_9DE66D_beaconsEntities floors = new DB_9DE66D_beaconsEntities();
        //information about all floors
        [Route("api/Map/getMaps")]
        public object GetMaps()
        {
            return (floors.new_floors.ToList<new_floors>().Select(p => new { floorId = p.floorId, dir = p.dir, tiles = p.tiles, tilesXcount = p.tilesXcount, tilesYcount = p.tilesYcount, mapLevel = p.mapLevel, buildingIdFk = p.buildingIdFk, width = p.width, height = p.height }));
        }

        //information about floor by id
        [Route("api/Map/getMapInfoByMapId/{id}")]
        public object GetMapInfoByMapId(int id)
        {
            return (floors.new_floors.ToList<new_floors>().Where(e => e.floorId == id).Select(p => new { floorId = p.floorId, dir = p.dir, tiles = p.tiles, tilesXcount = p.tilesXcount, tilesYcount = p.tilesYcount, mapLevel = p.mapLevel, buildingIdFk = p.buildingIdFk, width = p.width, height = p.height }));
        }

        //floor id by building id
        [Route("api/Map/getMapIdByBuildingId/{id}")]
        public object GetMapIdByBuilding(int id) { 
            return (floors.new_floors.ToList<new_floors>().Where(e => e.buildingIdFk == id).Select(p => new { floorId = p.floorId }));
        }

        //reference by id
        [Route("api/Map/getMapPathById/{id}")]
        public object GetMapPathByID(int id) { 
            return (floors.new_floors.ToList<new_floors>().Where(e => e.floorId == id).Select(p => new { tiles = p.tiles }));
        }
        //reference by beacon id
        [Route("api/Map/GetMapPathByBeaconId/{id}")]
        public object GetMapPathByBeaconId(int id)
         {
             IEnumerable<new_ibeacons> map = floors.new_ibeacons.Where(e => e.beaconId == id);
             List<new_floors> tmp_list = new List<new_floors>();
             foreach (new_ibeacons f_id in map)
             {
                 IEnumerable<new_floors> floor = floors.new_floors.Where(e => e.floorId == f_id.mapIdFK);
                 foreach (new_floors b_id in floor)
                 {
                     tmp_list.Add(b_id);
                 }
             }
             return tmp_list.Select(p => new { tiles = p.tiles });
          }
        //map id by beacon id
        [Route("api/Map/GetMapIdByBeacon/{id}")]
        public object GetMapIdByBeacon(int id)
         {
             IEnumerable<new_ibeacons> map = floors.new_ibeacons.Where(e => e.beaconId == id);
             List<new_floors> tmp_list = new List<new_floors>();
             foreach (new_ibeacons f_id in map)
             {
                 IEnumerable<new_floors> floor = floors.new_floors.Where(e => e.floorId == f_id.mapIdFK);
                 foreach (new_floors b_id in floor)
                 {
                     tmp_list.Add(b_id);
                 }
             }
             return tmp_list.Select(p => new { floorId = p.floorId });
         }
    }
}
