using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GRPCLayer
{
    public class ProtobufInitializer
    {
        static void InitializeProtobufRunTime()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var currentAssembly in assemblies)
            {
                var types = currentAssembly.GetTypes();

                foreach (var t in types.Where(x => x.Namespace != null && x.Namespace.Contains("GRPCLayer")))
                {
                    Console.WriteLine("Processing {0}", t.FullName);
                    var meta = RuntimeTypeModel.Default.Add(t, false);
                    var index = 1;

                    // find any derived class for the entity
                    foreach (var d in types.Where(x => x.IsSubclassOf(t)))
                    {
                        var i = index++;
                        Console.WriteLine("\tSubtype: {0} - #{1}", d.Name, i);
                        meta.AddSubType(i, d);
                    }

                    // then add the properties
                    foreach (var p in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Where(x => x.GetSetMethod() != null))
                    {
                        var i = index++;
                        Console.WriteLine("\tProperty: {0} - #{1}", p.Name, i);
                        meta.AddField(i, p.Name);
                    }

                }
            }
        }
    }
}
