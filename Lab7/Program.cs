using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

namespace Lab7
{
    class Program
    {
        public class NodeFile
        {
            public static int Count = 0;
            public static int ID = 0;

            private int _id;

            public int DateOfLastView;

            public NodeFile Parent;
            public NodeFile OlderFile;
            public NodeFile NewerFile;

            public NodeFile(int dateOfLastView)
            {
                DateOfLastView = dateOfLastView;
                ++Count;
                _id = ++ID;
            }
        }

        private static NodeFile Root;

        static void Main(string[] args)
        {
            AddNewFile(20211219);
            AddNewFile(20211019);
            AddNewFile(20211119);
            AddNewFile(20211125);
            AddNewFile(20210819);
            AddNewFile(20220819);

            ClearTreeFromNodeByDate(Root, 20211120);

            Console.WriteLine();
        }

        private static void ClearTreeFromNodeByDate(NodeFile node, int date)
        {
            if (node.DateOfLastView <= date)
            {
                if (node.NewerFile is null)
                {
                    if (node.Parent is null)
                    {
                        Root = null;
                        return;
                    }

                    if (node.DateOfLastView < node.Parent.DateOfLastView)
                    {
                        node.Parent.OlderFile = null;
                    }
                    else
                    {
                        node.Parent.NewerFile = null;
                    }
                }
                else
                {
                    if (node.Parent is null)
                    {
                        Root = node.NewerFile;
                    }
                    else
                    {
                        if (node.DateOfLastView < node.Parent.DateOfLastView)
                        {
                            node.Parent.OlderFile = node.NewerFile;
                        }
                        else
                        {
                            node.Parent.NewerFile = node.NewerFile;
                        }

                        node.NewerFile.Parent = node.Parent;
                    }

                    ClearTreeFromNodeByDate(node.NewerFile, date);
                }
            }
            else
            {
                if (node.OlderFile is not null)
                {
                    ClearTreeFromNodeByDate(node.OlderFile, date);
                }
            }
        }

        private static void AddNewFile(int date)
        {
            if (Root is null)
            {
                Root = new NodeFile(date);
                // Root.Parent = Root;
                return;
            }

            InsertFile(Root, date);
        }

        private static void InsertFile(NodeFile parent, int date)
        {
            if (parent.DateOfLastView <= date)
            {
                if (parent.NewerFile is null)
                {
                    parent.NewerFile = new NodeFile(date)
                    {
                        Parent = parent
                    };
                }
                else
                {
                    InsertFile(parent.NewerFile, date);
                }
            }
            else
            {
                if (parent.OlderFile is null)
                {
                    parent.OlderFile = new NodeFile(date)
                    {
                        Parent = parent
                    };
                }
                else
                {
                    InsertFile(parent.OlderFile, date);
                }
            }
        }
    }
}