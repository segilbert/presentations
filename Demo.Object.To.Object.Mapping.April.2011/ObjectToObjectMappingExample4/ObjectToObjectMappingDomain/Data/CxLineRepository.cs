#region license

/*
Copyright 2011 Sean Gilbert

Dual licensed under the MIT or GPL Version 2 licenses.

Unless required by applicable law or agreed to in writing, software 
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/

#endregion
//
using System.Collections.Generic;
using System.Data;
//
using imcode.ObjectToObjectMapping.Domain;

namespace imcode.ObjectToObjectMapping.Data
{
    public class CxLineRepository : IxRepository
    {


        #region Implementation of IxRepository

        public T FindById<T>(object id)
        {
            object line = new CxLine()
            {
               Id=3,
               Name="Moab Frontier Line",
               NumberOfSwitches=5,
               Location= new CxLocation{    Id=2,
                                            AddressLine1="123 Danvill Hillside View Top",
                                            City="Moab",
                                            Country="USA",
                                            Latitude="38.5733155",
                                            Longitude="-109.5498395"
                                        }
            };

            return (T)line;
        }

        public IList<T> FindAll<T>()
        {
            var trains =
               new List<CxLine>()
                            {
                                new CxLine{ Id=3,
                                            Name="Moab Frontier Line",
                                            NumberOfSwitches=5,
                                            Location= new CxLocation{   Id=2,
                                                                        AddressLine1="123 Danvill Hillside View Top",
                                                                        City="Moab",
                                                                        Country="USA",
                                                                        Latitude="38.5733155",
                                                                        Longitude="-109.5498395"
                                                                    }
                                            },
                                 new CxLine{ Id=4,
                                            Name="Moab Cliff Side Line",
                                            NumberOfSwitches=6,
                                            Location= new CxLocation{   Id=2,
                                                                        AddressLine1="123 Danvill Hillside View Top",
                                                                        City="Moab",
                                                                        Country="USA",
                                                                        Latitude="38.5733155",
                                                                        Longitude="-109.5498395"
                                                                    }
                                            },
                                new CxLine{ Id=5,
                                            Name="Fruita Frontier Line",
                                            NumberOfSwitches=2,
                                            Location= new CxLocation{   Id=3,
                                                                        AddressLine1="123 Dover View Top",
                                                                        City="Fruita",
                                                                        Country="USA",
                                                                        Latitude="39.1588696",
                                                                        Longitude="-108.7289882"
                                                                    }
                                        }
                            };

            return (IList<T>)trains;
        }

        public IDataReader GetDataReader<T>()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(FieldNames.Id, typeof(int));
            dt.Columns.Add(FieldNames.Name, typeof(string));
            dt.Columns.Add(FieldNames.NumberOfSwitches, typeof(int));
            
            DataRow dr = dt.NewRow();
            dr[FieldNames.Id] = 3;
            dr[FieldNames.Name] = "Moab Frontier Line";
            dr[FieldNames.NumberOfSwitches] = 5;
            
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[FieldNames.Id] = 5;
            dr[FieldNames.Name] = "Fruita Frontier Line";
            dr[FieldNames.NumberOfSwitches] = 2;
            
            dt.Rows.Add(dr);

            return dt.CreateDataReader();
        }

        public struct FieldNames
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string NumberOfSwitches = "NumberOfSwitches";
        }

        #endregion
    }
}
