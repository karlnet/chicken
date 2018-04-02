using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.Tools
{
    public class MenuItem
    {
        public MenuItem(int id, string name, bool leaf, bool expanded, string iconCls,string routeId)
        {
            this.id = id;
            this.leaf = leaf;
            this.name = name;
            this.expanded = expanded;
            this.iconCls = iconCls;
            this.routeId = routeId;
        }
        //[JsonIgnore]
        public int id { get; set; }
        public string name { get; set; }
      
        public bool leaf { get; set; }
       
        public bool expanded { get; set; }
        public string iconCls { set; get; }

        public string routeId { set; get; }
        public object body { set; get; }

        public void setChildren(List<MenuItem> item)
        {
            item.ForEach((m) =>
            {
                m.id = m.id + id * 1000;
            });

            body = item;
        }

    }
}