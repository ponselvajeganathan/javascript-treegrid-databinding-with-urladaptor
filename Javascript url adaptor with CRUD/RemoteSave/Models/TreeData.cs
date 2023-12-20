﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace url.Models
//{
//    public class TreeData
//    {
//        public TreeData() { }

//        public int TaskId { get; set; }



//        public string TaskName { get; set; }
//        public int Duration { get; set; }
//        public int? ParentId { get; set; }
//        public bool? isParent { get; set; }


//        public static List<TreeData> BusinessObjectCollection = new List<TreeData>();



//        public static List<TreeData> GetSelfData()
//        {
//            if (BusinessObjectCollection.Count == 0)
//            {
//                BusinessObjectCollection.Add(new TreeData()
//                {
//                    TaskId = 1,
//                    TaskName = "Parent Task 1",
//                    Duration = 10,
//                    ParentId = null,
//                    isParent = true
//                });
//                BusinessObjectCollection.Add(new TreeData()
//                {
//                    TaskId = 2,
//                    TaskName = "Child task 1",
//                    Duration = 4,
//                    ParentId = 1,
//                    isParent = false
//                });



//                BusinessObjectCollection.Add(new TreeData()
//                {
//                    TaskId = 5,
//                    TaskName = "Parent Task 2",
//                    Duration = 10,
//                    ParentId = null,
//                    isParent = true
//                });
//                BusinessObjectCollection.Add(new TreeData()
//                {
//                    TaskId = 6,
//                    TaskName = "Child task 2",
//                    Duration = 4,
//                    ParentId = 5,
//                    isParent = false
//                });



//                BusinessObjectCollection.Add(new TreeData()
//                {
//                    TaskId = 10,
//                    TaskName = "Parent Task 3",
//                    Duration = 10,
//                    ParentId = null,
//                    isParent = true
//                });
//                BusinessObjectCollection.Add(new TreeData()
//                {
//                    TaskId = 11,
//                    TaskName = "Child task 3",
//                    Duration = 4,
//                    ParentId = 10,
//                    isParent = false
//                });



//            }



//            return BusinessObjectCollection;
//        }
//    }

//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace url.Models
{
    public class TreeData
    {
        public static List<TreeData> tree = new List<TreeData>();
        [System.ComponentModel.DataAnnotations.Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Progress { get; set; }
        public String Priority { get; set; }
        public int Duration { get; set; }
        public int? ParentItem { get; set; }
        public bool? isParent { get; set; }
        public TreeData() { }
        public static List<TreeData> GetTree()
        {
            if (tree.Count == 0)
            {
                int root = -1;
                for (var t = 1; t <= 10; t++)
                {
                    Random ran = new Random();
                    string math = (ran.Next() % 3) == 0 ? "High" : (ran.Next() % 2) == 0 ? "Release Breaker" : "Critical";
                    string progr = (ran.Next() % 3) == 0 ? "Started" : (ran.Next() % 2) == 0 ? "Open" : "In Progress";
                    root++;
                    int rootItem = tree.Count + root + 1;
                    tree.Add(new TreeData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), isParent = true, ParentItem = null, Progress = progr, Priority = math, Duration = ran.Next(1, 50) });
                    int parent = tree.Count;
                    for (var c = 0; c < 10; c++)
                    {
                        root++;
                        string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                        int parn = parent + c + 1;
                        progr = (ran.Next() % 3) == 0 ? "In Progress" : (ran.Next() % 2) == 0 ? "Open" : "Validated";
                        int iD = tree.Count + root + 1;
                        tree.Add(new TreeData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), isParent = (((parent + c + 1) % 3) == 0), ParentItem = rootItem, Progress = progr, Priority = val, Duration = ran.Next(1, 50) });
                        if ((((parent + c + 1) % 3) == 0))
                        {
                            int immParent = tree.Count;
                            for (var s = 0; s < 3; s++)
                            {
                                root++;
                                string Prior = (immParent % 2 == 0) ? "Validated" : "Normal";
                                tree.Add(new TreeData() { TaskID = tree.Count + root + 1, TaskName = "Sub Task " + (tree.Count + root + 1).ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), isParent = false, ParentItem = iD, Progress = (immParent % 2 == 0) ? "On Progress" : "Closed", Priority = Prior, Duration = ran.Next(1, 50) });
                            }
                        }
                    }
                }
            }
            return tree;
        }
    }
}