
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
using System.Data.SqlClient;

namespace HSEbeacons_web.Controllers
{
    [Route("api/putibeacons/{title}/{description}/{uuid}/{minor}/{major}/{mapIdFK}/{coordX}/{coordY}/{nodeNum}/{batteryLevel}")]
    public partial class DatabaseController : ApiController
    {
        private DB_9DE66D_beaconsEntities control = new DB_9DE66D_beaconsEntities();
        //create new beacon
        public object GetExBeacons(string title, string description, string uuid, int minor, int major, int mapIdFK, int coordX, int coordY, int nodeNum, int batteryLevel)
        {
            var obj = new new_ibeacons();
            control.new_ibeacons.Add(obj);
            obj.title = title;
            obj.description = description;
            obj.uuid = uuid;
            obj.minor = minor;
            obj.major = major;
            obj.mapIdFK = mapIdFK;
            obj.coordX = coordX;
            obj.coordY = coordY;
            obj.nodeNum = nodeNum;
            obj.batteryLevel = batteryLevel;
            control.SaveChanges();
            if (obj != null)
                return (true);
            else return (false);
        }

        //delete existing beacon
        [Route("api/deletebeaconbyid/{id}")]
        public object GetDelBeaconById(int id)
        {
            var obj = control.new_ibeacons.Find(id);
            if (obj != null) { 
                control.new_ibeacons.Remove(obj);
            control.SaveChanges();

            if (control.new_ibeacons.Find(id) == null)
                return (true);
            else return (false);
            }
            else return (false);
        }

        //create new node
        [Route("api/putnodes/{IbeaconIdFk}/{mapIdFk}/{coordX}/{coordY}/{nodeNum}/{type}")]
        public object GetExNode (int IbeaconIdFk, int mapIdFk, int coordX, int coordY, int nodeNum, string type)
        {
            var obj = new new_nodes();
            control.new_nodes.Add(obj);
            obj.IbeaconIdFk = IbeaconIdFk;
            obj.mapIdFk = mapIdFk;
            obj.coordX = coordX;
            obj.coordY = coordY;
            obj.nodeNum = nodeNum;
            obj.type = type;
            control.SaveChanges();
            if (obj != null)
                return (true);
            else return (false);
        }

        //change matrix 
        [Route("api/putmatrix/{id}/{matrix}")]
        public object GetExMatrix(int id, string matrix)
        {
            var obj = control.new_builds.Where(n => n.buildingId == id).SingleOrDefault();
            if (obj != null)
            {
                obj.matrixFile = matrix;
                control.SaveChanges();
                if (obj != null)
                    return (true);
                else return (false);
            }
            else return (false);
        }
    }
}
