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
    public class NodeController : ApiController
    {
        private DB_9DE66D_beaconsEntities nodes = new DB_9DE66D_beaconsEntities();
        //information about all nodes
        [Route("api/Node/GetNodes")]
        public object GetNodes()
        {
            return (nodes.new_nodes.ToList<new_nodes>()).Select(p => new { NodeId = p.nodeId, IbeaconIdFk = p.IbeaconIdFk, mapIdFk = p.mapIdFk, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, type = p.type});
        }

        //information about node by id
        [Route("api/Node/GetNodeById/{id}")]
        public object GetNodeById(int id)
        {
            return (nodes.new_nodes.ToList<new_nodes>().Where(e => e.nodeId == id).Select(p => new { NodeId = p.nodeId, IbeaconIdFk = p.IbeaconIdFk, mapIdFk = p.mapIdFk, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, type = p.type }));
        }
        //info about node by building id
        [Route("api/Node/GetNodesByBuildingId/{id}")]
        public object GetNodesByBuildingId(int id)
        {
            IEnumerable<new_floors> map = nodes.new_floors.Where(e => e.buildingIdFk == id);
            List<new_nodes> tmp_list = new List<new_nodes>();
            foreach (new_floors f_id in map)
            {
                IEnumerable<new_nodes> floor = nodes.new_nodes.Where(e => e.mapIdFk == f_id.floorId);
                foreach (new_nodes b_id in floor)
                {
                    tmp_list.Add(b_id);
                }
            }
            return tmp_list.Select(p => new { NodeId = p.nodeId, IbeaconIdFk = p.IbeaconIdFk, mapIdFk = p.mapIdFk, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, type = p.type });
        }
        //Information about nodes by map id
        [Route("api/Node/GetIBeaconsByMapId/{id}")]
        public object GetIBeaconsByMapId(int id)
        {
            var jsondata = nodes.new_nodes.ToList<new_nodes>().Where(e => (e.mapIdFk == id)).Select(p => new { NodeId = p.nodeId, IbeaconIdFk = p.IbeaconIdFk, mapIdFk = p.mapIdFk, coordX = p.coordX, coordY = p.coordY, nodeNum = p.nodeNum, type = p.type });
            return jsondata;
        }
    }
}
