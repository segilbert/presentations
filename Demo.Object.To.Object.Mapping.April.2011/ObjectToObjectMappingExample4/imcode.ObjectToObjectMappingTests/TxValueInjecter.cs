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
using System.Linq;
//
using imcode.ObjectToObjectMapping.DTO;
using imcode.ObjectToObjectMapping.Mappings;
using imcode.ObjectToObjectMapping.Data;
using imcode.ObjectToObjectMapping.Domain;
using imcode.ObjectToObjectMapping.ViewModels;
//
using NUnit.Framework;
//
using Omu.ValueInjecter;

namespace imcode.ObjectToObjectMappingTests
{
    [TestFixture]
    public class TxValueInjecter
    {
        //
        // With ValueInjecter there is no fluent mapping like AutoMapper CreateMap
        //

        [Test]
        public void TestTrainToBrowseTrainsViewModel()
        {
            IxRepository repo = new CxTrainRepository();
            CxTrain train = repo.FindById<CxTrain>(4);
            
            CxBrowseTrainsViewModel viewModel = new CxBrowseTrainsViewModel();
            viewModel.InjectFrom(train);

            Assert.AreEqual(train.Id, viewModel.Id);
            Assert.AreEqual(train.Name, viewModel.Name);
            
            // Unlike AutoMapper ValueInject will Ignore mappings where property name and type do not match
            // no need to set Ignore
            //
            Assert.IsNull(viewModel.DefaultEngineerName);
            Assert.IsNull(viewModel.IsAwake);
        }

        [Test]
        public void TestTrainToBrowseTrainsViewModelHandleBooleanToString()
        {
            IxRepository repo = new CxTrainRepository();
            CxTrain train = repo.FindById<CxTrain>(4);

            CxBrowseTrainsViewModel viewModel = new CxBrowseTrainsViewModel();
            viewModel.InjectFrom(train)
                    .InjectFrom<BooleanToString>(train);

            Assert.AreEqual(train.Id, viewModel.Id);
            Assert.AreEqual(train.Name, viewModel.Name);

            // Unlike AutoMapper ValueInject will Ignore mappings where property name and type do not match
            // no need to set Ignore
            //
            Assert.AreEqual("Y", viewModel.IsAwake);
        }

        [Test]
        public void TestTrainToBrowseTrainsViewModelHandleBooleanToStringAndDefaultEngineerName()
        {
            IxRepository repo = new CxTrainRepository();
            CxTrain train = repo.FindById<CxTrain>(4);

            CxBrowseTrainsViewModel viewModel = new CxBrowseTrainsViewModel();
            viewModel.InjectFrom(train)
                    .InjectFrom<BooleanToString>(train)
                    .InjectFrom<FromEngineerToSimpleStringName>(train);

            Assert.AreEqual(train.Id, viewModel.Id);
            Assert.AreEqual(train.Name, viewModel.Name);

            Assert.AreEqual(string.Format("{0}, {1}", train.DefaultEngineer.LastName, train.DefaultEngineer.FirstName), viewModel.DefaultEngineerName);
            Assert.AreEqual("Y", viewModel.IsAwake);
        }

        [Test]
        public void TestListOfLinesToListOfLineViewModelMapping()
        {
            IList<CxLine> lines = new CxLineRepository().FindAll<CxLine>();

            // Transform-Map
            IList<CxLineViewModel2> lineViewModels = new List<CxLineViewModel2>();
            lineViewModels = CxLineViewModelMapper.Map(lines).ToList<CxLineViewModel2>();

            Assert.AreEqual(3, lineViewModels.Count);

            for (int i = 0; i < lineViewModels.Count; i++)
            {
                CxLineViewModel2 ds = lineViewModels[i];
                CxLine ts = lines[i];

                Assert.AreEqual(ts.Id, ds.Id);
                Assert.AreEqual(ts.Name, ds.Name);
                Assert.AreEqual(ts.NumberOfSwitches, ds.NumberOfSwitches);

                // Nested Mapping for Location
                Assert.AreEqual(ts.Location.Id, ds.Location.Id);
                Assert.AreEqual(ts.Location.AddressLine1, ds.Location.AddressLine1);
                Assert.AreEqual(ts.Location.City, ds.Location.City);
                Assert.AreEqual(ts.Location.Country, ds.Location.Country);
                Assert.AreEqual(ts.Location.Latitude, ds.Location.Latitude);
                Assert.AreEqual(ts.Location.Longitude, ds.Location.Longitude);
                Assert.AreEqual(ts.Location.PostalCode, ds.Location.PostalCode);
            }
        }

        [Test]
        public void TestIDataReaderToListOfLineDTOMapping()
        {
            IDataReader dr = new CxLineRepository().GetDataReader<CxLine>();
            IList<DxLineDTO> lineDtoList = new List<DxLineDTO>();

            try
            {
                while (dr.Read())
                {
                    var lineDto = new DxLineDTO();
                    lineDto.InjectFrom<ReaderInjection>(dr);

                    lineDtoList.Add(lineDto);
                }

                Assert.IsNotNull(lineDtoList);
                Assert.AreEqual(2, lineDtoList.Count);

                // only get this for validation reasons
                dr = new CxLineRepository().GetDataReader<CxLine>();

                foreach (DxLineDTO s in lineDtoList)
                {
                    dr.Read();

                    Assert.AreEqual(dr[CxLineRepository.FieldNames.Id], s.Id);
                    Assert.AreEqual(dr[CxLineRepository.FieldNames.Name], s.Name);
                    Assert.AreEqual(dr[CxLineRepository.FieldNames.NumberOfSwitches], s.NumberOfSwitches);
                }

                dr.Close();

            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
    }
}
