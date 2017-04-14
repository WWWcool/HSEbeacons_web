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
         /*public object GetIBeacons()
         {
             return (entities.new_ibeacons.ToList<new_ibeacons>()).Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapIdFK, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, batteryLevel = p.batteryLevel });

         }*/

        //information about beacon by id
        /*public object GetIBeaconById(int id)
        {
            return (entities.new_ibeacons.ToList<new_ibeacons>().Where(e => e.beaconId == id).Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapIdFK, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, batteryLevel = p.batteryLevel }));

        }*/
        // beacon id by uuid, minor, major
        public object GetIBeaconByUuidMinorMajor(char id, int minor, int major)
        {
            var jsondata = entities.new_ibeacons.ToList<new_ibeacons>().Where(e => (e.uuid.Equals(id)) & ( e.minor == minor)& (e.major == major)).Select(p => new { IbeaconId = p.beaconId});
            return jsondata;
        }
        public IEnumerable<new_floors> IBeaconsByBuildingId(int id)
        {
            return (entities.new_floors
                .Where(e => e.buildingIdFk == id)).AsEnumerable();

        }
        public object GetIBeaconsByBuildingId(int id) {
            var map = IBeaconsByBuildingId(id).Select(p => new { floorId = p.floorId });
            return (entities.new_ibeacons.ToList<new_ibeacons>() 
                .Select(p => new { IbeaconId = p.beaconId, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapIdFK, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, batteryLevel = p.batteryLevel })
                .Where(e => e.mapId.Equals(map)));

        }
        /*public object GetIBeaconsByBuildingId(int id)
        {
            var mapIdFk = entities.new_floors.ToList<new_floors>().Where(e => e.buildingIdFk == id).Select(p => new { floorId = p.floorId });
            var jsondata = entities.new_ibeacons.ToList<new_ibeacons>().Where(e => (e.mapIdFK.Equals(mapIdFk))).Select(p => new { IbeaconId = p.beaconId });
            return jsondata;
        }*/
        /*public object GetIBeaconsByMapId(int id)
        {
            var jsondata = entities.new_ibeacons.Where(e => (e.mapIdFK.Equals(id))).ToList<new_ibeacons>().Select(p => new { IbeaconId = p.beaconId });
            return jsondata;
        }*/

    }
}
