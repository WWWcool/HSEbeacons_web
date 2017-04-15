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
    public class IbeaconController : ApiController
    {
        private DB_9DE66D_beaconsEntities entities = new DB_9DE66D_beaconsEntities();
        //information about all beacons
        [ActionName("GetIBeacons")]
        public object GetIBeacons()
         {
             return (entities.new_ibeacons.ToList<new_ibeacons>()).Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapIdFK, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, batteryLevel = p.batteryLevel });

         }

        //information about beacon by id
        [ActionName("GetIBeaconById")]
        public object GetIBeaconById(int id)
        {
            return (entities.new_ibeacons.ToList<new_ibeacons>().Where(e => e.beaconId == id).Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapIdFK, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, batteryLevel = p.batteryLevel }));

        }
        // beacon id by uuid, minor, major
        [Route("api/getibeaconbyuuid/{id}/{minor}/{major}")]
        public object GetIBeaconByUuidMinorMajor(string id, int minor, int major)
        {
            var jsondata = entities.new_ibeacons.ToList<new_ibeacons>().Where(e => (e.uuid.Equals(id)) && ( e.minor == minor)&& (e.major == major)).Select(p => new { IbeaconId = p.beaconId});
            return jsondata;
        }
        //Information about beacons by building id
        public object GetIBeaconsByBuildingId(int id)
        {
            IEnumerable<new_floors> map = entities.new_floors.Where(e => e.buildingIdFk == id);//.Select(p => new { floorId = p.floorId });
            List<new_ibeacons> tmp_list = new List<new_ibeacons>();
            foreach (new_floors f_id in map)
            {
                IEnumerable<new_ibeacons> floor = entities.new_ibeacons.Where(e => e.mapIdFK == f_id.floorId);
                foreach (new_ibeacons b_id in floor)
                {
                    tmp_list.Add(b_id);
                }
            }
            return tmp_list.Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapIdFK, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, batteryLevel = p.batteryLevel });
         }
        //Information about beacons by map id
        public object GetIBeaconsByMapId(int id)
        {
            var jsondata = entities.new_ibeacons.ToList<new_ibeacons>().Where(e => (e.mapIdFK == id)).Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapIdFK, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, batteryLevel = p.batteryLevel });
            return jsondata;
        }

        //amount of beacons
        public int GetIBeaconCount()
        {
            IEnumerable<new_ibeacons> floor = entities.new_ibeacons;
            var jsondata_1 = 0;
            foreach (new_ibeacons b_id in floor)
            {
                jsondata_1++;
            }
            return jsondata_1;
        }
        //amount of beacons on the floor
        public int GetIBeaconCountByMap(int id)
        {
            IEnumerable<new_ibeacons> floor = entities.new_ibeacons.Where(e => (e.mapIdFK == id));
            var jsondata_1 = 0;
            foreach (new_ibeacons b_id in floor)
            {
                jsondata_1++;
            }
            return jsondata_1;
        }
        //info about beacons without batteryLevel and map id
        public object GetBeaconWithEventWithOutBatLvlAndMapId()
        {
            return (entities.new_ibeacons.ToList<new_ibeacons>()).Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum});

        }
    }
}
