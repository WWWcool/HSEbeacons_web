
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
    public partial class DatabaseController : ApiController
    {

        /* public new_ibeacons Get(int id)
         {

                 return entities.new_ibeacons.FirstOrDefault(e => e.beaconId == id);              
         }*/
        //информация о всех биконах
        /* public List<new_ibeacons> GetData_all()
         {
             var jsondata = entities.new_ibeacons.ToList<new_ibeacons>();
             return jsondata;
             //информация о всех биконах
         public List<IbeaconInfo> GetData_all()
         {
             var jsondata = db.IbeaconInfoes.ToList<IbeaconInfo>();
             return jsondata;
         }
         public JsonResult getIBeacons()
         {
             var jsondata = GetData_all().Select(p => new { IbeaconId = p.Id, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapId, coordX = p.coordX, coordY = p.coordY, batteryLevel = p.batteryLevel});
             return Json(jsondata, JsonRequestBehavior.AllowGet);
         }

         //число датчиков
         public JsonResult getIBeaconCount()
         {
             var jsondata_1 = 0;
             foreach (IbeaconInfo ibeaconinfo in db.IbeaconInfoes)
             {
                 //jsondata.Add(ibeaconinfo.Id);
                 jsondata_1++;

             }

             var jsondata = new { Number = jsondata_1 };
             return Json(jsondata, JsonRequestBehavior.AllowGet);
         }
         //Отправить id карты по id бикона
         public List<IbeaconInfo> GetData_m_b(int beaconId)
         {
             var jsondata = db.IbeaconInfoes.Where(i => (i.Id == beaconId)).ToList<IbeaconInfo>();
             return jsondata;
         }
         public JsonResult getMapId(int beaconId)
         {
             var jsondata = GetData_m_b(beaconId).Select(p => new { MapId = p.MapInfo.Id});
             return Json(jsondata, JsonRequestBehavior.AllowGet);
         }
         //Отправить описание датчиков по id карты
         public List<IbeaconInfo> GetData_beacons(int MapId)
         {
             var jsondata = db.IbeaconInfoes.Where(i => (i.MapInfo.Id == MapId)).ToList<IbeaconInfo>();
             return jsondata;
         }
         public JsonResult getBeaconsByMap(int MapId)
         {
             var jsondata = GetData_beacons(MapId).Select(p => new { IbeaconId = p.Id, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapId, coordX = p.coordX, coordY = p.coordY, batteryLevel = p.batteryLevel });
             return Json(jsondata, JsonRequestBehavior.AllowGet);
         }//информация о всех биконах
        public List<IbeaconInfo> GetData_all()
        {
            var jsondata = db.IbeaconInfoes.ToList<IbeaconInfo>();
            return jsondata;
        }
        public JsonResult getIBeacons()
        {
            var jsondata = GetData_all().Select(p => new { IbeaconId = p.Id, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapId, coordX = p.coordX, coordY = p.coordY, batteryLevel = p.batteryLevel});
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
    
        //число датчиков
        public JsonResult getIBeaconCount()
        {
            var jsondata_1 = 0;
            foreach (IbeaconInfo ibeaconinfo in db.IbeaconInfoes)
            {
                //jsondata.Add(ibeaconinfo.Id);
                jsondata_1++;

            }

            var jsondata = new { Number = jsondata_1 };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        //Отправить id карты по id бикона
        public List<IbeaconInfo> GetData_m_b(int beaconId)
        {
            var jsondata = db.IbeaconInfoes.Where(i => (i.Id == beaconId)).ToList<IbeaconInfo>();
            return jsondata;
        }
        public JsonResult getMapId(int beaconId)
        {
            var jsondata = GetData_m_b(beaconId).Select(p => new { MapId = p.MapInfo.Id});
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        //Отправить описание датчиков по id карты
        public List<IbeaconInfo> GetData_beacons(int MapId)
        {
            var jsondata = db.IbeaconInfoes.Where(i => (i.MapInfo.Id == MapId)).ToList<IbeaconInfo>();
            return jsondata;
        }
        public JsonResult getBeaconsByMap(int MapId)
        {
            var jsondata = GetData_beacons(MapId).Select(p => new { IbeaconId = p.Id, title = p.title, description = p.description, uuid = p.uuid, minor = p.minor, major = p.major, mapId = p.mapId, coordX = p.coordX, coordY = p.coordY, batteryLevel = p.batteryLevel });
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        //Отправить полную информацию по карте
        public List<MapInfo> GetData(int MapId)
        {
            var jsondata = db.MapInfoes.Where(i => (i.Id == MapId)).ToList<MapInfo>();
            return jsondata;
        }
        public JsonResult getMapInfo(int MapId)
        {
            var jsondata = GetData(MapId).Select(p => new { MapId = p.Id, directory = p.dir, tiles = p.tiles, tilesXcount = p.tilesXcount, tilesYcount = p.tilesYcount, mapLevel = p.mapLevel, width = p.width, height = p.height});
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        //Отправить полную информацию по картам
        public List<MapInfo> GetData_maps()
        {
            var jsondata = db.MapInfoes.ToList<MapInfo>();
            return jsondata;
        }
        public JsonResult getMaps()
        {
            var jsondata = GetData_maps().Select(p => new { MapId = p.Id, directory = p.dir, tiles = p.tiles, tilesXcount = p.tilesXcount, tilesYcount = p.tilesYcount, mapLevel = p.mapLevel, width = p.width, height = p.height });
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

    // имена зданий
        public List<BuildingInfo> GetData_bd()
        {
            var jsondata = db.BuildingInfoes.ToList<BuildingInfo>();
            return jsondata;
        }
        public JsonResult getBuildingsNames()
        {
            var jsondata = GetData_bd().Select(p => new { buildingName = p.buildingName });
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        // информация по зданиям
        public List<BuildingInfo> GetData_b(int buildingId)
        {
            var jsondata = db.BuildingInfoes.Where(i => (i.Id == buildingId)).ToList<BuildingInfo>();
            return jsondata;
        }
        public JsonResult getBuildingInfo(int buildingId)
        {
            var jsondata = GetData_b(buildingId).Select(p => new { buildingId = p.Id, buildingName = p.buildingName, Image = p.Image, country = p.country, city = p.city, street = p.street, house = p.house, matrixFile = p.matrixFIle });
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        //id здания по id бикона
        public List<BuildingInfo> GetData_n(int IbeaconId)
        {
            var jsondata = db.BuildingInfoes.Where(i => (i.IbeaconInfo.Id == IbeaconId)).ToList<BuildingInfo>();
            return jsondata;
        }
        public JsonResult getNodeById(int IbeaconId)
        {
            var jsondata = GetData_n(IbeaconId).Select(p => new { BuildingId = p.Id });
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        //id узла по id карты
        public List<NodeInfo> GetData_n(int MapId)
        {
            var jsondata = db.NodeInfoes.Where(i => (i.MapInfo.Id == MapId)).ToList<NodeInfo>();
            return jsondata;
        }
        public JsonResult getNodeByMap(int MapId)
        {
            var jsondata = GetData_n(MapId).Select(p => new { NodeId = p.Id });
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

         }*/

    }
}
